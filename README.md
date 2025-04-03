# 📌 Manage Leads

O projeto foi criado para simular uma aplicação de gerenciamento de Leads. No qual o usuário consegue visualizar as propostas, tendo a opção de aceitar ou não.

## 📋 Tecnologias Utilizadas

- **Frontend:** React
    - **Semantic ui react**
    - **React query**
- **Backend:** .NET
    - **MediatR**
    - **Entity Framework**
- **Banco de Dados:** SQL Server (rodando em container Docker)
- **Containerização:** Docker

## 🚀 Como Rodar o Projeto

### 📌 Pré-requisitos
Certifique-se de ter instalado:
- [Docker](https://www.docker.com/)
- [Node.js](https://nodejs.org/)
- [Visual Studio](https://visualstudio.microsoft.com/) (ou outra IDE para .NET)

### 🔧 Configuração e Execução

#### 🔹 Banco de Dados (Docker)
1. Acesse a pasta LeadsApi:
   ```sh
   cd LeadsApi
   ```

1. Suba o container do SQL Server executando o comando:
   ```sh
   docker-compose --project-name database up -d
   ```
2. Verifique se o container está rodando:
   ```sh
   docker ps
   ```

#### 🔹 Backend (.NET)
1. Acesse a pasta LeadsApi:
   ```sh
   cd LeadsApi
   ```
2. Instale as dependências:
   ```sh
   dotnet restore
   ```
3. Execute a aplicação:
   ```sh
   cd LeadsApi
   dotnet run
   ```

#### 🔹 Frontend (React)
1. Acesse a pasta do frontend:
   ```sh
   cd leadsfront
   ```
2. Ajuste a variavel de ambiente VITE_API no arquivo .env
   ```sh
   VITE_API=url que o backend está rodando
   ```
3. Instale as dependências:
   ```sh
   yarn install
   ```
4. Execute a aplicação:
   ```sh
   yarn dev
   ```
4. Acesse no navegador: [http://localhost:5173/](http://localhost:5173/)



## 📄 Testes

Para realizar os testes, podem ser cadastrados os Leads através do endpoint POST no swagger da API.
  ```sh
   {url que o backend está rodando}/swagger
   ```

