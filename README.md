# CadastroPessoa
Projeto Cadastro de Pessoas em AspNet Web Api (backend) e Aspx (frontend)

Libraries
- Para conexao como banco de dados MySql
  - Microsoft.EntityFrameworkCore 
    - version: 3.1.10
  - Microsoft.EntityFrameworkCore.Tools
    - version: 3.1.10
  - MySql.Data.EntityFrameworkCore 
    - version: 8.0.22


- No console do gerenciador NuGet
  Scaffold-DbContext "server=localhost;user id=<user>;password=<password>;database=<name_database>;" MySql.Data.EntityFrameworkCore -OutputDir Models
 
