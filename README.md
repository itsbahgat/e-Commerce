# Clothing E-Commerce Web App 

This is a web application for a clothing e-commerce site. It is built using ASP.NET Core MVC and includes several features such as user authentication, email confirmation, external login with Google and Facebook, customer and product management, filtering products by category and price range, adding products to favorites, and a cart with Stripe payment and Cloudinary photo services. It also includes an admin dashboard with CRUD operations for managing customers and products.

## Demo


https://user-images.githubusercontent.com/62761039/231823730-fa846b47-df36-45c7-b027-c8788762b525.mp4



## Technology Stack

-   ASP.NET Core MVC
-   Entity Framework Core
-   Bootstrap for layout and views
-   Stripe payment service
-   Cloudinary photo service


## Installation:

1.  Clone the repository to your local machine.
2.  Open the project in Visual Studio.
3.  Install any necessary packages using NuGet.
4.  Make sure to update the server name in *appSettings* file.
5.  Add user secrets, right click on the project inside visual studio and add the secret keys. 
  - You can contact one of the contrubuters to get the secret keys.
6.  In the *package manager console*, write 
  ```
  update-database -context IdentityContext
  ```
7.  Run the application using IIS Express or your preferred web server.
