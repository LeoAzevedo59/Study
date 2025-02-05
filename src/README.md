# [Notiify.me](https://www.notiify.me/)

## Dependências globais

Você precisa ter a SDK instalada em seu computador.

- SDK 8.0.405

Listar todas Sdks disponível em sua máquina:

```bash
dotnet --list-sdks
```

Alterar SDK:

```bash
dotnet new globaljson --sdk-version 6.0.412
```


## Rodar tests unitários

Rodando todos testes do projeto
```bash
dotnet test
```

Rodando testes com watch (Auto Reload)

1. Entre no projeto do teste em especifico
```bash
cd tests/Validators.Tests/
```
2. Comando para rodar os testes
```bash
dotnet watch test
```

Sempre que salvar o arquivo de teste em questão, o mesmo será rodado mostrando se passou ou se tem alguma falha.


## Rodar projeto

Usando dotnet run
```bash
dotnet run --project src/Api
```

Usando dotnet watch run (Auto Reload)
```bash
dotnet watch run --project src/Api
```

## Documentação para testes

- fazer documentação com base [fluent Assertions](https://fluentassertions.com/introduction)
- utilização do README.md como base [Tab News](https://raw.githubusercontent.com/filipedeschamps/tabnews.com.br/refs/heads/main/README.md)


- [Boolean](#boolean)

## Boolean

Espero que seja **True**
```bash
  Assert.True(result.IsValid);
```

Espero que seja **False**
```bash
  Assert.False(result.IsValid);
```




