# B3ChallengeDev_v2
Esta é uma aplicação para a candidatura de vaga como Desenvolvedor Fullstack na empresa B3. v2

#### Nova versão: 
 - Migrado para o .Net Framework 4.7.2;
 - Inserido as validações corretas na camada do client e api;
 - Correções e melhorias no cálculo do CDB;
 - Testes unitários de back e front foram adaptados com as novas regras.

Sistema para simular um investimento no CDB baseando no valor inicial e também em um mês para resgate, além de considerar algumas regras e incluindo cálculos de imposto.

### Frameworks e bibliotecas utilizadas:
- Dotnet Framework 4.7.2
- Angular CLI: 17
- Node: 20.10.0
- Package Manager: npm 10.2.3

- Bootstrap
- SonarLint
- NUnit

- Visual Studio 2019 Community - p/ webapi
- Visual Studio Code - p/ app client

### Como Executar:

Siga os seguintes passos para rodar a aplicação:

1. Clone este repositório:

```bash
  git clone https://github.com/alexandre1sakata/B3ChallengeDev.git
  cd B3ChallengeDev

```

#### Front-end - app client
2. Instale as dependências

```bash
  cd B3ChallengeDev.Client
  npm install
```

3. Inicie a aplicação do client

```bash
  npm start
```

3. Para rodar os testes do front

```bash
  ng test
```

#### Back-end - webapi
1. Restaurar o pacotes

```bash
  cd ..
  cd B3ChallengeDev.WebAPI
  dotnet restore
  ...
  .netFramework472 Solution Explorer => B3ChallengeDev.WebAPI => BuildSolution
```

2. Inicie a aplicação da api

```bash
  dotnet run
  ...
  .netFramework472 Solution Explorer => B3ChallengeDev.WebAPI => Debug => Start New Instance
```

3. Para rodar os testes da API

```bash
  .netFramework472 Solution Explorer => B3ChallengeDev.WebAPI => Run Tests
```
