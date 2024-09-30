using System.Speech.Synthesis;
using Aspose.Words;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using NAudio.Lame;
using NAudio.Wave;

namespace TextToMp3_BlazorWebApp.Components.Pages.Home
{
    public partial class Home
    {

        [SupplyParameterFromForm]
        private MyFile? Model { get; set; }

        protected override void OnInitialized() => Model ??= new();

        public class MyFile
        {
            public string? InputFile { get; set; } = null!;

            public string? OutputFile { get; set; } = "your audio";

        }

        public void GetInputFileName(InputFileChangeEventArgs e)
        {
            Model!.InputFile = e.File.Name;
        }

        public string GetInputFile()
        {
            var doc = new Document(@$"C:\Users\ClaGia\Downloads\{Model!.InputFile}");

            string text = doc.ToString(SaveFormat.Text).Trim().Replace("Created with an evaluation copy of Aspose.Words. To remove all limitations, you can use Free Temporary License https://products.aspose.com/words/temporary-license/", "").Replace("Evaluation Only. Created with Aspose.Words. Copyright 2003-2024 Aspose Pty Ltd.", "");

            return text;
        }

        public void ConvertWavStreamToMp3(Stream wavStream, string mp3FilePath)
        {
            using (var reader = new WaveFileReader(wavStream)) // Read from the wave stream
            using (var writer = new LameMP3FileWriter(mp3FilePath, reader.WaveFormat, LAMEPreset.VBR_90))
            {
                reader.CopyTo(writer);  // Copy WAV stream data into MP3 file
            }
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
                synth.SelectVoice("Microsoft Elsa Desktop");
                synth.Speak(GetInputFile());

                // Reset the position of the stream to the beginning before conversion
                wavStream.Position = 0;

                // Convert WAV stream to MP3 and save it to file
                ConvertWavStreamToMp3(wavStream, mp3FilePath);

            }

            Console.WriteLine("MP3 file generated.");
        }
    }
}