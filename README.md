# Phonenook

API REST de uma **Lista Telefônica**, desenvolvida como parte de um desafio técnico.
O projeto permite **criar**, **consultar**, **atualizar** e **excluir** contatos, utilizando **MongoDB Atlas** como banco de dados. A comunicação entre as camadas é realizada com **MediatR**, e as validações de entrada são implementadas com **FluentValidation**.

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

## ▶️ Como rodar o projeto

### 🔧 Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/) rodando **local** ou em **MongoDB Atlas**

---
### 📌 Passos

#### 1. Clone o repositório
```bash
https://github.com/nicolasmiaguchiku/Phonebook-Technical-Test.git
cd source
```
#### 2. Configure o banco no appsettings.json 

Edite o arquivo Phonebook.WebApi/appsettings.json e ajuste a conexão do MongoDB:
##### Exemplo:
```bash
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "PhonebookDb"
}
```

#### 3. Restaure as dependências
```bash
dotnet restore
```
#### 4. Rode a aplicação
```bash
dotnet run --project Phonebook.WebApi
```


