# Developer Store API

## Overview
The **Developer Store API** is a robust backend solution designed using modern development principles and best practices. This API manages products and provides seamless operations like creating and retrieving product details. The architecture is clean, scalable, and maintainable, adhering to Domain-Driven Design (DDD) and Clean Architecture principles.

## Technologies and Frameworks
The following technologies and frameworks are used in the project:

- **.NET 9**: The core framework for building a high-performance and scalable API.
- **Docker**: Containerization platform to ensure consistent environments across development, testing, and production.
- **PostgreSQL**: Relational database used for structured data storage for products and cart.
- **MongoDB**: NoSQL database for managing unstructured data for sales service.
- **Ocelot**: API Gateway for managing microservice routing and request aggregation.
- **GitHub Actions**: CI/CD pipeline automation for building, testing, and deploying the application.
- **AutoMapper**: Library for object-to-object mapping, simplifying DTO transformations.
- **MediatR**: Library for implementing the Mediator pattern, enabling decoupled and maintainable request/response handling.
- **Domain-Driven Design (DDD)**: Organizing code into domains to reflect the business logic clearly.
- **Clean Architecture**: Layered architecture ensuring separation of concerns and testability.

## Project Structure
The project is organized into the following layers:

1. **API/Domain**
   - Contains the core business logic and entities.
   - Example: `Product` entity.

2. **API/Application**
   - Responsible for handling application logic like commands, queries, and handlers.
   - Example:
     - Command: `CreateProductCommand`
     - Query: `GetProductByIdQuery`

3. **API/Infrastructure**
   - Implements data persistence using PostgreSQL and MongoDB.
   - Contains repositories and database configurations.

4. **API**
   - Exposes endpoints for interacting with the application.
   - Configured with Swagger for API documentation.
   - Example Endpoints:
     - `POST /api/products`: Create a new product.
     - `GET /api/products`: Retrieve a paginated list of products.
     - `GET /api/products/{id}`: Retrieve a product by ID.

## Features Implemented

1. **Create Product**
   - Route: `POST /api/products`
   - Description: Allows the creation of a new product.
   - Workflow:
     - Accepts a DTO from the client.
     - Maps the DTO to the `Product` entity using AutoMapper.
     - Saves the entity to the database using the repository.

2. **Retrieve Products**
   - Route: `GET /api/products`
   - Description: Fetches a paginated list of products.
   - Workflow:
     - Applies sorting and pagination dynamically.
     - Returns the data wrapped in a consistent response structure.

3. **Retrieve Product by ID**
   - Route: `GET /api/products/{id}`
   - Description: Fetches a specific product by its ID.
   - Workflow:
     - Queries the database for the product using the repository.
     - Returns a 404 status code if the product is not found.

## How to Run the Application

1. **Prerequisites**
   - Docker installed on your machine.
   - .NET 9 SDK installed.

2. **Steps**
   - Clone the repository:
     ```bash
     git clone https://github.com/osamukafps/developer-store-beecrowd.git
     ```
   - Navigate to the project directory:
     ```bash
     cd developer-store-api
     ```
   - Build and run the Docker containers:
     ```bash
     docker-compose up --build
     ```
   - Access the API documentation:
     - Swagger: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Roadmap
- Add update and delete product functionality.
- Implement tests
- Add caching with Redis.
- Implement cart service.

## Contributing
Contributions are welcome! Please follow the [contribution guidelines](CONTRIBUTING.md).

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

# Developer Store API

## Overview
The **Developer Store API** is a robust backend solution designed using modern development principles and best practices. This API manages products and provides seamless operations like creating and retrieving product details. The architecture is clean, scalable, and maintainable, adhering to Domain-Driven Design (DDD) and Clean Architecture principles.

## Technologies and Frameworks
The following technologies and frameworks are used in the project:

- **.NET 9**: The core framework for building a high-performance and scalable API.
- **Docker**: Containerization platform to ensure consistent environments across development, testing, and production.
- **PostgreSQL**: Relational database used for structured data storage.
- **MongoDB**: NoSQL database for managing unstructured data.
- **Ocelot**: API Gateway for managing microservice routing and request aggregation.
- **AutoMapper**: Library for object-to-object mapping, simplifying DTO transformations.
- **MediatR**: Library for implementing the Mediator pattern, enabling decoupled and maintainable request/response handling.
- **Domain-Driven Design (DDD)**: Organizing code into domains to reflect the business logic clearly.
- **Clean Architecture**: Layered architecture ensuring separation of concerns and testability.

## Project Structure
The project is organized into the following layers:

1. **Domain**
   - Contains the core business logic and entities.
   - Example: `Product` entity.

2. **Application**
   - Responsible for handling application logic like commands, queries, and handlers.
   - Example:
     - Command: `CreateProductCommand`
     - Query: `GetProductByIdQuery`

3. **Infrastructure**
   - Implements data persistence using PostgreSQL and MongoDB.
   - Contains repositories and database configurations.

4. **API**
   - Exposes endpoints for interacting with the application.
   - Configured with Swagger for API documentation.
   - Example Endpoints:
     - `POST /api/products`: Create a new product.
     - `GET /api/products`: Retrieve a paginated list of products.
     - `GET /api/products/{id}`: Retrieve a product by ID.

## Features Implemented

1. **Create Product**
   - Route: `POST /api/products`
   - Description: Allows the creation of a new product.
   - Workflow:
     - Accepts a DTO from the client.
     - Maps the DTO to the `Product` entity using AutoMapper.
     - Saves the entity to the database using the repository.

2. **Retrieve Products**
   - Route: `GET /api/products`
   - Description: Fetches a paginated list of products.
   - Workflow:
     - Applies sorting and pagination dynamically.
     - Returns the data wrapped in a consistent response structure.

3. **Retrieve Product by ID**
   - Route: `GET /api/products/{id}`
   - Description: Fetches a specific product by its ID.
   - Workflow:
     - Queries the database for the product using the repository.
     - Returns a 404 status code if the product is not found.

## How to Run the Application

1. **Prerequisites**
   - Docker installed on your machine.
   - .NET 9 SDK installed.

2. **Steps**
   - Clone the repository:
     ```bash
     git clone https://github.com/your-repo/developer-store-api.git
     ```
   - Navigate to the project directory:
     ```bash
     cd developer-store-api
     ```
   - Build and run the Docker containers:
     ```bash
     docker-compose up --build
     ```

## Roadmap
- Add update and delete product functionality.
- Implement authentication and authorization using IdentityServer or JWT.
- Add caching with Redis.
- Implement more microservices for additional domains.

## Contributing
Contributions are welcome! Please follow the [contribution guidelines](CONTRIBUTING.md).

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

