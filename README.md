## Objetivo

Implementar uma API REST para realizar as operações principais de um sistema de gerenciamento de avisos.

## Endpoints 

- GET /api/v1/avisos -> Lista todos os avisos ativos.

- GET /api/v1/avisos/{id} -> Busca aviso pelo Id

- POST /api/v1/avisos -> Cria aviso.

- PUT /api/v1/avisos/{id} -> Atualiza mensagem do aviso.

- DELETE /api/v1/avisos/{id} -> Apaga o aviso (Soft delete).

## Validações

- Id > 0 em todas as operações
- Título e Mensagem obrigatórios na criação.
- Apenas `Mensagem` pode ser alterada no PUT

## Entidade Principal

```csharp
public partial class AvisoEntity
{
	public int Id { get; private set; }
	public bool Ativo { get; set; } = true;
	public string Titulo { get; set; }
	public string Mensagem { get; set; }
	public DateTime DataCriacao { get; set; }
	public DateTime DataAlteracao { get; set; }
}
```

- `Ativo = false` → Aviso deletado.
- `DataAlteracao` é atualizada ao fazer alteração, caso contrario possuirá o mesmo valor da data de criação.

## Arquitetura

**Camadas da Clean Architecture:**

```
Presentation → Application → Domain → Infrastructure
```

- **Presentation**: Controllers
- **Application**: Handlers, Commands, Queries, Validators, Requests e Responses 
- **Domain**: Entidades e Interfaces
- **Infrastructure**: Repositórios e persistência (EF Core InMemory)

### Padrões Utilizados

- **CQRS + MediatR** → separação entre leitura e escrita.
- **Repository Pattern** → abstração do acesso aos dados.
- **FluentValidation** → validações declarativas antes do processamento.
- **Dependency Injection** → resolução automática de dependências.

## Como Executar

clone o repositório

```
git clone https://github.com/Gbishoppp/Desafio-Bernhoeft-GRT.git

```

vá até a pasta do projeto
  
```
  cd BasicoDotNet
```

Restaure os pacotes e rode o projeto

```
dotnet restore 
dotnet run --project 1-Presentation/Bernhoeft.GRT.Teste.Api
```
Acesse:  
**Swagger:** [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Melhorias Futuras

- Filtros nas buscas.
- Testes unitários e de integração.
- Logs estruturados e tratamento global de erros.
- Persistência em banco relacional real.
- incluir um tempo de expiração do aviso.

