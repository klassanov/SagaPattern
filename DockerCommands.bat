# latest RabbitMQ 4.0.x
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4.0-management

# postgres
docker run --name postgres-container -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e -p 5432:5432 postgres

# postgres management
docker run --name pgadmin-container -e PGADMIN_DEFAULT_EMAIL=admin@admin.com -e PGADMIN_DEFAULT_PASSWORD=admin -p 8088:80 dpage/pgadmin4

# Connect pgAdmin or Adminer to PostgreSQL
# Open the management UI in your browser (http://localhost:8088).
# Add a new connection to the PostgreSQL database:
# Host: host.docker.internal (or localhost if not on Docker Desktop)
# Port: 5432
# Username: admin (from POSTGRES_USER)
# Password: admin (from POSTGRES_PASSWORD)
# Database: mydatabase



