# Образ для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проектов и восстанавливаем зависимости
COPY BackendApi/BackendApi.csproj BackendApi/
COPY BusinessLogic/BusinessLogic.csproj BusinessLogic/
COPY Domain/Domain.csproj Domain/
COPY DataAccess/DataAccess.csproj DataAccess/
RUN dotnet restore "BackendApi/BackendApi.csproj"

# Копируем все файлы и публикуем проект
COPY . .
WORKDIR "/src/BackendApi"
RUN dotnet publish "BackendApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Копируем опубликованные файлы из этапа сборки
COPY --from=build /app/publish .

# Точка входа для запуска приложения
ENTRYPOINT ["dotnet", "BackendApi.dll"]

