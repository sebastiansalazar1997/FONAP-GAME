// Import Register Store
const STORE = require('./store');

function storeQuestions(body) {
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

        const QUESTIONS = [
            {user_id: parseInt(body.id), question: body.q1},
            {user_id: parseInt(body.id), question: body.q2},
            {user_id: parseInt(body.id), question: body.q3}
        ];
        
        resolve(STORE.store(QUESTIONS));
    });
}

module.exports = {
    storeQuestions
}
