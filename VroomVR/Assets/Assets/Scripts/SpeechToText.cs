// using Google.Cloud.Speech.V1;
// using System;

// namespace GoogleCloudSamples
// {
//     public class SpeechToText
//     {
//         public static void Main(string[] args)
//         {
//             var speech = SpeechClient.Create();
//             var response = speech.Recognize(new RecognitionConfig()
//             {
//                 Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
//                 SampleRateHertz = 16000,
//                 LanguageCode = "en",
//             }, RecognitionAudio.FromFile("audio.raw"));
//             foreach (var result in response.Results)
//             {
//                 foreach (var alternative in result.Alternatives)
//                 {
//                     Console.WriteLine(alternative.Transcript);
//                 }
//             }
//         }
//     }
// }