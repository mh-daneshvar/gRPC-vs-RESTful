const express = require('express');
const app = express();

app.use(express.json());

// 🟢 Small Payload Route
app.post('/small', (req, res) => {
    res.json({ message: `Hello, ${req.body.name}!` });
});

// 🟡 Medium Payload Route
app.post('/medium', (req, res) => {
    res.json({
        message: `Hello, ${req.body.name}!`,
        email: req.body.email,
        phone: req.body.phone
    });
});

// 🔴 Large Payload Route
app.post('/large', (req, res) => {
    res.json({
        message: `Hello, ${req.body.name}!`,
        age: req.body.age,
        email: req.body.email,
        address: req.body.address,
        city: req.body.city,
        state: req.body.state,
        country: req.body.country,
        phone: req.body.phone,
        salary: req.body.salary,
        isActive: req.body.isActive,
        skills: req.body.skills,
        metadata: req.body.metadata,
        company: req.body.company,
        department: req.body.department
    });
});

app.listen(8080, () => {
    console.log('✅ RESTful API running on http://localhost:8080');
});
