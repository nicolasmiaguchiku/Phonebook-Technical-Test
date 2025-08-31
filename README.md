API REST de uma **Lista Telefônica**, desenvolvida como parte de um desafio técnico.  
O projeto permite criar, consultar, atualizar e excluir contatos, utilizando **MongoDB** como banco de dados e **MediatR** para comunicação entre as camadas


## 🚀 Tecnologias utilizadas
- **.NET 8**
- **ASP.NET Core Web API**
- **MongoDB** MongoDB Atlas
- **MediatR** (para Commands e Queries)
- **FluentValidation** (validações de entrada)


## 📂 Estrutura do Projeto
O projeto segue uma organização em camadas inspirada na **Clean Architecture**:

- **API** → Camada de entrada da aplicação (Controllers / Endpoints).
- **Application** → Contém Handlers, Commands, Queries, Validators.
- **Domain** → Entidades principais (ex.: `Contact`) e interfaces (ex.: `IContactRepository`).
- **Infrastructure** → Configuração do banco de dados, persistência e repositórios.
- **Shared** → Classes e configurações compartilhadas, como resultados padronizados e leitura de settings.
