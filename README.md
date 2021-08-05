# SeedtagRadar

### 
The project was documented using `Swagger`, to use it you need to do the next, assuming that you are in the repository root:
1. Run `cd SeedtagRadar.Api/` command
2. Run `dotnet run` command
3. Navigate to `http://localhost:8888/radar/swagger/index.html`

### 
The project has an empty layer called `SeedtagRadar.Infrastructure`, which sense is to make the comunication with external sources like APIs, data base, etc.

### 
The project has unit tests, to run them, you need to run the following commands, assuming that you are in the repository root:

```
cd SeedtagRadar.Tests/

dotnet test
```