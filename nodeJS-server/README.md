NODE JS Server
=====================

Instrucciones antes de levantar el servidor:
-----------------------------------------------

**NOTA: Es necesario seguir estas instrucciones para que puedas utilizar el servidor**

1. En la carpeta "nodeJS-server" crear un archivo llamado "config.js", dentro de este archivo debe contener
    el siguiente código (sin los backticks **```**): 

```

const CONFIG = {
    port: 3000,
    origin: 'http://localhost:4200',
    db: {
        host: 'localhost',
        user: 'postgres',
        password: 'tu-contraseña',
        database: 'FONAP_game'
    }
}

module.exports = CONFIG;

```

2. Una vez que tengas este archivo creado y dentro del mismo, hayas copiado el código anterior; ahora debes
    cambiar donde dice 'tu-contraseña' por la contraseña que le hayas puesto a tu base de datos en Postgres 
    (la contraseña debe ir entre comillas simples **''**); todo este código es utilizado por la librería
    KnexJS para conectarse a la base de datos, por lo que es necesario este paso y configurar la contraseña.

3. Dentro de la carpeta "database" hay un archivo llamado "database.sql", dentro del mismo hay el código
    SQL para crear y borrar la base de datos y las tablas.

4. Copia y ejecuta el código SQL para crear la base de datos en Postgres; después copia y ejecuta el código
    SQL para crear las tablas.

5. Para levantar el servidor con NodeJS, abre la consola y ejecuta el código (sin los backticks **```**):

```

node index

```

6. Si todo sale bien se debería levantar el servidor y mostrar en consola el siguiente mensaje:
    **"La aplicación está ejecutandose en http://localhost:3000"**
    