# 🚀 .NET gRPC vs RESTful API Performance Benchmark

## 📌 Project Overview

This repository contains a .NET implementation of the gRPC vs RESTful API performance benchmark. It includes:

✅ A **RESTful API** built with **ASP.NET Core Web API**  
✅ A **gRPC API** using **Protocol Buffers** and **ASP.NET Core gRPC**  
✅ Support for **small, medium, and large payloads**  
✅ Automated performance testing with **Spectre.Console** for beautiful output

## 🛠 Prerequisites

- .NET 7.0 SDK or later
- Visual Studio 2022 or later (recommended)

## 🚀 Getting Started

### 1️⃣ Clone the Repository

```sh
git clone <repository-url>
cd dotnet-benchmark
```

### 2️⃣ Build the Solution

```sh
dotnet build
```

### 3️⃣ Run the APIs

#### REST API
```sh
cd RestApi
dotnet run
```
📍 Runs on: **https://localhost:7001** and **http://localhost:5001**

#### gRPC API
```sh
cd GrpcApi
dotnet run
```
📍 Runs on: **https://localhost:7002** and **http://localhost:5002**

## 📊 Running Performance Tests

Once both APIs are running, you can run the performance tests:

```sh
cd PerformanceTests
dotnet run
```

The tests will:
- Send 200,000 requests for each payload size
- Use 100 concurrent requests
- Test both REST and gRPC endpoints
- Display beautiful console output with metrics

### 📈 Expected Benchmark Output

```
    ____  ____  ____  ____    ____  ____  ____  ____  ____  ____  ____  ____ 
   / ___\/ ___\/ ___\/ __ \  / ___\/ ___\/ ___\/ ___\/ ___\/ ___\/ ___\/ ___\
  / /_/ / /_/ / /_/ / /_/ / / /_/ / /_/ / /_/ / /_/ / /_/ / /_/ / /_/ / /_/ /
  \____/\____/\____/\____/  \____/\____/\____/\____/\____/\____/\____/\____/

Starting performance tests...

🟢 RESTful API Tests
🟡 Small Payload
┌──────────────┬──────────┐
│ Metric       │ Value    │
├──────────────┼──────────┤
│ Total Requests│ 200,000  │
│ Completed    │ 200,000  │
│ Errors       │ 0        │
│ Duration     │ 15.23s   │
│ Requests/sec │ 13,131.98│
└──────────────┴──────────┘

🟡 Medium Payload
...

🟡 Large Payload
...

🔵 gRPC API Tests
🟡 Small Payload
...

🟡 Medium Payload
...

🟡 Large Payload
...

✅ All tests completed!
```

## 📝 API Endpoints

### REST API

#### Small Payload
- **POST** `/test/small`
```json
{
    "name": "John Doe"
}
```

#### Medium Payload
- **POST** `/test/medium`
```json
{
    "name": "John Doe",
    "email": "john@example.com",
    "phone": "+1234567890"
}
```

#### Large Payload
- **POST** `/test/large`
```json
{
    "name": "John Doe",
    "age": 30,
    "email": "john@example.com",
    "address": "123 Main St",
    "city": "New York",
    "state": "NY",
    "country": "USA",
    "phone": "+1234567890",
    "salary": 75000.00,
    "isActive": true,
    "skills": ["C#", "ASP.NET", "gRPC"],
    "metadata": {
        "key1": "value1",
        "key2": "value2"
    },
    "company": "Tech Corp",
    "department": "Engineering"
}
```
### Output Example
```asm
 ⚡os ❯❯ dotnet run

Configuration:
REST API URL: http://localhost:5001
gRPC API URL: http://localhost:5002
Total Requests: 200,000
Concurrent Requests: 100

                                           ____    ____     ____                     ____    _____   ____    _____   
                                    __ _  |  _ \  |  _ \   / ___|   __   __  ___    |  _ \  | ____| / ___|  |_   _|  
                                   / _` | | |_) | | |_) | | |       \ \ / / / __|   | |_) | |  _|   \___ \    | |
                                  | (_| | |  _ <  |  __/  | |___     \ V /  \__ \   |  _ <  | |___   ___) |   | |
                                   \__, | |_| \_\ |_|      \____|     \_/   |___/   |_| \_\ |_____| |____/    |_|
                                   |___/
                                         ____                          _                                  _
                                        | __ )    ___   _ __     ___  | |__    _ __ ___     __ _   _ __  | | __
                                        |  _ \   / _ \ | '_ \   / __| | '_ \  | '_ ` _ \   / _` | | '__| | |/ /
                                        | |_) | |  __/ | | | | | (__  | | | | | | | | | | | (_| | | |    |   <
                                        |____/   \___| |_| |_|  \___| |_| |_| |_| |_| |_|  \__,_| |_|    |_|\_\


Starting performance tests...


🟢 RESTful API Tests

🟡 Small Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 9.53s    │
│ Requests/sec   │ 20984.28 │
│ Avg Latency    │ 3.08ms   │
│ Min Latency    │ 0.35ms   │
│ Max Latency    │ 107.13ms │
│ P95 Latency    │ 5.14ms   │
└────────────────┴──────────┘

🟡 Medium Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 8.98s    │
│ Requests/sec   │ 22259.37 │
│ Avg Latency    │ 2.78ms   │
│ Min Latency    │ 0.37ms   │
│ Max Latency    │ 55.33ms  │
│ P95 Latency    │ 4.32ms   │
└────────────────┴──────────┘

🟡 Large Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 9.77s    │
│ Requests/sec   │ 20474.85 │
│ Avg Latency    │ 3.18ms   │
│ Min Latency    │ 0.44ms   │
│ Max Latency    │ 99.46ms  │
│ P95 Latency    │ 4.73ms   │
└────────────────┴──────────┘

🔵 gRPC API Tests

🟡 Small Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 5.35s    │
│ Requests/sec   │ 37394.40 │
│ Avg Latency    │ 1.55ms   │
│ Min Latency    │ 0.42ms   │
│ Max Latency    │ 29.80ms  │
│ P95 Latency    │ 2.54ms   │
└────────────────┴──────────┘

🟡 Medium Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 4.92s    │
│ Requests/sec   │ 40657.81 │
│ Avg Latency    │ 1.35ms   │
│ Min Latency    │ 0.44ms   │
│ Max Latency    │ 23.90ms  │
│ P95 Latency    │ 2.01ms   │
└────────────────┴──────────┘

🟡 Large Payload

Processing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ 100%

┌────────────────┬──────────┐
│ Metric         │ Value    │
├────────────────┼──────────┤
│ Total Requests │ 200,000  │
│ Completed      │ 200,000  │
│ Errors         │ 0        │
│ Duration       │ 5.10s    │
│ Requests/sec   │ 39201.19 │
│ Avg Latency    │ 1.45ms   │
│ Min Latency    │ 0.44ms   │
│ Max Latency    │ 60.40ms  │
│ P95 Latency    │ 2.04ms   │
└────────────────┴──────────┘

✅ All tests completed!
```


### gRPC API

The gRPC service provides the same functionality as the REST API but using Protocol Buffers. The service definition can be found in `GrpcApi/Protos/test.proto`.

## 📜 License

📄 **MIT License** – Feel free to use, modify, and contribute!

🔥 **Happy benchmarking!** 🚀 