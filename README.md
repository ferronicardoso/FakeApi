# Projeto de FakeApi em ASP.NET MVC
## Objetivo

Inspirado no site mockable.io e buscando as melhores práticas no desenvolvimento de teste unitário e uso de mock, comecei a desenvolver esse projeto somente para teste de rotas dinamicas do ASP.NET MVC armazenadas em banco de dados.

## Funcionamento

Inicialmente temos dois controllers, um para responder as requisições da api que irá entregar as respostas de acordo com o que foi cadastrado pelo usuário atráves do Dashboard.

## Executando o projeto
Na primeira execução, será baixado as dependências pelo Nuget.

### Rota do Dashboard
http://localhost:33913/dashboard

### Rota da Api
http://localhost:33913/api/<caminho_cadastrado>

