using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using YoutubeExtractor;

namespace HR
{
    class YouTube
    {
        string downloadLocation = "";
        public void FindLink(string URL)
        {
            URL = "https://www.youtube.com";
            string start = "/watch?v=Uvj827SqHak";
            downloadLocation = "E:/Downloads";
            string linkFile = @"E:\youtube.txt";

            List<string> links = new List<string>();
            
            Queue<string> K = new Queue<string>();


            //if (File.Exists(linkFile))
            //{
            //    string[] lines = System.IO.File.ReadAllLines(linkFile);
            //    if (lines.Length > 0)
            //    {
            //        start = lines[(new Random()).Next(1, lines.Length)];
            //        links.AddRange(lines);
            //    }
            //}
            
            K.Enqueue(URL + start);

            int level = 1;
            while (level < 4)
            {
                while (K.Count > 0)
                {
                    string curURL = K.Dequeue();

                    HtmlWeb hw = new HtmlWeb();
                    HtmlDocument doc = hw.Load(curURL);

                    int count = 0;
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        if (link != null)
                        {
                            bool b = (link.OuterHtml.Contains("/watch"));
                            if (b && count < 5)
                            {
                                count++;
                                string temp = link.Attributes["href"].Value;
                                if (temp.StartsWith("/w") && !links.Contains(temp))
                                {
                                    links.Add(temp);
                                    K.Enqueue(URL + temp);
                                }
                            }
                        }
                    }
                    if (links.Count > 150)
                        break;
                }
                if (links.Count > 150)
                    break;
                level++;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(linkFile, false))
            {
                for (int i = 0; i < links.Count; i++)
                {
                    try
                    {
                        file.WriteLine(links[i]);
                        string s = links[i];
                        if(s.IndexOf("&amp") > 0)
                            s = s.Substring(0, s.IndexOf("&amp"));  
                        DownloadAudio(URL + s);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            
        }

        public void DownloadAudio(string link)
        {

            // Our test youtube link
            //string link = "insert youtube link";

            /*
             * Get the available video formats.
             * We'll work with them in the video and audio download examples.
             */
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);

            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderByDescending(info => info.AudioBitrate)
                .First();
            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */
            string fileName = video.Title;
            fileName =  Regex.Replace(fileName, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            var audioDownloader = new AudioDownloader(video, Path.Combine(downloadLocation, fileName + video.AudioExtension));

            
            // Register the progress events. We treat the download progress as 85% of the progress and the extraction progress only as 15% of the progress,
            // because the download will take much longer than the audio extraction.
            audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
            audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

            if (!File.Exists(Path.Combine(downloadLocation, fileName + video.AudioExtension)))
            {
                /*
                 * Execute the audio downloader.
                 * For GUI applications note, that this method runs synchronously.
                 */
                audioDownloader.Execute();
            }
        }
    }
}
