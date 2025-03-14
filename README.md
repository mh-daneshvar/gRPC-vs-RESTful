# gRPC vs RESTful API Performance Benchmark

## 📌 Project Target

This repository is designed to compare the **performance** of gRPC and RESTful APIs using **small, medium, and large
payloads**. It includes:

- A **RESTful API** built with Express.js.
- A **gRPC API** built with Protocol Buffers and Node.js.
- Automated benchmarking tests using **Autocannon** (for REST) and **ghz** (for gRPC).

## 🚀 Installation Guide

To set up the project, follow these steps:

### 1️⃣ Clone the Repository

```sh
git clone <your-repository-url>
cd grpc-vs-restful
```

### 2️⃣ Install Dependencies

Make sure you have **Node.js** (version 16+) installed, then run:

```sh
npm install
```

### 3️⃣ Install Performance Testing Tools

We use **Autocannon** for RESTful API benchmarking and **ghz** for gRPC.

#### Install Autocannon (For REST)

```sh
npm install -g autocannon
```

#### Install ghz (For gRPC)

```sh
# macOS (Homebrew)
brew install ghz

# Linux (Using curl)
curl -sSL https://github.com/bojand/ghz/releases/latest/download/ghz-linux-x86_64.tar.gz | tar xz
sudo mv ghz /usr/local/bin/

# Windows (Scoop)
scoop install ghz
```

## ▶️ Running the Servers

Before running tests, start both servers.

### 1️⃣ Start the RESTful API

```sh
node restful/restServer.js
```

The RESTful API will run on **http://localhost:8080**

### 2️⃣ Start the gRPC Server

```sh
node grpc/grpcServer.js
```

The gRPC server will run on **localhost:5050**

## 📊 Running Performance Tests

Once the servers are running, execute the benchmark tests.

### 1️⃣ Run RESTful API Tests

```sh
bash tests/test_rest.sh
```

### 2️⃣ Run gRPC API Tests

```sh
bash tests/test_grpc.sh
```

## 📈 Expected Output

The test scripts will generate benchmark results showing **requests per second**, **latency**, and **error rates** for
each API.

### Example Output (REST)

```
🟢 Testing RESTful API (Small Payload)
Stat    Avg      Stdev    Max
Req/s   12345.6  ± 0.5%   12500
Latency 10ms
...

🟡 Testing RESTful API (Medium Payload)
...

🔴 Testing RESTful API (Large Payload)
...
```

### Example Output (gRPC)

```
🟢 Testing gRPC API (Small Payload)
Summary:
  Count: 200000
  Average Latency: 2.5ms
  Requests/sec: 15000
...

🟡 Testing gRPC API (Medium Payload)
...

🔴 Testing gRPC API (Large Payload)
...
```

## 📚 License

MIT License - Feel free to use and modify.

---

🔥 **Happy benchmarking!** Let me know if you need any changes. 🚀