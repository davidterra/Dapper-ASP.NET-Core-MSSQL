# Dapper-ASP.NET-Core-MSSQL

Projeto criando uma webapi REST com Dapper e acessando uma base de dados hospedada em um container Docker com o VSCode. Para a base de dados escolhi uma imagem do MSSQL 2019 do Ubuntu e então para a criação do container escrevi um _dockerfile_ que leva embutido um script para subir a base de dados de exemplo Northwind com informações pré cadastradas.
A pesar da escolha em trabalhar com o MSSQL mative uma abstração na criação da conexão no caso de no futuro alterar o SGBD.

Resolvi alguns problemas hipotéticos:

1. Apresentar um ranking com os melhores vendedores.
1. Totalizar as vendas anuais.
1. Listar todos os produtos cadastrados com suas categorias e fornecedores e a possibilidade de paginar a consulta.
1. Consulta de categorias com os produtos atrelados.
