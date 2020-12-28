# SimpleAuthService
This is a simple identity management and authentication service that lets you:
* Manage accounts and account emails
* Manage authentication
* Manage account claims

API Preview & Documentation: http://simpleauthservicedemo.azurewebsites.net/swagger/index.html  
(yes, i am aware that this thing is useless when using plain http. will work on https and hsts when i have time.)  
API Key = "iniapikey"

## Technologies
* Entity Framework Core 3.1.9 (O/RM)
* Autofac (Dependency Injection)
* MediatR (Mediator to facilitate Command Query Responsibility Segregation)
* Automapper (Object-object mapping)
* FluentValidation (Input validation)
* PostgreSQL (Persistence RDBMS)
* ASP.NET Core (Web Framework)
* NSwag (API Documentation)

## Getting Started
Simply deploy and navigate to [base url]/swagger in the browser.
