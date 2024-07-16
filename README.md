# Sistema de Gestão de Portfólio de Investimentos (SPI)

O **Sistema de Gestão de Portfólio de Investimentos** (SPI) tem como objetivo permitir que os usuários da operação gerenciem os investimentos disponíveis e que os clientes possam comprar, vender e acompanhar seus investimentos.

Para atender aos requisitos propostos, o backend disponibiliza duas WebAPIs:

## Serviço de Produtos Financeiros (API FinantialProduct)

- **POST /FinantialProduct**: Cria um produto financeiro no sistema SPI.
- **GET /FinantialProduct**: Consulta produtos financeiros no sistema SPI (utiliza paginação).
- **PUT /FinantialProduct**: Atualiza um produto financeiro no sistema SPI.
- **GET /FinantialProduct/{id}**: Consulta um produto financeiro no sistema SPI utilizando um ID específico.

## Serviço de Negociações de Produtos (API Investments)

- **POST /Investment/buy**: Permite a compra de um produto financeiro por um cliente.
- **POST /Investment/sell**: Permite a venda de um produto financeiro por um cliente.
- **GET /Investment**: Permite a consulta do extrato de um determinado cliente.

A documentação detalhada sobre como utilizar essas WebAPIs está disponível no Swagger, incluindo exemplos de requisições e respostas.
