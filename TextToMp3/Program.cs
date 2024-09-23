using System.Speech.Synthesis;

// Initialize a new instance of the SpeechSynthesizer.
SpeechSynthesizer synth = new SpeechSynthesizer();

// Configure the audio output.
synth.SetOutputToDefaultAudioDevice();

// Speak a string, synchronously
synth.Speak("Hello World!");

// Speak a string asynchronously
var prompt = synth.SpeakAsync("Goodnight Moon!");

while (!prompt.IsCompleted)
{
    Console.WriteLine("speaking...");
    Thread.Sleep(500);
}