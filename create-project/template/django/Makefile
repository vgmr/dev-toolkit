ROOT:=$(dir $(realpath $(firstword $(MAKEFILE_LIST))))

RED="\033[1;31m"
GREEN="\033[1;32m"
YELLOW="\033[1;33m"
BLUE="\033[1;34m"
NOCOLOR="\033[0m\033[K"

.PHONY: help
.DEFAULT_GOAL := help

MANAGE=python manage.py

##
## Main targets
##
help: ## display enhanced help message
	@grep -E '(^[a-zA-Z_-]+:.*?##.*$$)|(^##)' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[32m%-15s\033[0m %s\n", $$1, $$2}' | sed -e 's/\[32m##/[33m/'

run-server: ## run django server
	${MANAGE} runserver

##
## DB targets
##

showmigrations: ## SHOW MIGRATIONS  
	${MANAGE} showmigrations

migrate: ## APPLY MIGRATIONS  
	${MANAGE} migrate

dbshell: ## DB SHELL
	${MANAGE} dbshell

createsuperuser: ## CREATE SUPER USER
	${MANAGE} createsuperuser

makemigrations: ## MAKE MIGRATIONS  
	${MANAGE} makemigrations
   