 var Cleverbot = require('cleverbot-node');
    cleverbot = new Cleverbot;
    cleverbot.configure({botapi: "CC8p7GuDm6who_Etq64db0qguSw"});
    cleverbot.write("Just a small town girl", function (response) {
       console.log(response.output);
    });