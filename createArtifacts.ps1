############### Create archive demoWebsite.zip for publish #########################
#--------------------------------------------------------------------------
###########################################################################
$artifacts = "$((Get-Location).Path)/artifacts"
# Remove all the files from the nupkgs folder
# Remove-Item "$artifacts/*" -Force -Recurse 

$cmd = "dotnet publish ./CognitiveServices.Translator.Client.WebSample/CognitiveServices.Translator.Client.WebSample.csproj -c=Release -o=$artifacts"
Invoke-Expression $cmd

Compress-Archive -Path "$artifacts/*" -DestinationPath "$artifacts\demoWebsite.zip"
Remove-Item "$artifacts/*" -Force -Recurse -Exclude "demoWebsite.zip"
