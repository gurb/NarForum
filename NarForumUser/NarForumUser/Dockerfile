# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 7072
EXPOSE 7073


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NarForumUser/NarForumUser/NarForumUser.csproj", "NarForumUser/NarForumUser/"]
COPY ["NarForum.ServiceDefaults/NarForum.ServiceDefaults.csproj", "NarForum.ServiceDefaults/"]
COPY ["NarForumUser/NarForumUser.Client/NarForumUser.Client.csproj", "NarForumUser/NarForumUser.Client/"]
RUN dotnet restore "./NarForumUser/NarForumUser/NarForumUser.csproj"
COPY . .
WORKDIR "/src/NarForumUser/NarForumUser"
RUN dotnet build "./NarForumUser.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NarForumUser.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NarForumUser.dll"]