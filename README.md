# Web Ecommerce
Using ASP.NET MVC5 Code First
How to use :
1. Clone repository
2. Open with Visual Studio and build solution
3. In file webconfig, edit connectionString to your database
4. Choose Tools->NuGet Package Mangager->Package Manager Console
5. Run migration with follow command bellow:
    * update-database -v
6. Press F5 to run application.
* Note: You can delete folder Migrations in class library Domain and run commmand :
  * enable-migrations
  * add-migration initDB
  * update-database
