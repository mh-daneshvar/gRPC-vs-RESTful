#!/bin/bash

echo "🟢 Testing gRPC API (Small Payload)"
ghz --insecure --proto grpc/service.proto --call test.TestService.GetSmall -d '{"name":"John"}' --concurrency=100 --duration=20s localhost:5050

echo "🟡 Testing gRPC API (Medium Payload)"
ghz --insecure --proto grpc/service.proto --call test.TestService.GetMedium -d '{
  "name": "John Doe",
  "email": "johndoe@example.com",
  "phone": "+1-555-1234"
}' --concurrency=100 --duration=20s localhost:5050

echo "🔴 Testing gRPC API (Large Payload)"
ghz --insecure --proto grpc/service.proto --call test.TestService.GetLarge -d '{
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
}' --concurrency=100 --duration=20s localhost:5050
