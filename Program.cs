using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using SkladProject.Data;

var builder = WebApplication.CreateBuilder(args);

// --- 1. СЕРВИСЫ API ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- 2. БАЗА ДАННЫХ ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=sklad.db"));

// --- 3. IDENTITY (СИСТЕМА ПОЛЬЗОВАТЕЛЕЙ) ---
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// --- 4. JWT AUTH ---
var key = Encoding.ASCII.GetBytes("SuperSecretKey12345678901234567890");
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// --- 5. CORS ---

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend", p => 
        p.WithOrigins(
            "http://localhost:5173",             // Локальная разработка (Vue/Vite)
            "http://localhost:4200",             // Локальная разработка (Angular)
            "https://angular-api-sklad-sho9.vercel.app" // Ваш основной фронтенд на Vercel
          )
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()); // Добавьте это, если используете Cookies или Identity
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowVueApp");
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

// --- 6. SEED DATA: АВТОСОЗДАНИЕ АДМИНА ---
using (var scope = app.Services.CreateScope())
{
        // 1. Получаем контекст базы данных
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // 2. КРИТИЧЕСКИ ВАЖНО: Создаем таблицы, если их нет (решает ошибку no such table)
    await db.Database.MigrateAsync();
    
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var adminUser = await userManager.FindByNameAsync("admin");
    
    if (adminUser == null)
    {
        var admin = new IdentityUser { UserName = "admin", Email = "admin@sklad.com" };
        // В .NET Identity пароль Admin123! подходит под базовые требования
        var result = await userManager.CreateAsync(admin, "Admin123!");
        
        if (result.Succeeded)
        {
            // Помечаем, что админ уже "входил" (LockoutEnd), чтобы Vue не просил смену пароля
            admin.LockoutEnd = DateTimeOffset.UtcNow;
            await userManager.UpdateAsync(admin);
        }
    }
}

app.Run();
