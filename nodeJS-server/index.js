// Import App Modules
const EXPRESS = require('express');
const BODYPARSER = require('body-parser');

// Import Modules
const ROUTER = require('./routes/routes');
const CONFIG = require('./config');

// Initialize the Express' app
var app = EXPRESS();

// Setting the Express' app
app.use(BODYPARSER.urlencoded());

app.listen(CONFIG.port);
app.use((request, response, next) => {
    response.header('Access-Control-Allow-Origin', CONFIG.origin);
    response.header('Access-Control-Allow-Headers', 'Authorization, X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Allow-Request-Method');
    response.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, DELETE');
    response.header('Allow', 'GET, POST, OPTIONS, PUT, DELETE');
    next();
});

ROUTER(app);

console.log(`La aplicación está ejecutandose en http://localhost:${CONFIG.port}`);
