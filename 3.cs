using System;
using System.Collections.Generic;

public class MediaFile
{
    public string FileName { get; set; }

    public MediaFile(string fileName)
    {
        FileName = fileName;
    }

    public virtual void Play()
    {
        Console.WriteLine($"Відтворення медіафайлу: {FileName}");
    }
}

public interface IDownloadable
{
    void Download(string path);
}

public interface IStreamable : IDownloadable
{
    void Stream();
}

public class AudioFile : MediaFile
{
    public AudioFile(string fileName) : base(fileName) { }

    public override void Play()
    {
        Console.WriteLine($"Відтворення аудіо: {FileName}");
    }
}

public class VideoFile : MediaFile, IStreamable
{
    public VideoFile(string fileName) : base(fileName) { }

    public override void Play()
    {
        Console.WriteLine($"Відтворення відео: {FileName}");
    }

    public void Download(string path)
    {
        Console.WriteLine($"Відео {FileName} завантажено у {path}");
    }

    public void Stream()
    {
        Console.WriteLine($"Стрімінг відео: {FileName}");
    }
}

class Program
{
    static void Main()
    {
        List<MediaFile> mediaFiles = new List<MediaFile>
        {
            new AudioFile("song.mp3"),
            new VideoFile("movie.mp4")
        };

        Console.WriteLine("Відтворення файлів:");
        foreach (var media in mediaFiles)
        {
            media.Play();

            if (media is IStreamable streamable)
            {
                streamable.Download("/Users/d0n0ts1lly/Downloads/");
                streamable.Stream();
            }
        }
    }
}
