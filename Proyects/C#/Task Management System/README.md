# Task Management System — .NET / C# Project

Task management system developed with **.NET and C#**, designed to manage users, boards, and tasks through a role-based access system.

The project follows a layered structure based on **Controllers, Repositories, Models, ViewModels, and Views**, separating the application's business logic, data access, data models, and user interface.

The system allows administrators and regular users to manage boards and tasks according to their permissions, while controlling access to information depending on ownership and task assignments.

**Programmer:** Andy Alejandro Rodriguez Rodriguez

**Git Repository:** [GitHub — Task Management System](https://github.com/TallerDeLenguajes1/tl2-tp10-2023-AndyRR2/tree/main/Proyect?utm_source=chatgpt.com)

# Guide

The project is developed using **.NET and C#** following an MVC-style architecture.

The application is organized into the following main components:

* **Controllers** — Handle HTTP requests, application flow, authentication, and access control.
* **Repositories** — Handle communication with the database and provide operations for users, boards, and tasks.
* **Models** — Represent the main entities of the system.
* **ViewModels** — Provide the data required by each view and connect the presentation layer with the models.
* **Views** — Provide the user interface and display the information received from the controllers.

The different layers are connected according to their responsibilities. For example, a View uses its corresponding ViewModel:

`@model Proyect.ViewModels.DeleteUserViewModel`

A ViewModel can use the required Models:

`using Proyect.Models;`

Controllers use the corresponding Repositories, Models, and ViewModels:

`using Proyect.Repositories;`
`using Proyect.Models;`
`using Proyect.ViewModels;`

This separation allows each part of the application to have a specific responsibility and keeps the code organized.

## System Overview

The system is based on three main entities:

* **Users**
* **Boards**
* **Tasks**

Users can have different access levels:

* **Administrator**
* **Simple User**

Boards belong to users and contain tasks. Tasks can have an owner and can also be assigned to other users.

The permissions available to a user depend on their role and their relationship with the board or task.

## Features

### User Management

The system provides functionality for creating, editing, deleting, and viewing users.

Administrators have access to all users, while simple users have restricted access to operations involving their own account.

The system also verifies that a username does not already exist before creating a new user.

### Board Management

Boards are used to organize tasks.

Administrators can manage any board, while simple users can manage only boards where they are the owner.

Simple users can also access boards when they have tasks assigned to them or when they own tasks within those boards.

Boards can be disabled when their owner is deleted, allowing the system to preserve the relationship between the board and its tasks.

### Task Management

Tasks belong to boards and can have an owner and assigned users.

The system allows tasks to be:

* Created
* Edited
* Deleted
* Assigned to users
* Changed between different statuses
* Retrieved according to their board or owner

Administrators can manage any task.

Simple users can edit or delete a task only when they are its owner. Assigned users cannot modify or delete the task itself, but they can change its status.

### Task Assignment

Tasks can be assigned to users according to the user's permissions.

An administrator can assign users to any task.

A simple user can assign users to a task only when they are the owner of that task.

### Task Status

Tasks have a status that can be changed according to the user's permissions.

Administrators can change the status of any task.

Simple users can change the status only when they are either:

* The owner of the task.
* A user assigned to the task.

This allows assigned users to update the progress of their own work without giving them permission to modify the task itself.

# Access Control

The application implements access control at the controller level.

Each controller verifies whether the current user is logged in and, depending on the operation, whether the user has administrator privileges or owns the corresponding resource.

## UserController

### Index

* Available to all logged-in users.

### AddUser

* Only available to logged-in administrators.

### EditUser

* The user must be logged in.
* Administrators can edit any user.
* Simple users can edit only their own user.

### DeleteUser

* The user must be logged in.
* Administrators can delete any user.
* Simple users can delete only their own user.

## BoardController

### Index

* The user must be logged in.
* Administrators can view all boards.
* Administrators can view boards belonging to individual users.
* Simple users can view boards where they are the owner or where they have an assigned task or own a task.

### AddBoard

* Only available to logged-in administrators.

### EditBoard

* The user must be logged in.
* Administrators can edit any board.
* Simple users can edit only boards they own.

### DeleteBoard

* The user must be logged in.
* Administrators can delete any board.
* Simple users can delete only boards they own.

## TaskController

### Index

* The user must be logged in.
* Administrators can view all tasks.
* Administrators can view the tasks of any board individually.
* Simple users can view tasks from boards where they own the board, have a task assigned to them, or own a task.

### AddTask

* Only available to logged-in administrators.

### EditTask

* The user must be logged in.
* Administrators can edit any task.
* Simple users can edit only tasks they own.

### DeleteTask

* The user must be logged in.
* Administrators can delete any task.
* Simple users can delete only tasks they own.

### AssignTask

* The user must be logged in.
* Administrators can assign users to any task.
* Simple users can assign users only to tasks they own.

### ChangeTaskStatus

* The user must be logged in.
* Administrators can change the status of any task.
* Simple users can change the status of tasks they own or have assigned to them.

# Repositories

Repositories are responsible for handling database operations and keeping data access separated from the controllers.

## UserRepository

The `UserRepository` manages operations related to users.

Main operations include:

* `GetAll()` — Retrieves all users from the database.
* `GetById()` — Retrieves a user by ID.
* `Create()` — Creates a new user.
* `Update()` — Updates an existing user.
* `Remove()` — Removes a user.
* `UserExists()` — Checks whether a username already exists.

`UserExists()` is used as a validation before creating a new user, preventing duplicate usernames.

## BoardRepository

The `BoardRepository` manages boards and relationships between boards and users or tasks.

Main operations include:

* `GetAll()` — Retrieves all boards.
* `GetById()` — Retrieves a board by ID.
* `Create()` — Creates a new board.
* `Update()` — Updates an existing board.
* `Remove()` — Removes a board.
* `Disable()` — Disables a board when its owner is deleted.
* `GetByOwnerUser()` — Retrieves boards belonging to a specific user.
* `ChechAsignedTask()` — Checks whether a user has a relevant task in a board.
* `GetByUserAsignedTask()` — Retrieves boards where a user has an assigned task.
* `BoardExists()` — Checks whether a board with the same name already exists.

These methods are also used by the controllers to determine which boards a simple user is allowed to access.

## TaskRepository

The `TaskRepository` manages task operations and their relationships with boards and users.

Main operations include:

* `GetAll()` — Retrieves all tasks.
* `GetById()` — Retrieves a task by ID.
* `Create()` — Creates a new task.
* `Update()` — Updates an existing task.
* `Remove()` — Removes a task.
* `Assign()` — Assigns a user to a task.
* `ChangeStatus()` — Changes the status of a task.
* `Disable()` — Disables a task when its board is deleted or disabled.
* `GetByOwnerBoard()` — Retrieves tasks belonging to a specific board.
* `GetByOwnerUser()` — Retrieves tasks belonging to a specific user.
* `TaskExists()` — Checks whether a task with the same name already exists.

The `Disable()` operation allows tasks to maintain their relationship with a board when the board is only disabled. If the board is actually deleted, the task can instead become unassigned from a board.

# Data Flow

The application follows a defined flow between its different layers.

A typical operation follows this structure:

**View → Controller → Repository → Database**

The result then follows the reverse direction:

**Database → Repository → Controller → ViewModel → View**

For example, when displaying a user's information:

1. The View requests the corresponding ViewModel.
2. The Controller receives the request.
3. The Controller uses the `UserRepository`.
4. The Repository retrieves the required data from the database.
5. The Controller prepares the corresponding ViewModel.
6. The View receives the ViewModel and displays the information.

This structure prevents Views from directly accessing the database and keeps database operations inside the Repository layer.

# Relationships Between Entities

The main relationships of the system can be summarized as:

**User → Board → Task**

A user can own boards, and boards can contain multiple tasks.

Tasks can have an owner and can also be assigned to other users.

These relationships are important for access control because permissions are not determined only by the user's role. For simple users, access can also depend on whether they own a board, own a task, or have been assigned to a task.

# Project Architecture

The project uses a separation of responsibilities between its main components.

### Models

Models represent the entities and data structures used by the application.

Examples include users, boards, and tasks.

### ViewModels

ViewModels contain the information required by individual Views.

This allows the application to provide each View with only the data it needs instead of directly exposing the complete Model.

For example:

`@model Proyect.ViewModels.DeleteUserViewModel`

### Controllers

Controllers coordinate the application's operations.

They receive requests, verify authentication and permissions, use the appropriate repositories, prepare ViewModels, and return the corresponding Views.

### Repositories

Repositories isolate database access from the rest of the application.

Controllers do not directly perform the database operations. Instead, they use repository methods such as `GetById()`, `Create()`, `Update()`, and `Remove()`.

### Views

Views are responsible for presenting information to the user.

Each View uses the ViewModel corresponding to the information or operation it represents.

# Project Goal

This project was created to practice:

* C# and .NET development
* MVC-style application architecture
* Object-oriented programming
* Repository pattern
* Separation of responsibilities
* Models and ViewModels
* CRUD operations
* Authentication and login controls
* Role-based access control
* Resource ownership and permissions
* Relationships between users, boards, and tasks
* Database access and persistence
* Task assignment and status management
* Validation and data integrity
