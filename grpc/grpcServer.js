const grpc = require('@grpc/grpc-js');
const path = require('path');
const protoLoader = require('@grpc/proto-loader');

const protoPath = path.join(__dirname, 'service.proto');
const packageDefinition = protoLoader.loadSync(protoPath, {
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true
});
const testProto = grpc.loadPackageDefinition(packageDefinition).test;

function getSmall(call, callback) {
    callback(null, { message: `Hello, ${call.request.name}!` });
}

function getMedium(call, callback) {
    callback(null, {
        message: `Hello, ${call.request.name}!`,
        email: call.request.email,
        phone: call.request.phone
    });
}

function getLarge(call, callback) {
    callback(null, call.request);
}

const server = new grpc.Server();
server.addService(testProto.TestService.service, {
    GetSmall: getSmall,
    GetMedium: getMedium,
    GetLarge: getLarge
});

server.bindAsync('0.0.0.0:5050', grpc.ServerCredentials.createInsecure(), () => {
    console.log('✅ gRPC Server running on 0.0.0.0:5050');
    server.start();
});
