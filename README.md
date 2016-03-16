# OrdersSystem
System for monitoring incoming and outgoing orders 

## Functionality
Registered users can have three roles admin, boss or worker. Admin can change, add or delete everything like incoming orders, outgoing orders, repair orders, add role to user, remove role from user or delete user. Boss can add or edit orders. Worker can be assigned to an order and can only change order status.

## Areas
Public area(home page) where latest incoming orders can be seen.
Private area for users with role(boss, worker or admin).
Admin area for user with admin role. Here admin can make CRUD operations.

##Architecture

### OrdersSystem.Web
This is the startup project. Here are all the controllers and views. Also the areas are placed here.

### OrdersSystem.Data
Here is configured the DbContext, the repository pattern and the unit-of-works pattern.

### OrdersSystem.Services
Here is all the logic that the controllers use. Within the constructors of the services is injected the unit of works database class and in the controlellers are injected the different services they use. Ninject has been used for the injection. And Automapper for mapping the db models with the view models.

### OrdersSystem.Models
Here are all the database models.

### OrdersSystem.Common
Here are defined all the global constants like error and success messages.

### OrdersSystem.Web.Controllers.Test
Here are all test for controllers.

### OrdersSystem.Web.Routes.Test
Here are all test for routes.


