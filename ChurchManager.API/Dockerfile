FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN mkdir /app
WORKDIR /app
COPY bin/Release/net6.0/publish/ app/
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "ChurchManager.API.dll"]