$apiKey = $args[0]
$apiKey2 = $args[1]
$data = Get-Content "general.json" -Raw
$data = $data -creplace "APIKEY1", $apiKey
$data = $data -creplace "APIKEY2", $apiKey2
Set-Content "general.json" $data