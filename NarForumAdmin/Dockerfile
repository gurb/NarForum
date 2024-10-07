# Stage 1: Build the Blazor WebAssembly App
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve restore et
COPY ["NarForumAdmin.csproj", "./"]
RUN dotnet restore "./NarForumAdmin.csproj"

# Tüm proje dosyalarını kopyala ve build et
COPY . .
RUN dotnet publish "NarForumAdmin.csproj" -c Release -o /app/build

# Stage 2: Serve with Nginx
FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html

# Yayınlanan (publish edilen) dosyaları nginx dizinine kopyala
COPY --from=build /app/build/wwwroot .

# Özel nginx.conf dosyasını kopyala
COPY nginx.conf /etc/nginx/nginx.conf

# Nginx için portu aç
EXPOSE 7058

# Nginx çalıştır
CMD ["nginx", "-g", "daemon off;"]