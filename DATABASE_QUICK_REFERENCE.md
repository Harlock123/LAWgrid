# Database Quick Reference Card

Quick reference for all LAWgrid test databases. For detailed documentation, see [DOCKER_DATABASES_README.md](DOCKER_DATABASES_README.md).

## Quick Start

```bash
# Easy way - Use the management script
./manage-databases.sh start-all
./manage-databases.sh status
./manage-databases.sh init-db2  # Required for DB2 only

# Manual way - Start individual databases
docker-compose up -d                              # Oracle
cd docker-postgres && docker-compose up -d        # PostgreSQL
cd docker-mysql && docker-compose up -d           # MySQL
cd docker-db2 && docker-compose up -d             # DB2
```

## Connection Strings

### Oracle
```csharp
"User Id=testuser;Password=TestPassword123;Data Source=localhost:1521/XEPDB1;"
```

### PostgreSQL
```csharp
"Host=localhost;Port=5432;Database=lawgrid_test;Username=testuser;Password=TestPassword123;"
```

### MySQL
```csharp
"Server=localhost;Port=3306;Database=lawgrid_test;Uid=testuser;Pwd=TestPassword123;"
```

### DB2
```csharp
"Server=localhost:50000;Database=lawgrid;UID=db2inst1;PWD=TestPassword123;"
```

## LAWgrid Method Calls

### Oracle
```csharp
await grid.PopulateFromOracleQuery(connectionString, "SELECT * FROM EMPLOYEES");
await grid.PopulateFromOracleQueryAsync(connectionString, "SELECT * FROM EMPLOYEES");
grid.PopulateFromOracleQuerySync(connectionString, "SELECT * FROM EMPLOYEES");
```

### PostgreSQL
```csharp
await grid.PopulateFromPostgresQuery(connectionString, "SELECT * FROM employees");
await grid.PopulateFromPostgresQueryAsync(connectionString, "SELECT * FROM employees");
grid.PopulateFromPostgresQuerySync(connectionString, "SELECT * FROM employees");
```

### MySQL
```csharp
await grid.PopulateFromMySqlQuery(connectionString, "SELECT * FROM employees");
await grid.PopulateFromMySqlQueryAsync(connectionString, "SELECT * FROM employees");
grid.PopulateFromMySqlQuerySync(connectionString, "SELECT * FROM employees");
```

### DB2
```csharp
await grid.PopulateFromDb2Query(connectionString, "SELECT * FROM employees");
await grid.PopulateFromDb2QueryAsync(connectionString, "SELECT * FROM employees");
grid.PopulateFromDb2QuerySync(connectionString, "SELECT * FROM employees");
```

## Basic Test Queries

All databases have the same tables: `employees`, `departments`, `products`

### Simple Query
```sql
-- Oracle (uppercase)
SELECT * FROM EMPLOYEES ORDER BY EMPLOYEE_ID;

-- PostgreSQL, MySQL, DB2 (lowercase)
SELECT * FROM employees ORDER BY employee_id;
```

### Join Query
```sql
-- Oracle
SELECT e.FIRST_NAME, e.LAST_NAME, d.DEPARTMENT_NAME
FROM EMPLOYEES e
LEFT JOIN DEPARTMENTS d ON e.DEPARTMENT_ID = d.DEPARTMENT_ID;

-- PostgreSQL, MySQL, DB2
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id;
```

## Management Script Commands

```bash
# Start/Stop
./manage-databases.sh start-all
./manage-databases.sh stop-all
./manage-databases.sh restart-all

# Individual databases
./manage-databases.sh start postgres
./manage-databases.sh stop mysql
./manage-databases.sh logs oracle

# Status and maintenance
./manage-databases.sh status
./manage-databases.sh down-all      # Remove containers, keep data
./manage-databases.sh clean-all     # Remove everything (with confirmation)

# DB2 specific
./manage-databases.sh init-db2      # Required after first start
```

## Troubleshooting Commands

### Check Status
```bash
docker ps --filter "name=lawgrid"
./manage-databases.sh status
```

### View Logs
```bash
./manage-databases.sh logs oracle
./manage-databases.sh logs postgres
./manage-databases.sh logs mysql
./manage-databases.sh logs db2
```

### Connect via CLI
```bash
# Oracle
docker exec -it lawgrid-oracle-db sqlplus testuser/TestPassword123@XEPDB1

# PostgreSQL
docker exec -it lawgrid-postgres-db psql -U testuser -d lawgrid_test

# MySQL
docker exec -it lawgrid-mysql-db mysql -u testuser -pTestPassword123 lawgrid_test

# DB2
docker exec -it lawgrid-db2-db bash
su - db2inst1
db2 connect to lawgrid
```

### Reset Database
```bash
# Stop, remove all data, and restart
docker-compose down -v && docker-compose up -d  # Oracle
cd docker-postgres && docker-compose down -v && docker-compose up -d  # PostgreSQL
cd docker-mysql && docker-compose down -v && docker-compose up -d  # MySQL
cd docker-db2 && docker-compose down -v && docker-compose up -d  # DB2
```

## Port Reference

| Database | Port |
|----------|------|
| Oracle | 1521 |
| PostgreSQL | 5432 |
| MySQL | 3306 |
| DB2 | 50000 |

## Common Issues

### Port Already in Use
```bash
# Check what's using the port
lsof -i :1521   # Oracle
lsof -i :5432   # PostgreSQL
lsof -i :3306   # MySQL
lsof -i :50000  # DB2
```

### Container Won't Start
```bash
# View logs
./manage-databases.sh logs <database>

# Reset completely
./manage-databases.sh clean-all
./manage-databases.sh start-all
```

### DB2 "Table Not Found"
```bash
# Initialize schema (required for DB2)
./manage-databases.sh init-db2
```

### Connection Timeout
```bash
# Wait for healthy status
./manage-databases.sh status

# Check if container is running
docker ps | grep lawgrid
```

## Resource Usage

| Database | RAM | Disk | Startup |
|----------|-----|------|---------|
| Oracle | 2GB | 2.5GB | 2-3 min |
| PostgreSQL | 512MB | 80MB | 10-15 sec |
| MySQL | 1GB | 500MB | 30-45 sec |
| DB2 | 4GB | 5GB | 3-5 min |

**Running all together:** ~8GB RAM, ~10GB disk

## Documentation Links

- [Complete Overview](DOCKER_DATABASES_README.md)
- [Oracle Setup](DOCKER_ORACLE_SETUP.md)
- [PostgreSQL Setup](docker-postgres/POSTGRES_SETUP.md)
- [MySQL Setup](docker-mysql/MYSQL_SETUP.md)
- [DB2 Setup](docker-db2/DB2_SETUP.md)

## Test Query Files

Each database includes comprehensive test queries:
- `init-scripts/01-create-schema.sql` - Creates tables and sample data
- `init-scripts/test-queries.sql` - 15+ test queries

## Quick Testing Workflow

1. Start database: `./manage-databases.sh start postgres`
2. Wait for healthy: `./manage-databases.sh status`
3. Test connection from your C# code
4. Run test queries from `init-scripts/test-queries.sql`
5. Stop when done: `./manage-databases.sh stop postgres`
