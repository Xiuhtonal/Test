FROM mcr.microsoft.com/dotnet/sdk:latest

WORKDIR /app

COPY . .

CMD ["dotnet", "run"]