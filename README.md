#   CRUD Pedido Back-end
- **autor**: João Vitor Porto (jvaporto@gmail.com)

Api montada em c# com comunicação com banco de dados do tipo mysql para registro de dados realtivos a pedidos e manuseio de chamadas http

## Dependências:

- (c#)[https://docs.microsoft.com/pt-br/dotnet/csharp/]
- (dotnet 5)[https://dotnet.microsoft.com/download/dotnet/5.0]
- (mysql)[https://www.mysql.com/downloads/]

## Setup:

- Executar a query sql presente na pasta db no localhost do mysql
- verificar se as credenciais na linha 13 de PedidoDBCommunicator coincidem com as credenciais do localhost do mysql

## Execução:

Ao executar a aplicação pelo arquivo Program.cs uma janela do navegador será aberta e nela estarão tanto os comandos implementados por esta api como os objetos de transferência que ela utiliza, sempre no formato json.

### Componentes (back-end/pedido_api):
- Controllers/PedidoController: classe que controla os protocolos http
- Repository/PedidoDBCommunicator: classe que comunica a aplicação com o mysql
- Dto: pasta contendo os objetos de transferência de dados (DTO) para as funções get, put e post.
- Program: arquivo responsável por executar a aplicação.
- Startup: arquivo contendo as configurações básicas para levantar o servidor.
- Properties/launchSettings.json: json contendo todas as informações necessárias para levantar o servidor em forma de json.
