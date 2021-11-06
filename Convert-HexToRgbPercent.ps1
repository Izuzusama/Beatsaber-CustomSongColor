[CmdletBinding()]
param (
    [Parameter()]
    [String]
    $HexColor
)

$HexColor = $HexColor.Replace("#", "")
if($HexColor.Length -ne 6){
    Write-Error "HexCode size incorrect"
    exit
}

$r = [Math]::Round([System.Convert]::ToInt64($HexColor[0] + $HexColor[1], 16)/255, 2)
$g = [Math]::Round([System.Convert]::ToInt64($HexColor[2] + $HexColor[3], 16)/255, 2)
$b = [Math]::Round([System.Convert]::ToInt64($HexColor[4] + $HexColor[5], 16)/255, 2)

Write-Output "
{
    `"r`" : $r,
    `"g`" : $g,
    `"b`" : $b
}
"