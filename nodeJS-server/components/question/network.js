// Import App Modules
const EXPRESS = require('express');

// Import Register Controller
const CONTROLLER = require('./controller');

// Inicialize App Router
const ROUTER = EXPRESS.Router();

// Routes for add the questions
ROUTER.post('/', function(request, response) {
    CONTROLLER.storeQuestions(request.body)
        .then(message => {
            response.send(message);
        })
        .catch(error => {
            response.send(error);
        });
});

// Export the routes for this Component
module.exports = ROUTER;
