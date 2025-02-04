# [notiify.me](https://www.notiify.me/)

### Dependências globais

Você precisa ter a SDK instalada em seu computador.

- SDK 8.0.405

listar todas Sdks disponível em sua máquina:

``dotnet --list-sdks``


alterar SDK:

``dotnet new globaljson --sdk-version 6.0.412``

### Rodar tests unitários

Rodando todos testes do projeto

``dotnet test``

Rodando testes com watch (Auto Reload)

1. Entre no projeto do teste em especifico
``cd tests/Validators.Tests/``
2. Comando para rodar os testes
``dotnet watch test``

Sempre que salvar o arquivo de teste em questão, o mesmo será rodado mostrando se passou ou se tem alguma falha.


### Rodar projeto

Usando dotnet run

``dotnet run --project src/Api``

Usando dotnet watch run (Auto Reload)

``dotnet watch run --project src/Api``




