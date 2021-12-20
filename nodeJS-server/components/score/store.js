// Import Knex Module
const KNEX = require('../../database/database');

function getHighScore() {
    return KNEX.from('users').orderBy('score', 'desc').limit(10);
}

function updateScore(id, score) {
    return KNEX('users')
        .where('id', id)
        .andWhere('score', '<', score)
        .update({score: score}, 'score')
        .then(raw => {
            return JSON.stringify({
                data: raw,
                message: {
                    info: 'Score actualizado con éxito',
                    status: 200
                }
            });
        })
        .catch(error => {
            return JSON.stringify({
                data: error,
                message: {
                    info: 'No se pudo actualizar el score',
                    status: 400
                }
            });
        });
}

module.exports = {
    index: getHighScore,
    update: updateScore
}
