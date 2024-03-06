#!/bin/bash

docker build -t testapi .

docker run -d -p 8080:80 --name odoo-proxy-instance testapi