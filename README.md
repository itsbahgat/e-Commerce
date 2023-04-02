1. Create the entities/models of each Area
    
    ```
    add-migration "initial" -context databaseContext 
    ```
    ```
    Update-Database -context databaseContext
    ```
2. Create your services interfaces and class
3. Create read/write controllers

- Make sure to run 
    ``` 
    updata-database -context databaseContext
    ```
- Note: The startup front is the product and you can change ir from *program.cs*