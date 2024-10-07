// Function to convert WAV stream to MP3
using NAudio.Lame;
using NAudio.Wave;

class WavToMp3
{
    public static void ConvertWavStreamToMp3(Stream wavStream, string outFileName)
    {
        using (var reader = new WaveFileReader(wavStream)) // Read from the wave stream
        using (var writer = new LameMP3FileWriter(outFileName, reader.WaveFormat, LAMEPreset.VBR_90))
        {
            reader.CopyTo(writer);  // Copy WAV stream data into MP3 file
        }
    }
}