// Import Register Store
const STORE = require('./store');

function addUser(body) {
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

        const USER = {
            name: body.name,
            age: parseInt(body.age),
            community: body.community || null,
            is_affiliate: parseInt(body.is_affiliate) || false
        }

        resolve(STORE.store(USER));
    });
}

module.exports = {
    addUser
}
