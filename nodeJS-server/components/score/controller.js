// Import Register Store
const STORE = require('./store');

function getHighScore() {
    return new Promise((resolve, reject) => {
        resolve(STORE.index());
    });
}

function updateScore(body) {
    return new Promise((resolve, reject) => {

        if (!body) {
            return reject(JSON.stringify({
                data: null,
                message: {
                    info: 'Datos inválidos',
                    status: 400
                }
            }));
        }

        resolve(STORE.update(body.id, parseInt(body.score)));
    });
}

module.exports = {
    getHighScore,
    updateScore
}
