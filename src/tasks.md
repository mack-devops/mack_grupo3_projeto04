# Projeto_04

## Tasks
### General
- [OK] Criar repositorio da app de monitoramento (https://github.com/mack-devops/mack_grupo3_projeto04)
- Criar o README.md que de uma visão geral do projeto;

### App Monitoramento
- [OK] Serviço de monitoramento que siga a regra desenhada, ou seja, a cada segundo a aplicação faz uma solicitação na rota /health_check e valida se a aplicação está ok, caso a aplicação cair, envia uma notificação para o Rocket.chat. Se a aplicação voltar ao funcionamento normal, a aplicação deve enviar uma notificação de qua a aplicação voltou;

````
--> APP desenvolvido em NODEJS
Executar comandos:
	$ npm install
	$ npm install axios (https://github.com/axios/axios#installing)
````

### API
- [OK] 1 rota deve emular o health check da aplicação (GET para /health_check) e o retorno esperado é o json {“status”: “live”};

````
--> APP desenvolvido em C# .net6
Executar projeto:
	$ dotnet run
````


### Azure Monitor
- Deve-se utilizar o Azure Monitor para criar gráficos para a aplicação principal contendo as seguintes informações:
	- a. Average Memory working set; b. CPU Time;
	- c. Data In; Data Out; 
	- d. Http 2xx;
	- e. Http Server Errors; f. Requests;
	- g. Requests In Application Queue; h. Response Time;
  	
### VM Host
- Configurar docker
- Subir container Rocket.chat