FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY . .
CMD [ "dotnet" ,"/app/workdays_api/bin/Debug/netcoreapp3.1/publish/workdays_api.dll"]
EXPOSE 80