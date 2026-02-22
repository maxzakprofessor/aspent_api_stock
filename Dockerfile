# 1. ЭТАП СБОРКИ (SDK)
FROM ://mcr.microsoft.com AS build
WORKDIR /src

# Копируем файл проекта (УБЕДИСЬ, ЧТО ОН НАЗЫВАЕТСЯ SkladProject.csproj)
COPY SkladProject.csproj ./
RUN dotnet restore SkladProject.csproj

# Копируем остальное и собираем
COPY . .
RUN dotnet publish SkladProject.csproj -c Release -o /app/publish

# 2. ЭТАП ЗАПУСКА (RUNTIME)
FROM ://mcr.microsoft.com
WORKDIR /app
COPY --from=build /app/publish .

# Настройка порта для Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Убедись, что итоговый файл называется SkladProject.dll
ENTRYPOINT ["dotnet", "SkladProject.dll"]
