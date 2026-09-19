# LabUseCase01 — ASP.NET Core .NET 8 + EF Core (Database First) + SQL Server

Projeto completo gerado para o laboratório: CRUD de Tarefa (já pronto), Funcionário, Incidente,
Departamento e CentralDeCusto.

## 1. Pré-requisitos

Instale, na sua máquina:

1. **.NET 8 SDK** → https://dotnet.microsoft.com/download/dotnet/8.0
2. **Docker Desktop** (para rodar o SQL Server sem precisar instalar nada "na unha") → https://www.docker.com/products/docker-desktop/
3. Um editor: **Visual Studio 2022** (Community é grátis) ou **VS Code** com a extensão C# Dev Kit.
   - Se for usar Visual Studio, é só abrir a pasta e clicar em "Abrir pasta como projeto", ou
     gerar a solution com `dotnet new sln` (passo 3).

Confirme que o SDK está instalado:
```bash
dotnet --version   # deve mostrar 8.x
```

## 2. Subir o SQL Server (via Docker)

Na raiz do projeto (onde está o `docker-compose.yml`):
```bash
docker compose up -d
```
Isso sobe um SQL Server 2022 na porta `1433`, com senha `SuaSenhaForte#123` (usuário `sa`).

Se preferir sem Docker Compose, o comando equivalente direto é:
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SuaSenhaForte#123" \
  -p 1433:1433 --name sqlserver-labfullstack -d mcr.microsoft.com/mssql/server:2022-latest
```

## 3. Criar o banco `dbTasks`

Use o `sql/schema.sql` (já inclui as tabelas do laboratório inteiro: Funcionario, Tarefa,
Incidente, Departamento e CentralDeCusto, mais os dados de teste).

**Opção A — Azure Data Studio / SSMS:** conecte em `localhost,1433` com usuário `sa` e a senha
acima, abra o `sql/schema.sql` e execute (F5).

**Opção B — via linha de comando (sqlcmd dentro do container):**
```bash
docker exec -it sqlserver-labfullstack /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U sa -P "SuaSenhaForte#123" -C -i /dev/stdin < sql/schema.sql
```

## 4. Ajustar a connection string

Os arquivos `appsettings.json` e `appsettings.Development.json` já estão configurados para
`localhost` — só troque a senha se você usou outra:

```json
"ConexaoSqlServer": "Server=LOCALHOST;Database=dbTasks;User Id=sa;Password=SuaSenhaForte#123;TrustServerCertificate=True;"
```

## 5. Rodar o projeto

```bash
dotnet restore
dotnet run
```

Acesse a URL que aparecer no terminal (algo como `http://localhost:5xxx`). Você verá o menu com
**Tarefas, Funcionários, Incidentes, Departamentos e Central de Custo**, todos com CRUD completo
(Criar, Listar, Editar, Detalhar, Excluir).

> Se quiser usar o Visual Studio: abra a pasta, deixe ele detectar o `.csproj`, ajuste a
> connection string do mesmo jeito e dê F5.

## 6. O que já vem pronto neste pacote

| Item | Onde está |
|---|---|
| Models (Funcionario, Tarefa, Incidente, Departamento, CentralDeCusto) | `Models/` |
| DbContext (`DbTasksContext`) | `Models/DbTasksContext.cs` |
| Controllers com CRUD completo das 5 entidades | `Controllers/` |
| Views (Index/Create/Edit/Details/Delete) das 5 entidades | `Views/` |
| Menu de navegação já com os 5 links | `Views/Shared/_Layout.cshtml` |
| Script SQL completo (Passo 1 + Passo 4 + Passo 5 do lab) | `sql/schema.sql` |
| SQL Server via Docker | `docker-compose.yml` |

Ou seja: os Passos 1 a 5 do laboratório (criação de tabelas, CRUD de Tarefa, scaffold de
Funcionário, módulo de Incidente, e Departamento/CentralDeCusto) já estão implementados. O que
falta é você **rodar, testar na sua máquina e fazer o fluxo de Git pedido** — veja abaixo.

## 7. GitFlow pedido no laboratório

O enunciado pede para criar uma branch `develop` e, a partir dela, uma branch por fluxo
(Departamento e CentralDeCusto). Sugestão de sequência (rode isso depois de `git init` e do
primeiro commit com o projeto base):

```bash
git init
git add .
git commit -m "chore: estrutura inicial do projeto + CRUD de Tarefa"

git checkout -b develop

git checkout -b feature/departamento develop
# (ajustes específicos de Departamento, se houver)
git add .
git commit -m "feat: CRUD de Departamento"
git checkout develop
git merge feature/departamento

git checkout -b feature/central-de-custo develop
# (ajustes específicos de CentralDeCusto, se houver)
git add .
git commit -m "feat: CRUD de CentralDeCusto"
git checkout develop
git merge feature/central-de-custo
```

## 8. Sobre o Scaffold (Passo 3 e 4.2 do lab)

Este pacote já entrega o resultado final do scaffold (Models + Controllers + Views prontos), mas
se seu professor pedir para você **rodar o comando de scaffold manualmente** (para praticar o
fluxo do Visual Studio), o comando via terminal seria:

```bash
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Name=ConexaoSqlServer" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
```

Isso regenera o `DbTasksContext` e as models a partir do banco — use com cuidado, pois sobrescreve
os arquivos atuais (o `-f`/`-Force` é justamente para isso).

## 9. Quiz do laboratório

O PDF também trazia 10 questões de múltipla escolha sobre SQL, EF Core e POO. Se quiser, posso te
passar em um quiz interativo aqui na conversa para você se testar antes da entrevista/avaliação.
