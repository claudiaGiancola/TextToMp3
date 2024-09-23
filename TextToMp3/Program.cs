using System;
using System.IO;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

// Initialize a new instance of the SpeechSynthesizer.
using (SpeechSynthesizer synth = new SpeechSynthesizer())
{

    // Configure the audio output.
    synth.SetOutputToWaveFile(@"C:\Training\TextToMp3\exportTests\test.wav",
    new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));

    // Build a prompt.
    PromptBuilder builder = new PromptBuilder();
    builder.AppendText("This is sample output to a WAVE file.");

    // Speak the prompt.
    synth.Speak(builder);

}

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();



