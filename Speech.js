// Imports the Google Cloud client library
const speech = require('@google-cloud/speech');
const textToSpeech = require('@google-cloud/text-to-speech');
const fs = require('fs');
const cleverbot = require('cleverbot.io');
bot = new cleverbot("6MmbsFvWFWtcaeob", "c4PdYQ20pjQ0mdEw0IcFYOAu9Pvs1OBY");
bot.setNick("VRTalk");
require('dotenv').config();
//elp
if(!fs.existsSync('./.env')) {
	throw new Error('.env file is missing');
}
// Creates a client
const client = new speech.SpeechClient();
const textclient = new textToSpeech.TextToSpeechClient();

// The name of the audio file to transcribe
const fileName = './VroomVR/Assets/audio.wav';


//const fs = require('fs');
//require('log-timestamp');

const buttonPressesLogFile = './VroomVR/Assets/audio.wav';

console.log(`Watching for file changes on ${buttonPressesLogFile}`);

fs.watch(buttonPressesLogFile, (event, filename) => {
  if (filename) {
    // Reads a local audio file and converts it to base64
const file = fs.readFileSync(fileName);
const audioBytes = file.toString('base64');

// The audio file's encoding, sample rate in hertz, and BCP-47 language code
const audio = {
  content: audioBytes,
};
const config = {
  encoding: 'LINEAR16',
  sampleRateHertz: 44100,
  languageCode: 'en-US',
};
const request = {
  audio: audio,
  config: config,
};
// Detects speech in the audio file
client
  .recognize(request)
  .then(data => {
    const response = data[0];
    const transcription = response.results
      .map(result => result.alternatives[0].transcript)
      .join('\n');
    console.log(`Transcription: ${transcription}`);
	fs.writeFile('text.txt', transcription, err => {
			if (err) {console.log("error");}
			else {console.log("worked");}
		});
		

		const textRequest = {input: {text: transcription},
		  // Select the language and SSML Voice Gender (optional)
		  voice: {languageCode: 'en-US', ssmlGender: 'NEUTRAL'},
		  // Select the type of audio encoding
		  audioConfig: {audioEncoding: 'MP3'},};
		  textclient.synthesizeSpeech(textRequest, (err, response) => {
		  	if (err) {
		  		console.error('ERROR:', err);
		  		return;
		  	}
		  	fs.writeFile('./VroomVR/Assets/output.mp3', response.audioContent, 'binary', err => {
	    if (err) {
	      console.error('ERROR:', err);
	      return;
	    }
	    console.log('Audio content written to file: output.mp3');
	  });
		  })
	  })
	  .catch(err => {
	    console.error('ERROR:', err);
	  });
	  }
});

bot.create(function (err, session) {
		console.log("\ntesting\n");
	  // session is your session name, it will either be as you set it previously, or cleverbot.io will generate one for you
	  bot.ask("Just a small town girl", function (err, response) {
		  console.log(response);
		});
	  // Woo, you initialized cleverbot.io.  Insert further code here
	});
