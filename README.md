## Tech Stacks
Our web application leverages a robust and scalable tech stack to deliver a seamless user experience. The key components of our tech stack include:

- **Backend** - DOT NET CORE WEB API 7.0 with Dapper, Entity Framework Core for database interactions
- **Database** - SQL Server 2019 with indexing for optimal query performance, leveraging built-in ACID compliance for data integrity.
- **Frontend** - Angular 15 with Material, primeng, bootstrap for building responsive and visually appealing UI components, utilizing Webpack and Babel for efficient code
management.
- **Cloud Infrastructure:** AWS with EC2 instances, RDS for databases, and S3 for storage.

## Development Tools:
Our development team relies on the following tools to streamline our workflow:

- **Visual Studio Code**: Integrated Development Environment (IDE) with code completion, debugging, and version control integration for frontend development.
- **Visual Studio 2022**: Integrated Development Environment (IDE) with code completion, debugging, and version control integration for backend development.
- **Git**: As Source control and code versioning.

## FE
This is Angular Application with version 15. This Application having following components

- Component - This module contains all components listed to define fields for doing CRUD operations in Grid level.

## BE
This is DOT NET CORE WEB API 7.0 Application. This application follows Clean Architecture Pattern.

- Domain - Contains all bussiness entities
- Application - This layer contains all bussiness logic and resources which will be used in application.
- Infrastructure - This layer provide all kind of infrastructure services along with external parties injected.
- WebApi - This is presentation layers exposing APIs to be consumed by Frontend applications.
