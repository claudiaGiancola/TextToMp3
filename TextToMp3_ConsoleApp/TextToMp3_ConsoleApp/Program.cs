using System.Speech.Synthesis;

string mp3FilePath = @"C:\Training\TextToMp3\TextToMp3_ConsoleApp\exportTests\MartelloDelSoleTest.mp3";

using (SpeechSynthesizer synth = new SpeechSynthesizer())
using (MemoryStream wavStream = new MemoryStream())
{

    // Configure the audio output
    synth.SetOutputToWaveStream(wavStream);
    // Input the text to be turned into speech
    synth.SelectVoice("Microsoft Elsa Desktop");
    synth.Speak(InputFile.GetInputFile());

    // Reset the position of the stream to the beginning before conversion
    wavStream.Position = 0;

    // Convert WAV stream to MP3 and save it to file
    WavToMp3.ConvertWavStreamToMp3(wavStream, mp3FilePath);

}

Console.WriteLine("MP3 file generated.");



