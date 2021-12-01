FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ChurchManager.API/bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ChurchManager.API.dll"]