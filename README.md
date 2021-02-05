# DesafioSances


Para este desafio, foram criado 2 aplicações, onde a aplicação Item, é responsável pelo cadastro dos itens, e a Pedido é responsável pelo cadastro dos pedidos.

Para armazenamento dos dados, foi utilizado o banco de dados SqL Server.

Aplicações: Item = Código, Quantidade, Valor Unitário, Desconto, Valor Total; 
Pedido = Número, Data, Descrição, Situação; 

Todas as aplicações foram desenvolvidas em C#, todo o código foi feito no programa Visual Studio Code. 
Para os testes de apresentação das requisições foi utilizada a ferramenta do Postman, e as informações eram apresentadas via requisição HTTP e retornavam JSON.

Na pasta Desafio encotra-se a parte Back end.
Na pasta DesafioFront, está o FrontEnd para executar o processo.

Utilozado terminal do VS Code para rodar tanto Back (comando: "dotnet watch run) quanto Front (comando: "npm start").
Utilizado "http://localhost:4200/" para apresentação do Front.


Ao seleciona a opção Cadastrar produto, a opção "Situação" já vem pré definida como "Em Análise".
Para fazer alteração do pedido, será necessário clicar no botão "Detalhes" e alterar a opção "Situação" manualmente, para "Aprovar" ou "Cancelar".

Na opção "Cadastrar Pedido"o formato da data precisa ser "0000-00-00T00:00:00" para o "Salvar" funcionar.
