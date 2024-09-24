# Intro

This is a console application.
Input your text file to convert and download it as mp3.

Please always verify you own the rights of the text file or the file's author gave you the permission to convert it before using this application.

Run the program with `dotnet run`


### Dependencies

Run `dotnet add package System.Speech --version 8.0.0`
This provides APIs for speech recognition and synthesis built on the Microsoft Speech API in Windows. It's not supported on other platforms.
This package is provided primarily for compatibility with code being ported from .NET Framework and is not accepting new features.

Run `dotnet add package Aspose.Words`
Run `dotnet add package NAudio --version 2.2.1`
Run `dotnet add package NAudio.Lame --version 2.1.0`


### Voices

List the available installed voices adding in Program.cs the line `Voices.GetVoices();`.
Use your preferred voice updating this line  `synth.SelectVoice("<your preferred voice name>");`.

You can download additional voices (if available) in your Windows Language Settings > Preferred Languages.