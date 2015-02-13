# Enable -Verbose option
[CmdletBinding()]

#Write-Host ("Script has now started")
	
# Regular expression pattern to find the version in the build number 
# and then apply it to the assemblies
$VersionRegex = "\d+\.\d+\.\d+\.\d+"
Write-Host ("Script has now started")
Write-Host ("This should give the correct directory: " + $Env:WORKSPACE)

# Make sure there is a build number
if (-not $Env:GTA_VERSION)
{
	Write-Error ("GTA_VERSION environment variable is missing.")
	exit 1
}
Write-Host "GTA_VERSION: $Env:GTA_VERSION"
Write-Verbose "GTA_VERSION: $Env:GTA_VERSION"
	
# Get and validate the version data
$VersionData = [regex]::matches($Env:GTA_VERSION,$VersionRegex)
switch($VersionData.Count)
{
   0		
      { 
         Write-Error "Could not find version number data in GTA_VERSION."
         exit 1
      }
   1 {}
   default 
      { 
         Write-Warning "Found more than instance of version data in GTA_VERSION." 
         Write-Warning "Will assume first instance is version."
      }
}
$NewVersion = $VersionData[0]
Write-Host "Version: $NewVersion"

$files = gci C:\Jenkins\workspace\RefreshDB -recurse -include "*Properties*","My Project" | 
	?{ $_.PSIsContainer } | 
	foreach { gci -Path $_.FullName -Recurse -include AssemblyInfo.* }
if($files)
{
	Write-Host "Will apply $NewVersion to $($files.count) files."
	
	foreach ($file in $files) {
			
			
		if(-not $Disable)
		{
			$filecontent = Get-Content($file)
			attrib $file -r
			$filecontent -replace $VersionRegex, $NewVersion | Out-File $file
			Write-Host "$file - version applied"
		}
	}
}
else
{
	Write-Warning "Found no files."
}
