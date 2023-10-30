
primeiro acesse uma pasta e clone o projeto com:
git clone https://gitlab.com/webteia1/thomasgregteste.git

mude para a branch master:
git checkout master

abra a solução: ThomasGregTeste.sln

no appsettings.json do projeto ThomasGreg.App uma connection string fui criada, substituir a mesma apontando para o ambiente de teste: 

essa conection string alimenta uma variavel de ambiente, localizada no dbContext de nome: ThomasGregDbContext.

a connection é recuperada pela chamada Environment.GetEnvironmentVariable("Default"), se esse Default não for setado deve-se colocar a string da connection nesse campo.

o Campo está nas classes: ThomasGregDbContext e LogradouroRepository.

acesse o sql management e crie a base de dados rodando o seguinte comando
create database ThomasGregTeste;

no visual studio clique com o botão direito na solution e depois em restaurar pacotes nuget.
no visual studio vá no menu ferramentas/Gerenciador de pacotes nuget/console do gerenciador de pacotes.

mude o campo projeto padrão para ThomasGreg.Repository

digite update-database

o migration irá gerar as tabelas do banco de dados.

Após isso abra a pasta Procedures, no projeto ThomasGreg.Repository, dentro da mesma existe o arquivo [InsertLogradouro].

No sql management execute
use ThomasGregTeste 
execute a procedure nessa base de dados.

execute o projeto.
