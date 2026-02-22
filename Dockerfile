# 1. СБОРКА (SDK)
FROM mcr.microsoft.com AS build
WORKDIR /src

# Копируем файл проекта (Убедись, что он называется SkladProject.csproj)
COPY SkladProject.csproj ./
RUN dotnet restore SkladProject.csproj

# Копируем всё остальное и собираем релиз
COPY . .
RUN dotnet publish SkladProject.csproj -c Release -o /app/publish

# 2. ЗАПУСК (RUNTIME)
FROM mcr.microsoft.com
WORKDIR /app
COPY --from=build /app/publish .

# Настройка порта для Render (обязательно 10000)
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Имя DLL должно совпадать с именем проекта
ENTRYPOINT ["dotnet", "SkladProject.dll"]
