FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-image
 
WORKDIR /home/app
 
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
 
RUN dotnet restore
 
COPY . .
 
RUN dotnet test ./UniversityUnitTests/UniversityUnitTests.csproj
 
RUN dotnet publish ./UniversityManager/UniversityManager.csproj -o /publish/
 
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
 
WORKDIR /publish
 
COPY --from=build-image /publish .
 
ENTRYPOINT ["dotnet", "UniversityManager.dll"]]