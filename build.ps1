
# 1. get latest
# git pull
# git reset --hard
# git clean -f

# 2. version assets
pwsh -NoProfile -NoLogo -ExecutionPolicy unrestricted -command "(Get-Content ./Site/Properties/AssemblyInfo.cs).replace('GITHASH', (git rev-parse --short HEAD)) | Set-Content ./Site/Properties/AssemblyInfo.cs"

# 3. build
dotnet restore
dotnet build -c Release

# 4. run tests
dotnet test -c Release '-l:trx;LogFileName=../../results/Site.Tests.xml'

# 5. deploy
dotnet publish -c Release -o dist Site/Site.csproj
#pwsh -NoProfile -NoLogo -ExecutionPolicy unrestricted -command "Compress-Archive -Path ./dist -DestinationPath ./Site.zip"
#az webapp deployment source config-zip --resource-group $env:resourcegroup --name $env:webapp --src ./Site.zip
