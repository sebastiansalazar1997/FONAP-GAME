const CONFIG = require('../config');

const KNEX = require('knex')({
    client: 'pg',
    connection: {
      host : CONFIG.db.host,
      user : CONFIG.db.user,
      password : CONFIG.db.password,
      database : CONFIG.db.database
    }
});

module.exports = KNEX;