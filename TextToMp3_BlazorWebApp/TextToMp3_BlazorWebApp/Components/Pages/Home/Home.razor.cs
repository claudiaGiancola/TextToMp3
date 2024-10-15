using System.Speech.Synthesis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace TextToMp3_BlazorWebApp.Components.Pages.Home
{
    public partial class Home
    {

        [SupplyParameterFromForm]
        private MyFile? Model { get; set; }

        protected override void OnInitialized() => Model ??= new();

        public class MyFile
        {
            public IBrowserFile InputFile { get; set; } = null!;
            public string InputFileName { get; set; } = null!;
            public string OutputFile { get; set; } = "your audio";
            public string Voice { get; set; } = "Microsoft Elsa Desktop";
            public string Status { get; set; } = "Please select a file";

        }

        public void GetInputFileName(InputFileChangeEventArgs e)
        {
            Model!.InputFile = e.File;
            Model!.InputFileName = e.File.Name;
        }

        public void GetStatus() {
            Model!.Status = $"Your file {Model.InputFile.Name} will be downloaded as {Model.OutputFile}.mp3";
        }

        public async void DownloadAudio()
        {

            string outFileName = $"../../Exports/{Model!.OutputFile}.mp3";

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            using (MemoryStream wavStream = new MemoryStream())
            {

                // Configure the audio output
                synth.SetOutputToWaveStream(wavStream);

                // Input the text to be turned into speech
                synth.SelectVoice(Model!.Voice);

                string textToSpeak = await InputFile.GetInputFile(Model!.InputFile);

                synth.Speak(textToSpeak);

                // Reset the position of the stream to the beginning before conversion
                wavStream.Position = 0;

                // Convert WAV stream to MP3 and save it to file
                WavToMp3.ConvertWavStreamToMp3(wavStream, outFileName);

            }

            Console.WriteLine("MP3 file generated.");
        }
    }
}