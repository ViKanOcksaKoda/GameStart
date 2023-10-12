# GameStart
Backend and API for a game WebShop made in ASP.NET 6.0
# Step guide to run the project
## Update Database
-Open Package Manager Console <br />
-Position it into GameStart.Infrastructure <br />
-Enter: Update-Database <br />
<br/>
If you need to reset migration from scratch do the following: <br />
-Right-Click and remove Migration whole folder in Infrastructure Project <br />
-Open SQL Server Explorer <br />
-Remove GameStart Database <br />
-Open Package Manager Console <br />
-Position it into GameStart.Infrastructure <br />
-Enter: Add-Migration InitialCreate <br />
-Enter: Update-Database <br />
## Run the Project
-Have it running in the background then run the GameStartUI to use the whole application
