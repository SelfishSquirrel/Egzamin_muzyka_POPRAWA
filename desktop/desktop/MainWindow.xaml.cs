using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System;

namespace desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Music
    {
        public string artistName;
        public string albumName;
        public int songsNumber;
        public int releaseYear;
        public long downloadNumber;
    };
    public partial class MainWindow : Window
    {
        public int currentIndex = 1;

        public List<Music> Musics = new List<Music>();
        public MainWindow()
        {
            InitializeComponent();

            Musics = LoadData("Data.txt");
            DisplayData(currentIndex);
        }

        public static List<Music> LoadData(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<Music> Musics = new List<Music>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
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

        public void DisplayData(int index)
        {
            if (index < 0 || index >= Musics.Count)
            {
                return;
            }
            Music music = Musics[index];

            Wykonawca.Text = music.artistName;
            NazwaAlbumu.Text = music.albumName;
            LiczbaUtworow.Text = music.songsNumber.ToString();
            RokWydania.Text = music.releaseYear.ToString();
            LiczbaPobran.Text = music.downloadNumber.ToString();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = Musics.Count - 1;
            }
            DisplayData(currentIndex);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;

            if (currentIndex > Musics.Count - 1)
            {
                currentIndex = 0;
            }
            DisplayData(currentIndex);
        }

        private void Pobierz_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < 0 || currentIndex >= Musics.Count )
            {
               return;
            }

            Musics[currentIndex].downloadNumber++;
            DisplayData(currentIndex);
        }
    };
}