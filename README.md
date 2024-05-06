# CRUD de Vendedores em ASP.NET Core MVC

Este projeto implementa um CRUD básico de vendedores, departamentos e
vendas usando ASP.NET Core MVC. O CRUD permite criar, ler, atualizar e
excluir as entidades citadas.

## Pré-requisitos

Certifique-se de ter instalado o seguinte software antes de prosseguir:

-   [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual
    Studio Code](https://code.visualstudio.com/)
-   [.NET Core SDK](https://dotnet.microsoft.com/download)
-   Versão da linguagem : 12.0
-   Versão do .NET Framework: 8.0

## Configuração do Ambiente de Desenvolvimento

1.  Clone este repositório em sua máquina local:

``` bash
https://github.com/ichi1ro/projeto_vendedores.git
```

2.  Abra o projeto em seu ambiente de desenvolvimento preferido (Visual
    Studio ou Visual Studio Code).
3.  Para conectar ao banco de dados desejado, basta ir no arquivo
    appsettings.json do projeto, e alterar o ConnectionString para o
    banco escolhido, o banco que usei foi o PostgreSQL.
4.  Certifique-se de que o banco de dados está configurado corretamente.
    Este projeto utiliza o Entity Framework Core para lidar com o banco
    de dados. Execute as migrações para criar o banco de dados:

``` bash
dotnet ef database update
```

## Como Usar

1.  Execute o projeto.
2.  Abra um navegador da web e acesse a URL do aplicativo.
3.  Você será redirecionado para a página inicial.
4.  Na página inicial, na barra superior, você terá opções para:

-   Acessar o CRUD de departamento
-   Acessar o CRUD de vendedores
-   Acessar o CRUD de vendas

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

``` graphql
Projeto_Vendedores/
│
├── Connected Services/ # Onde se armazena os serviços conectados. O projeto pode ter algum serviço conectado, como o Azure.
├── Dependencies/    # São os pacotes importados do NuGet.
├── Properties/      # Propriedades do projeto que podem ser alterados.
├── wwwroot/         # Onde se tem os arquivos css, imagens, libs e arquivos javascript. Basicamente recursos do frontend.
├── Controllers/     # Controladores MVC para manipular requisições HTTP.
├── Data/            # Modelos de dados que representam as entidades.
├── Interfaces/      # Interfaces para serem implementadas nos serviços.
├── Migrations/      # Histórico das migrations realizadas
├── Models/          # Modelos e ViewModels
│   ├── Enums/        # Enumerações para o estado da venda.
│   ├── ViewModels/
├── Services/        # Serviços para os controladores
│   ├── Exceptions/    # Exceções personalizadas      
├── Views/           # Visualizações HTML que são renderizadas pelo ASP.NET Core MVC.
│   ├── Departments/    # Visualizações específicas relacionadas aos departamentos.
│   ├── Home/          # Visualizações específicas relacionadas à página inicial.
│   ├── SalesRecords/   # Visualizações específicas relacionadas às vendas.
│   ├── Sellers/        # Visualizações específicas relacionadas aos vendedores.    
│   ├── Shared/         # HTML em comum para todas as Views.
```

## Tecnologias Utilizadas

-   ASP.NET Core MVC
-   Entity Framework Core
-   Razor Pages
-   HTML
-   CSS (Bootstrap)
-   C# (linguagem de programação)

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue se
encontrar algum problema ou enviar um pull request com melhorias.

## Licença

Este projeto está licenciado sob a Licença MIT.

The MIT License (MIT)

Copyright (c) \[2024\] \[Raphael Ichiro\]

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
