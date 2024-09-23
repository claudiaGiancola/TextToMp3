using System.Speech.Synthesis;

string mp3FilePath = @"C:\Training\TextToMp3\exportTests\test.mp3";

using (SpeechSynthesizer synth = new SpeechSynthesizer())
using (MemoryStream wavStream = new MemoryStream())
{

    // Configure the audio output
    synth.SetOutputToWaveStream(wavStream);
    // Input the text to be turned into speech
    synth.Speak("This is sample output directly to an MP3 file from a stream.");

    // Reset the position of the stream to the beginning before conversion
    wavStream.Position = 0;

    // Convert WAV stream to MP3 and save it to file
    WavToMp3.ConvertWavStreamToMp3(wavStream, mp3FilePath);

}

Console.WriteLine("MP3 file generated.");



