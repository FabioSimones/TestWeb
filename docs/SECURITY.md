# Segurança

Este documento resume o estado de autenticação, autorização e configuração sensível do `SistemaDeVendas`, com base no que foi encontrado no código-fonte.

## Achado crítico: credencial de banco de dados em texto plano no repositório

O arquivo `SistemaDeVendas/appsettings.json`, **versionado no Git**, contém a connection string do MySQL com usuário e senha reais em texto plano na chave `ConnectionStrings:SistemaDeVendasContext`.

Isso significa que qualquer pessoa com acesso ao repositório (ou ao seu histórico de commits) tem acesso a essa credencial.

**Ações recomendadas (fora do escopo desta tarefa de documentação, a critério do autor):**

1. Trocar a senha do usuário MySQL afetado imediatamente.
2. Remover a credencial do `appsettings.json` e substituí-la por uma referência a variável de ambiente ou ao **User Secrets** do .NET (`dotnet user-secrets`), por exemplo.
3. Adicionar ao `.gitignore` qualquer arquivo local que passe a conter segredos (ex.: `appsettings.Local.json`).
4. Avaliar a necessidade de reescrever o histórico do Git para remover o segredo de commits antigos, caso o repositório seja ou venha a ser público.

## Autenticação e autorização

Não há autenticação nem autorização implementadas. Não existem atributos `[Authorize]`, middleware de autenticação (`UseAuthentication`) ou configuração de identity/cookies de autenticação em `Startup.cs`. Todas as rotas e ações dos Controllers são acessíveis publicamente.

## Proteção contra CSRF

As ações `POST` de criação, edição e exclusão (`DepartmentsController`, `SellersController`) usam `[ValidateAntiForgeryToken]`, o padrão de proteção contra CSRF do ASP.NET Core MVC.

## Tratamento de exceções

- Em ambiente de desenvolvimento: `UseDeveloperExceptionPage()` (exibe detalhes da exceção — não deve ser usado em produção; a própria configuração já restringe isso via `env.IsDevelopment()`).
- Em outros ambientes: `UseExceptionHandler("/Home/Error")` e `UseHsts()`.
- Exceções de integridade referencial ao excluir um vendedor com vendas associadas são capturadas (`IntegrityException`) e tratadas com uma página de erro amigável. **O mesmo tratamento não existe em `DepartmentsController`** — excluir um departamento com vendedores vinculados pode propagar uma exceção de banco não tratada.

## HTTPS

`UseHttpsRedirection()` está habilitado, redirecionando requisições HTTP para HTTPS.
