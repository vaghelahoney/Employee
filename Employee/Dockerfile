# 1. Runtime environment (Yahan app chalegi)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Build environment (Yahan app compile hogi)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Apna .csproj file copy karke restore karein
COPY ["Employee.csproj", "./"]
RUN dotnet restore "Employee.csproj"

# Baaki saara code copy karke build karein
COPY . .
RUN dotnet build "Employee.csproj" -c Release -o /app/build

# 3. App ko publish karein
FROM build AS publish
RUN dotnet publish "Employee.csproj" -c Release -o /app/publish

# 4. Final step: App run karein
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Employee.dll"]