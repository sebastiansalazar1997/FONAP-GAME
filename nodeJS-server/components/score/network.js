// Import App Modules
const EXPRESS = require('express');

// Import Register Controller
const CONTROLLER = require('./controller');

// Inicialize App Router
const ROUTER = EXPRESS.Router();

// Routes for get HighScores
ROUTER.get('/', function(request, response) {
    CONTROLLER.getHighScore()
        .then(message => {
            response.send(message);
        })
        .catch(error => {
            response.send(error);
        });
});

// Routes for update the scores
ROUTER.post('/', function(request, response) {
    CONTROLLER.updateScore(request.body)
        .then(message => {
            response.send(message);
        })
        .catch(error => {
            response.send(error);
        });
});

// Export the routes for this Component
module.exports = ROUTER;
