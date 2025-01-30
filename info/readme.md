# Developer Evaluation Project
 
`READ CAREFULLY`
 
## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**
 
- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- Documentation and overall organization will also be taken into consideration
 
## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**
 
As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.
 
Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:
 
* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled
 
It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled
 
If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.
 
### Business Rules
 
* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount
 
These business rules define quantity-based discounting tiers and limitations:
 
1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount
 
2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items
 
## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates.
 
See [Overview](/.doc/overview.md)
 
## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components.
 
See [Tech Stack](/.doc/tech-stack.md)
 
## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability.
 
See [Frameworks](/.doc/frameworks.md)
 
<!--
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

##Mandatory Endpoints
The following endpoints must be implemented with the same names and paths:

GET /carts: Listing of shopping carts.
POST /carts: Creating shopping carts.
GET /products: Listing of products.
POST /products: Creating a product.
POST /sales: Creating a sale with application of discount rules.

baseUrl= http://ocelot-gateway:7777/

Endpoints should return standardized responses:
{
  "data": {},
  "status": "success",
  "message": "Operação concluída com sucesso"
}

##Docker :

services:
  gateway:
    container_name: ocelot-gateway
    build:
      context: ./src
...

  api:
    container_name: sales-api
    build:
      context: ./src  # Diretorio onde o codigo da API esta localizado
...
			
If the repository is structured correctly, docker-compose will identify each Dockerfile and build the images automatically.
You should follow the conteiner names due the tests will call the endpoints.

Checklist for the candidate:

1. The repository must contain:
	src/SalesApi/Dockerfile (Sales API)
	src/Gateway/Dockerfile (Ocelot Gateway)
	docker-compose.yml in the root of the project.
	
docker-compose.yml must be configured to point to the correct Dockerfiles.
 
## Project Structure
This section describes the overall structure and organization of the project files and directories.
 
See [Project Structure](/.doc/project-structure.md)
tem menu de contexto