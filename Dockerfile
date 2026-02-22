# 1. ЭТАП СБОРКИ (SDK)
FROM ://mcr.microsoft.com AS build
WORKDIR /src

# Копируем файл проекта отдельно для кэширования слоев
COPY SkladProject.csproj ./
RUN dotnet restore SkladProject.csproj

# Копируем всё остальное и собираем
COPY . .
RUN dotnet publish SkladProject.csproj -c Release -o /app/publish /p:UseAppHost=false

# 2. ЭТАП ЗАПУСКА (RUNTIME)
FROM ://mcr.microsoft.com
WORKDIR /app
COPY --from=build /app/publish .

# Render требует порт 10000 или 80
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Указываем точное имя DLL (проверьте, что проект называется SkladProject)
ENTRYPOINT ["dotnet", "SkladProject.dll"]
