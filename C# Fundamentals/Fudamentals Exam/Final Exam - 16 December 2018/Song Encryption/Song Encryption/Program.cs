using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var patern = new Regex(@"^([A-Z][a-z\s']+):([A-Z\s]+?)$");

            string input = Console.ReadLine();

            while (input != "end")
            {

                if (patern.IsMatch(input))
                {

                    var song = patern.Match(input);

                    string artist = song.Groups[1].Value;
                    string nameSong = song.Groups[2].Value;
                    int key = artist.Length;

                    string encryptName = EncryptSongName(nameSong, key);
                    string encryptArtist = EncryptArtist(artist, key);

                    Console.WriteLine($"Successful encryption: {encryptArtist}@{encryptName}");

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        static string EncryptArtist(string artist, int key)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (var letter in artist)
            {
                if ((int)letter != 32 && (int)letter != 39)
                {
                    int newLetter = letter + key;
                    if (count == 0)
                    {
                        while (newLetter > 90)
                        {
                            newLetter -= 26;
                        }
                        count++;
                    }
                    else
                    {
                        while (newLetter > 122)
                        {
                            newLetter -= 26;
                        }
                    }
                    sb.Append((char)newLetter);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
        static string EncryptSongName(string nameSong, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var letter in nameSong)
            {
                if ((int)letter != 32 && (int)letter != 39)
                {
                    int newLetter = letter + key;

                    while (newLetter > 90)
                    {
                        newLetter -= 26;
                    }

                    sb.Append((char)newLetter);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}
