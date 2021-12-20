// Import Knex Module
const KNEX = require('../../database/database');

function storeQuestions(questions) {
    return KNEX('questions')
        .insert(questions)
        .then(raw => {
            return JSON.stringify({
                data: raw,
                message: {
                    info: 'Preguntas almacenadas con éxito',
                    status: 200
                }
            });
        })
        .catch(error => {
            return JSON.stringify({
                data: error,
                message: {
                    info: 'No se pudo almacenar las preguntas',
                    status: 400
                }
            });
        });
}

module.exports = {
    store: storeQuestions
}
