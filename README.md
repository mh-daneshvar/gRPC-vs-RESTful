# 🚀 gRPC vs RESTful API Performance Benchmark

## 📌 Project Overview

This repository benchmarks the **performance** of gRPC and RESTful APIs using **small, medium, and large payloads**. It
includes:

✅ A **RESTful API** built with **Express.js**  
✅ A **gRPC API** using **Protocol Buffers** and **Node.js**  
✅ Automated benchmarking with **Autocannon** (REST) and **ghz** (gRPC)

## 🛠 Installation Guide

### 1️⃣ Clone the Repository

```sh
git clone git@github.com:mh-daneshvar/gRPC-vs-RESTful.git
cd grpc-vs-restful
```

### 2️⃣ Install Dependencies

Ensure **Node.js (v16+)** is installed, then run:

```sh
npm install
```

### 3️⃣ Install Benchmarking Tools

We use **Autocannon** for RESTful API benchmarking and **ghz** for gRPC.

#### 📌 Install Autocannon (for REST)

```sh
npm install -g autocannon
```

#### 📌 Install ghz (for gRPC)

- **macOS (Homebrew)**
  ```sh
  brew install ghz
  ```

- **Linux (Using curl)**
  ```sh
  curl -sSL https://github.com/bojand/ghz/releases/latest/download/ghz-linux-x86_64.tar.gz | tar xz
  sudo mv ghz /usr/local/bin/
  ```

- **Windows (Scoop)**
  ```sh
  scoop install ghz
  ```

---

## ▶️ Running the Servers

Before running the tests, start both servers.

### 1️⃣ Start the RESTful API

```sh
node restful/restServer.js
```

📍 Runs on: **http://localhost:8080**

### 2️⃣ Start the gRPC Server

```sh
node grpc/grpcServer.js
```

📍 Runs on: **localhost:5050**

---

## 📊 Running Performance Tests

Once both servers are running, execute the benchmark tests.

### 🟢 Run RESTful API Tests

```sh
bash tests/test_rest.sh
```

### 🔵 Run gRPC API Tests

```sh
bash tests/test_grpc.sh
```

---

## 📈 Expected Benchmark Output

The tests will measure **requests per second (RPS)**, **latency**, and **error rates**.

### 🔹 Example Output (REST)

```
🟢 RESTful API (Small Payload)
Stat     Avg       Stdev    Max
Req/s    12,345.6  ± 0.5%   12,500
Latency  10ms
...

🟡 RESTful API (Medium Payload)
...

🔴 RESTful API (Large Payload)
...
```

### 🔹 Example Output (gRPC)

```
🟢 gRPC API (Small Payload)
Summary:
  Count: 200,000
  Avg Latency: 2.5ms
  Requests/sec: 15,000
...

🟡 gRPC API (Medium Payload)
...

🔴 gRPC API (Large Payload)
...
```

---

## 📜 License

📄 **MIT License** – Feel free to use, modify, and contribute!

🔥 **Happy benchmarking!** 🚀