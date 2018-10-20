// using System;
// using System.IO;
// using Google.Cloud.TextToSpeech.V1;

// public class QuickStart
// {
//     public static void Main(string[] args)
//     {
//         // Instantiate a client
//         TextToSpeechClient client = TextToSpeechClient.Create();

//         // Set the text input to be synthesized.
//         SynthesisInput input = new SynthesisInput
//         {
//         		///clever bot return stuff
//             Text = "Hello, World!"
//         };

//         // Build the voice request, select the language code ("en-US"),
//         // and the SSML voice gender ("neutral").
//         VoiceSelectionParams voice = new VoiceSelectionParams
//         {
//             LanguageCode = "en-US",
//             SsmlGender = SsmlVoiceGender.Neutral
//         };

//         // Select the type of audio file you want returned.
//         AudioConfig config = new AudioConfig
//         {
//             AudioEncoding = AudioEncoding.Mp3
//         };

//         // Perform the Text-to-Speech request, passing the text input
//         // with the selected voice parameters and audio file type
//         var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
//         {
//             Input = input,
//             Voice = voice,
//             AudioConfig = config
//         });

//         // Write the binary AudioContent of the response to an MP3 file.
//         using (Stream output = File.Create("sample.mp3"))
//         {
//             response.AudioContent.WriteTo(output);
//             Debug.Log("Audio content written to file 'sample.mp3'");
//         }
//     }
// }