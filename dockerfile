# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore dependencies
COPY ["BitcoinPriceFetcher.csproj", "./"]
RUN dotnet restore "./BitcoinPriceFetcher.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet build "BitcoinPriceFetcher.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "BitcoinPriceFetcher.csproj" -c Release -o /app/publish

# Use the official .NET runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "BitcoinPriceFetcher.dll"]
