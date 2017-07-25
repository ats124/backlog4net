$apiKey = $args[0]
$data = Get-Content "general.json" -Raw
$data = $data -creplace "APIKEY", $apiKey
Set-Content "general.json" $data