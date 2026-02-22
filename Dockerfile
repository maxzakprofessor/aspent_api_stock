# 1. ЭТАП СБОРКИ (SDK)
FROM ://mcr.microsoft.com AS build
WORKDIR /app

# Копируем файлы проекта и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем всё остальное и собираем релиз
COPY . ./
RUN dotnet publish -c Release -o out

# 2. ЭТАП ЗАПУСКА (RUNTIME)
# Используем .NET 9 Runtime, так как он стабильнее на Render
FROM ://mcr.microsoft.com
WORKDIR /app
COPY --from=build /app/out .

# Открываем порт (Render по умолчанию ищет 80 или 10000)
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "SkladProject.dll"]
