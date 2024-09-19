## Getting started 

1. ### Clone repository:

   ```bash
   git clone https://github.com/M0BIN-V/Shop
   ```

2. ### Change directory to repository

   ```bash
   cd Shop
   ```

3. ### To set up the database and project, execute the **Run.ps1** file with the following parameters:

   ```ps1
   .\Run.ps1 --init -key "<ENCRYPTION KEY>" -connection "<SQLSERVER CONNECTION STRING>"
   ```
   **ENCRYPTION KEY:** This is the key used to encrypt the JSON Web Token (JWT).
   
   like:
   ```
    iusidaf658FKASDds_DasA689MSDfafgissdaf002445_iixdafsdfworesdf_324wdskfsdmqpkjjds
   ```

   **SQLSERVER CONNECTION STRING:** This is a string used to establish a connection to an SQL Server database.

   like :
   ```
    Data Source =.\DB_Address ;Initial Catalog= DB_Name ;Integrated Security=True;Trust Server Certificate=True;
   ```
   
4. ### Run web api

   ```ps1
   .\Run.ps1
   ```
