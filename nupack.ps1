############### Remove RavenDB Abandonned Indexes #########################
#--------------------------------------------------------------------------
# Example of call: 
#   > .\RavenDB-RemoveAbandonnedIndexes.ps1 -testRun -server "http://localhost:8080"
# Result: 
#   Start the process in test run to show what will be deleted from the specified RavenDB URL
# Tested on:
#   RavenDB 2.5
###########################################################################
[CmdletBinding()]
Param(
  # Path to azure publish settings. It can be downloaded easilly from Azure portal
  [Parameter(Mandatory=$false)]
  [string]$k = "somekindofkey",

  # Set the version
  [Parameter(Mandatory=$false)]
  [string]$v = "1.0.0",

  # Show help
  [Parameter(Mandatory=$false)]
  [switch]$h = $false
)

if ($h -or $key -eq "somekindofkey" ){
  Write-Host "==============================="
  Write-Host "Parameters:"
  Write-Host " -h                 : This documentation"
  Write-Host " -v                 : Nuget version of package"
  Write-Host " -k thenugetkey     : Use that key to publish the package"
  Write-Host "==============================="
  exit 0;
}

$nupkgs = "$((Get-Location).Path)\nupkgs"
# Remove all the files from the nupkgs folder
Get-ChildItem "$((Get-Location).Path)\nupkgs" | ForEach-Object { $_.Delete() }

$cmd = "dotnet build ./CognitiveServices.Translator.Client/CognitiveServices.Translator.Client.csproj -c=Release"
Invoke-Expression $cmd

# Build and pack
$cmd = "dotnet pack ./CognitiveServices.Translator.Client/CognitiveServices.Translator.Client.csproj /p:PackageVersion=$v --include-source --include-symbols -c=Release -o $nupkgs"
Invoke-Expression $cmd

# Ask if we really want to push the packages.
$cmd = "dotnet nuget push $nupkgs\CognitiveServices.Translator.Client.$v.nupkg -s=https://api.nuget.org/v3/index.json -ss=https://nuget.smbsrc.net -k=$k --force-english-output"
Invoke-Expression $cmd
