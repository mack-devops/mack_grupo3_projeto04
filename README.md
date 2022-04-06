##### mack_grupo3_projeto04
---

# PROJETO 4: MONITORAMENTO DA APLICAÇÃO

## OBJETIVO
Este exercício visa contribuir com o desenvolvimento profissional do aluno, nele espera-se que o aluno tenha um conhecimento básico em linguagem de programação e em API. O objetivo é aplicar os conhecimentos vistos em sala sobre o monitoramento da aplicação.

## EXERCÍCIO
DOECS é uma das maiores empresas de dados do Brasil, e eles estão implementando DevOps aos poucos, a aplicação deles tem um pipeline de CI/CD, porém não foi implementado a fase de monitoramento da aplicação. Você e sua equipe fazem parte de uma empresa de consultoria e deve auxiliar a DOECS no desenvolvimento de um serviço de monitoramento da aplicação. A equipe de arquitetura da sua empresa desenhou a seguinte solução:

![image info](https://raw.githubusercontent.com/mack-devops/mack_grupo3_projeto04/7efa4a842b5f7c3b607711d0b025dfb3210cc48c/doc/flow.png)

## Tasks
### General
- [OK] Criar repositorio da app de monitoramento (https://github.com/mack-devops/mack_grupo3_projeto04)
- [OK] Criar o README.md que de uma visão geral do projeto;

### App Monitoramento
- [OK] Serviço de monitoramento que siga a regra desenhada, ou seja, a cada segundo a aplicação faz uma solicitação na rota /health_check e valida se a aplicação está ok, caso a aplicação cair, envia uma notificação para o Rocket.chat. Se a aplicação voltar ao funcionamento normal, a aplicação deve enviar uma notificação de qua a aplicação voltou;

````
--> APP desenvolvido em NODEJS
> https://nodejs.org/en/download/

Instalação de dependências:
    $ npm install
    $ npm install axios (https://github.com/axios/axios#installing)

Executar projeto:
    $ npm start
````

### API
- [OK] 1 rota deve emular o health check da aplicação (GET para /health_check) e o retorno esperado é o json {“status”: “live”};

````
--> APP desenvolvido em C# .net6
> https://dotnet.microsoft.com/en-us/download/dotnet/6.0

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