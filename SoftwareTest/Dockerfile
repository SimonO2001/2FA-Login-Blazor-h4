# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["SoftwareTest.csproj", "./"]
RUN dotnet restore "./SoftwareTest.csproj"

# Copy the remaining source code and publish the app
COPY . .
RUN dotnet publish "SoftwareTest.csproj" -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Copy the certificate into the container
COPY mycert.pfx ./

# Expose ports (5000 for HTTP, 5001 for HTTPS)
EXPOSE 5000
EXPOSE 5001

# Define the entry point
ENTRYPOINT ["dotnet", "SoftwareTest.dll"]
