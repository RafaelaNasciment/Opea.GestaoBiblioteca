# Opea.GestaoBiblioteca
### Projeto criado para Avaliação Back-end da empresa Opea

---

## ⚙️ Como Executar

### Pré-requisitos
- **SQL Server** instalado  
- **.NET 8 SDK** (para executar a API localmente)

### 1) Configure a conexão com o SQL Server
Edite a seção **`ConnectionStrings`** nos arquivos:
- `Opea.GestaoBiblioteca.Api/appsettings.json`
- `Opea.GestaoBiblioteca.Infrastructure/appsettings.json`

Ajuste o **`Server`** para o seu servidor local. Exemplos:

```json
// Autenticação SQL (usuário/senha)
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OpeaBiblioteca;User Id=sa;Password=SuaSenhaForte!;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
  }
}
```

```json
// Instância nomeada (SQLEXPRESS)
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=OpeaBiblioteca;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
  }
}
```

### 2) Restaurar e compilar
```bash
dotnet restore
dotnet build
```

### 3) Executar a API
A URL e a porta aparecerão no console. A documentação Swagger (em *Development*) fica em:
```
http://localhost:<porta>/swagger
```

---

## 🔚 Endpoints REST (resumo)

### Livros
- `POST /api/livro/v1` — Criar livro  
- `GET  /api/livros/v1/ObterPorId` — Obter livro por Id  
- `GET  /api/livros/v1/ListarLivros` — Listar livros e emprestimos

### Empréstimos
- `POST /api/emprestimo/v1/SolicitarEmprestimo` — Solicitar empréstimo  
- `PUT  /api/emprestimos/v1/DevolveverEmprestimo` — Devolver empréstimo
- 
---

## 🧭 Decisões de Arquitetura (por camada)

### API
- **ASP.NET Core (.NET 8)** com **Controllers** e **Swagger** em `Development`.  

### Application
- **Padrão:** **Use Case + Mediator (MediatR)**.  
  - Um *Request/Handler* por caso de uso (ex.: `CriarLivro`, `SolicitarEmprestimo`, `DevolverEmprestimo`).  
- **Response pattern**: `Response<T>` padroniza saída (sucesso/falha + notificações).  
- **Orquestração**: coordena repositórios/transações e mantém regras no **Domínio**.

### Domain
- **Flunt** para validação.  
- **Linguagem Ubíqua** nos nomes (Livro, Empréstimo, Devolver, Solicitar, QuantidadeDisponivel…).
  
### Infrastructure
- **EF Core (code-first)** + **SQL Server**.  
- **Repository pattern** (ex.: `ILivroRepository`, `IEmprestimoRepository`) + mappings dedicados.  
- **Seeds estáticos** de Livros e Empréstimos via EF Core.  

### Tests
- **xUnit** para testes.  
- **Moq** para isolar Application (mocks de repositórios).  
- **Domínio**: validações e regras (título/autor; emprestar/devolver).  
- **Aplicação**: fluxos de sucesso/erro (sem estoque, devolução duplicada).

---

## 🗃️ Versionamento e Convenções de Commit
- **Git** com commits semânticos: `feat`, `fix`, `chore`.  
  Exemplos: `feat: adiciona endpoint de empréstimo`, `fix: corrige mapeamento datetime2`, `chore: configura EF Core`.

---

## 🧰 Produtividade
- **CodeMaid**: limpeza/organização automática do código (formatar, remover usings, padronizar).


---

## 🧱 Estrutura (alto nível)

```
Opea.GestaoBiblioteca.Domain         # Entidades, regras de domínio, enums
Opea.GestaoBiblioteca.Application    # Use cases / Mediator / Responses
Opea.GestaoBiblioteca.Infrastructure # EF Core, DbContext, Mappings, Repositórios
Opea.GestaoBiblioteca.Api            # API (Controllers, Program)
Opea.GestaoBiblioteca.Tests          # Testes de domínio e aplicação
```

---

## 🧱 Comandos EF Core (referência)

```powershell
Add-Migration {nome da migration} -StartupProject Opea.GestaoBiblioteca.Infrastructure
Update-Database -StartupProject Opea.GestaoBiblioteca.Infrastructure
```

---

##Próximos passos - Sugestões 
## 🔐 Segurança & Configuração 
- Remover a **connection string** do `appsettings.json` e usar **User Secrets** (dev) e **variáveis de ambiente/Key Vault** (CI/CD).  
- Middleware de **tratamento global de exceções** com resposta JSON padronizada.  
- **JWT Bearer** para autenticação/autorização.  
- **Logs estruturados** + **telemetria/health checks**.

---

## 🚀 Roadmap Sugerido
- Cadastro de usuários.  
- Segurança: **JWT**.  
- Observabilidade: logs, **telemetria**, *health checks*.  
- Banco em **Docker** (container SQL Server).  
- Finalizar testes unitários dos **Use Cases** e mapear **cobertura**.  
- Remover secrets do `appsettings` (usar **secrets/env**).  
- **CI/CD** automatizado (ex.: GitHub Actions).

---

