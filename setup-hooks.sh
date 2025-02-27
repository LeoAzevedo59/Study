#!/bin/sh

echo "🔧 Configurando hooks do Git..."
git config core.hooksPath .githooks
echo "✅ Hooks configurados com sucesso!"

echo "🔧 Verificando se o .NET SDK está instalado..."
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET SDK não encontrado! Instale o .NET antes de continuar."
    exit 1
fi

echo "🛠️ Listando SDKs instalados..."
dotnet --list-sdks

echo "🔍 Verificando se o .NET SDK 8.0 está instalado..."
if ! dotnet --list-sdks | grep -q "8.0"; then
    echo "❌ .NET SDK 8.0 não encontrado! Instale o SDK 8.0 antes de continuar."
    exit 1
fi
echo "✅ .NET SDK 8.0 encontrado!"

echo "🧪 Executando testes do projeto..."
if ! dotnet test --no-build --verbosity minimal; then
    echo "❌ Alguns testes falharam! Corrija os erros antes de continuar."
    exit 1
fi
echo "✅ Todos os testes passaram!"

echo "🎉 Configuração concluída com sucesso!"
exit 0