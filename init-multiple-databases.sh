#!/bin/bash

set -e
set -u

function create_user_and_db(){
	local db=$1
	local user=$2
	local pwd=$3
	echo " Creating user '$user' and db '$db'";
	psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "postgres"
	<<-EOSQL
		CREATE USER $user WITH PASSWORD '$pwd';
		CREATE DATABASE $db;
		GRANT ALL PRIVILEGES ON DATABASE $db to $user;
	EOSQL
}

if[ -n "${POSTGRES_MULTIPLE_DATABASES:-}" ]; then
	echo "Multiple database creation requested: $POSTGRES_MULTIPLE_DATABASES"
	for db_config in $(echo $POSTGRES_MULTIPLE_DATABASES | tr ',' ' '); do
		IFS=':' read -r db user password <<< "$db_config"
		create_user_and_db $db $user $pwd
	done
	echo "multiple dbs created"
fi