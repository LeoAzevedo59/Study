# Study

Repository para estudar backend com foco em utilziar boas praticas e novidades do .NET C#

## Inicio

Clonar o projeto 

```bash
  git clone git@github.com:LeoAzevedo59/Study.git
```

- Com o código na sua máquina entre no root do projeto `Study`;
- Caso esteja utilizando MacOs, digite o comando ``chmod +x setup-hooks.sh`` para dar permissão para o comando `sh` de configuração inicial;
- Rode o comando para configuração inicial ``sh setup-hooks.sh``
- Caso aparece a mensagem ``🎉 Configuração concluída com sucesso!``, você já pode usar o projeto.
- O comando irá verificar se você possui a SDK 8.0 .NET;
- O comando irá verificar os testes de unidade;
- O comando irá verificar os testes de integração;
- O comando irá configurar o ``pre-commit`` do git;
- O comando irá verificar a estilização do código;

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

## Theory
Caso você queira realizar um teste de unidade, porem alterando em vários valores você pode utilizar ``theory``, para que
seja realizado um laço de repitção entre vários valores pre-setado por você.

**Exemplo**
```bash
  [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amount_Invalid(decimal amount)
```

O teste será realizado com o valor da váriavel **decimal amount**, 0, -1.
- Dentro da função será realizada o teste individualmente de cada valor;
- Não será na ordem que você declarou, por exemplo o teste pode iniciar pelo valor -1 e depois 0;
- Não conseguirá validar os dois valores ``InlineDate`` ao mesmo tempo;

## Boolean

Espero que seja **True**
```bash
  Assert.True(result.IsValid);
```

Espero que seja **False**
```bash
  Assert.False(result.IsValid);
```

## Database

Gerando uma nova migration

```bash
 dotnet ef migrations add <NomeMigration> --project Infra --startup-project Api
```


Executar migration

```bash
dotnet ef database update  --project Infra --startup-project Api
```

Listar migrations existentes


```bash
dotnet ef migrations list  --project Infra --startup-project Api
```