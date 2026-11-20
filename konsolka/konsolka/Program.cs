using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    class MainProgram
    {
      public static void Main(string[] args)
      {
         List<Music> Musics = LoadData("Data.txt");
         DisplayData(Musics);
        }

        public static List<Music> LoadData(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<Music> Musics = new List<Music>();

            for (int i = 0; i < lines.Length; i++)
            {
                if(string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                Music music = new Music();

                music.artistName = lines[i];
                music.albumName = lines[i + 1];
                music.songsNumber = int.Parse(lines[i + 2]);
                music.releaseYear = int.Parse(lines[i + 3]);
                music.downloadNumber = long.Parse(lines[i + 4]);
                Musics.Add(music);
                i += 4;
            }

            return Musics;
        }

        public static void DisplayData(List<Music> Musics)
        {
            foreach(Music music in Musics)
            {
                Console.WriteLine("Artist Name: " + music.artistName);
                Console.WriteLine("Album Name: " + music.albumName);
                Console.WriteLine("Songs Number: " + music.songsNumber);
                Console.WriteLine("Release Year: " + music.releaseYear);
                Console.WriteLine("Download Number: " + music.downloadNumber);
                Console.WriteLine();
            }
        }
    };

    class Music
    {
        public string artistName;
        public string albumName;
        public int songsNumber;
        public int releaseYear;
        public long downloadNumber;
    };
}