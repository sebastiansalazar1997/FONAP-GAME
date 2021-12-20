// Import Knex Module
const KNEX = require('../../database/database');

function addUser(user) {
    return KNEX('users').insert(user, 'id')
        .then(raw => {
            return JSON.stringify({
                data: raw,
                message: {
                    info: 'Usuario creado con éxito',
                    status: 200
                }
            });
        })
        .catch(error => {
            return JSON.stringify({
                data: error,
                message: {
                    info: 'No se pudo crear el usuario',
                    status: 400
                }
            });
        });
}

module.exports = {
    store: addUser 
}
