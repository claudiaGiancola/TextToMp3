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
            public string InputFile { get; set; } = null!;
            public string OutputFile { get; set; } = "your audio";
            public string Voice { get; set; } = "Microsoft Elsa Desktop";
            public string Status { get; set; } = "";

        }

        public void GetInputFileName(InputFileChangeEventArgs e)
        {
            Model!.InputFile = e.File.Name;
        }

        public void GetStatus() {
            Model!.Status = $"Your file {Model!.InputFile} will be downloaded as {@Model.OutputFile}.mp3";
        }

        public void DownloadAudio()
        {

            string mp3FilePath = @"C:\Users\ClaGia\Downloads\" + $"{Model!.OutputFile}.mp3";

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            using (MemoryStream wavStream = new MemoryStream())
            {

                // Configure the audio output
                synth.SetOutputToWaveStream(wavStream);

                // Input the text to be turned into speech
                synth.SelectVoice(Model!.Voice);

                synth.Speak(InputFile.GetInputFile(Model!.InputFile));

                // Reset the position of the stream to the beginning before conversion
                wavStream.Position = 0;

                // Convert WAV stream to MP3 and save it to file
                WavToMp3.ConvertWavStreamToMp3(wavStream, mp3FilePath);

            }

            Console.WriteLine("MP3 file generated.");
        }
    }
}