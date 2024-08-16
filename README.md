# GlobTester
A simple glob testing tool.


```ps1
# build
dotnet publish --configuration Release -p:PublishProfile=FolderProfile --output ".\artifacts\GlobTester" ".\src\GlobTester\GlobTester.csproj"

# run sample
.\artifacts\GlobTester\GlobTester.exe "src/**" "!**/bin/**" "!**/obj/**"
```
