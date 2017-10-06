docker-compose down
docker-compose rm --force
docker rmi demo-app-web demo-app-db-migrator
rd /s ./artifacts/
rd /s ./packages/
rd /s ./obj/
