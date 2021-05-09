# Educacional
Projeto proposto pela empresa evolucional educação

## Características do projeto
O desenho deste projeto, embora ainda não totalmente aderente, usa princípios de DDD e SOLID. 
Foi utilizando autenticação JWT no controle de acessos às APIs e Entity Framework para acesso a base de dados.
A implementação foi feita utilizando linguagem de programação c# e .netCore 5.

Embora não tenha sido possível entregar a parte visual em tempo hábil, havia a intenção que a camada de apresentação web fosse entregue em Angular.


## Configuração do projeto
1. Criar database na base de dados SQL Server
2. Executar o arquivo educacional.sql no novo database
3. Alterar a string de conexão no arquivo appsettings.json, do projeto Educacional.LayerApplication
3. Alterar o local para geração do relatório de alunos, dentro arquivo appsettings.json do projeto Educacional.LayerApplication

## Procedimentos para teste
Não foi possível entregar a parte visual da aplicação. Porém todo o desenho de construção da aplicação é funcional e testável atrávés do software Postman, seguindo estes passos:

1. Importar arquivo Evolucional.postman_collection.json da pasta Postman
2. Alterar endereço de invocação das APIs de acordo com a configuração usada no Visual Studio.
3. Invocar a API Login, passando as credencias de usuário e senha para obter o token de acesso (o token está configurado com um tempo de validade de 5 minutos
4. Invocar a API Student, passando o token de acesso obtido na execução da API Login
5. Invocar a API Subject, passando o token de acesso obtido na execução da API Login
6. Invocar a API StudentSubject, passando o token de acesso obtido na execução da API Login
7. Invocar a API Report, para gerar o relatório de alunos e obter o link para download do arquivo excel





