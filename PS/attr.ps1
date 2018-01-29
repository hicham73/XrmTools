#$fields = "asyncautodelete, categoryname, uniquename, subprocess, primaryentityname, description, typename, inputparameters, name, businessprocesstype, category"

$fields = "asyncautodelete", "uniquename", "subprocess", "description", "inputparameters", "name", "businessprocesstype", "category"

#$fields = $fields.Split(",")

foreach($field in $fields)
{
    $TextInfo = (Get-Culture).TextInfo
    $field = $field.Trim()
    $method = $TextInfo.ToTitleCase($field)

    #Write-Host "public string $method`n{`n`tget { return e.GetAttributeValue<string>(""$field""); } `n`tset {} `n}"
    Write-Host "new KeyValuePair<string, string>(""$method"",""$method""),"
}