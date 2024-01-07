# Url Shortener

## Instalar as dependências do projeto no Linux

### Instalar o SDK ou o runtime do .NET 7.0 no Ubuntu 22.04
https://learn.microsoft.com/pt-br/dotnet/core/install/linux-ubuntu-2204

### Para buildar o projeto
```../src$ dotnet build UrlShortener.sln```

### Para rodar o projeto
```../src$ dotnet run --project UrlShortener.Api/UrlShortener.Api.csproj```

### cURL para realizar teste de POST através de um cliente de API:
```
 curl --request POST \
 --url http://localhost:5230/v1/shorten/ \
 --header 'Content-Type: application/json' \
 --data '{
 "longUrl": "https://www.dummy-url.com"
 }'
```
### cURL para realizar teste de GET através de um cliente de API:
```
curl --request GET \
  --url http://localhost:5230/v1/ae64d27
```

### OBS:
- A longUrl no cURL de POST é somente um exemplo, deve ser substituida por qualquer URL válida;
- A shortUrl no cURL de GET é um exemplo gerado pelo sistema com base na longUrl do cURL de POST;
- O projeto está configurado para rodar na porta 5230, mas pode ser alterado no arquivo src/UrlShortener.WebApi/Properties/launchSettings.json;
