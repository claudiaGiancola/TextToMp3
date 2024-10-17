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
            public bool IsLoading { get; set; } = false;
        }

        public void GetInputFileName(InputFileChangeEventArgs e)
        {
            Model!.InputFile = e.File;
            Model!.InputFileName = e.File.Name;
        }

        public async void DownloadAudio()
        {
            Model!.IsLoading = true;

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
            
            Model!.IsLoading = false;

            StateHasChanged();
        }
    }
}