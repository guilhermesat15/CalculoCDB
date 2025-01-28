# Avaliação do cálculo do CDB

Tecnologias e frameworks usados na solução:

ASP.NET Core and C# para p BackEnd versão net8 <br />
Angular and TypeScript para o FrontEnd, [Angular CLI](https://github.com/angular/angular-cli) versão 19.1.4 <br />
Bootstrap para layout das telas versão 5.3.3 <br />

## Instalação

1. Clone o repositório:

   <b> git clone https://github.com/guilhermesat15/CalculoCDB.git </b>

1. Vá até a pasta clonada e execute <br />
<b>dotnet build</b> 

## Executando a aplicação 

1. Configure a inicialização<br />
-Marque com o botão direito encima da solution(Configurar Projeto de Inicialização / Propriedades Comuns/ Projeto de Inicialização), <br />
-Marque a opção "Vários projetos de inicialização" e selecione a opção "Iniciar" para os dois projetos(CalculoCDB.API e CalculoCDB.AppWeb) e acione o botão ok e execute os projetos.<br />

Aplicação web poderá ser acessada em (http://localhost:4200/)<br />
Aplicação api poderá ser acessada em (http://localhost:8080/swagger/index.html)<br />

ou 

2. Navegue até o diretório CalculoCDB.AppWeb <br />  
<b>cd CalculoCDB.AppWeb </b> <br />

execute <br />
<b> dotnet run </b>  <br />


## Executando testes unitário e relatórios de cobertura da camada lógica. 

Usei os testes os seguintes frameworks: 

coverlet.msbuild <br />
coverlet.collector <br />
MSTest.TestFramework <br />

Navegue até a pasta ./CalculoCDB/CalculoCDB.Test e execute o comando  <br />
dotnet test --filter 'FullyQualifiedName!~calculo0cdb.Tests' /p:CollectCoverage=true <br />




