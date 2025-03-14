#!/bin/bash

echo "🟢 Testing RESTful API (Small Payload)"
autocannon -c 100 -d 20 -p 10 -m POST -b '{"name":"John"}' http://localhost:8080/small

echo "🟡 Testing RESTful API (Medium Payload)"
autocannon -c 100 -d 20 -p 10 -m POST -b '{
  "name": "John Doe",
  "email": "johndoe@example.com",
  "phone": "+1-555-1234"
}' http://localhost:8080/medium

echo "🔴 Testing RESTful API (Large Payload)"
autocannon -c 100 -d 20 -p 10 -m POST -b '{
  "name": "John Doe",
  "age": 35,
  "email": "johndoe@example.com",
  "address": "123 Street, Apt 4",
  "city": "New York",
  "state": "NY",
  "country": "USA",
  "phone": "+1-555-1234",
  "salary": 75000.50,
  "isActive": true,
  "skills": ["JavaScript", "Node.js", "gRPC"],
  "metadata": {"role": "Developer", "level": "Senior"},
  "company": "TechCorp",
  "department": "Engineering"
}' http://localhost:8080/large
