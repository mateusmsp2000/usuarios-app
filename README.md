# Usuarios-App

## Prefácio
O intuito dessa aplicação é possibilitar relizar operações de CRUD para usuários do sistema, portanto esses usuários serão gravados em um banco de dados PostgresSql.

## Funcionalidades
* Cadastro de usuário manualmente (Informando dados).
* Cadastro de usuário automaticamente (Dados auto gerados da api pública Random User).
* Edição de usuário.
* Remoção de usuário.

## Para rodar a aplicação:
**⚠️ Observação:** É necessário possuir o docker instalado na maquina para executar a aplicação utilizando a abordagem abaixo.

```bash
docker-compose up --build
```

## Disponibilidade
A aplicação com documentação swagger estará disponível em http://localhost:5000/swagger/index.html


## Frameworks utilizados
* Entity Framework Core - (Utilização de migration para criação das tabelas)

## Tabelas criadas no banco de dados:
| Tabela                | Descrição                                    |
|----------------------|----------------------------------------------|
| **Usuarios**         | Armazena informações dos usuários do sistema. |
| **UsuarioLocalizacoes** | Armazena as localizações / endereços associadas aos usuários. |

## Endpoints
| Tipo   | Rota                          | Descrição                           |
|--------|-------------------------------|-------------------------------------|
| **GET**    | `/api/read/UsuarioRead`         | Lista todos os usuários cadastrados conforme paginação. |
| **GET**    | `/api/read/UsuarioRead/{id}`     | Obter dados de um usuário específico pelo ID. |
| **POST**   | `/api/Usuario`  | Cadastra um novo usuário com dados informados manualmente pelo body. |
| **POST**   | `/api/Usuario/usuarioAleatorio`  | Cadastra um novo usuário com dados aleatórios gerados pela API pública Random User. |
| **PUT**    | `/api/Usuario`                   | Atualiza os dados de um usuário existente. |
| **DELETE** | `/api/Usuario/{id}`              | Exclui um usuário específico pelo ID. |


## Padrões de projetos utilizados:
* **Builder** -> Para a criação de objetos complexos.
* **Command** -> PAra que seja possível encapsular uma solicitação como um objeto, permitindo parametrizar outros objetos com diferentes requisições.

## Objetivo 
* Criar aplicação simples, escalável, que facilite a manutenção no futuro e seja extensível conforme surja novas demandas ou alterações em regras de negócio.

## Possíveis melhorias para versão 2.0
* Integrar api com prometheus e grafana para obtenção de métricas.
* Monitorar banco de dados através do prometheus e grafana.
* Criar testes unitários de todas as camadas, em especial a de domínio por conter lógica de negócios.

## Diagrama de entidades
![alt text](image.png)

