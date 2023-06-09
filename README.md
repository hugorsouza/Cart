# Cart - Carrinho de compras

O Carrinho de Compras é uma aplicação desenvolvida em .NET 5, que utiliza uma arquitetura de camadas para proporcionar uma experiência completa de compras. Esta aplicação oferece duas opções de interação: console e Swagger, permitindo que os usuários adicionem informações por meio do console e consultem os dados utilizando a interface Swagger.

## 🛠️ Arquitetura de Camadas:
O Carrinho de Compras foi desenvolvido utilizando uma arquitetura de camadas, que oferece uma estrutura organizada e flexível para o projeto. A arquitetura de camadas é composta por:

### Camada de Apresentação:
Responsável por interagir com o usuário por meio do console, fornecendo uma interface para adicionar produtos ao carrinho de compras

### Camada de Aplicação: 
Contém a lógica de negócios da aplicação, que processa as solicitações recebidas da camada de apresentação e realiza as operações no carrinho de compras.

### Camada de Acesso a Dados: 
Responsável pelo acesso aos dados do carrinho de compras. Nesta camada, são realizadas operações de leitura e gravação dos produtos.
 
### Camada de Domínio: 
Define os modelos de dados e as regras de negócio relacionadas ao carrinho de compras.

### Camada de Infraestrutura: 
Gerencia aspectos técnicos, como a configuração da aplicação e a integração com o Swagger.

### Banco de Dados SQL: 
A aplicação se integra com um banco de dados SQL para armazenar informações sobre os usuários, listas de conteúdo e detalhes do conteúdo.

### Camadas: 
A arquitetura é dividida em camadas, incluindo a camada de apresentação (API), camada de serviços (regras de negócio), camada de acesso a dados (repositórios) e camada de modelos (entidades de domínio), garantindo um código organizado e modular.

## 🔩 Contribuição:

Se você quiser contribuir para o desenvolvimento do Carrinho de Compras, fique à vontade para abrir uma issue ou enviar um pull request neste repositório.
Esperamos que esta aplicação de Carrinho de Compras desenvolvida em .NET 5 com arquitetura de camadas seja útil e atenda às suas necessidades. Aproveite!
