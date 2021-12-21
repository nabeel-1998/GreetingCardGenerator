using GreetingCardGenerator.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GreetingCardGenerator.Helper
{
    public class CardGenerator
    {
        public static string CreateCard(Template selectedTemplate)
        {
            byte[] ImageArray = Convert.FromBase64String(selectedTemplate.IMAGE);
            var bitmap = ByteArrayToImage(ImageArray);
           
            foreach(var item in GreetingWord.SetGreetingPoints())
            {
                int offset = 70;
                var word = item.Word.Substring(0, 1);
                var remainingword = item.Word.Substring(1);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Consolas", 30,FontStyle.Bold))
                    {
                        graphics.DrawString(word, arialFont, Brushes.Aqua, item.Location);
                        
                    }
                }
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Consolas", 30, FontStyle.Bold))
                    {
                        var point = new PointF() { X = item.Location.X + offset, Y = item.Location.Y };
                        graphics.DrawString(remainingword, arialFont, Brushes.CornflowerBlue, point);

                    }
                }
            }

            return ConvertFromBitmapToBase64String(bitmap);




            //bitmap.Save(imageFilePath);//save the image file

        }
        
        public static string ConvertFromBitmapToBase64String(Bitmap bitmap)
        {
            string SigBase64;
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                 SigBase64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
            }
            return SigBase64;
        }

        public static Bitmap ByteArrayToImage(byte[] source)
        {
            using (var ms = new MemoryStream(source))
            {
                return new Bitmap(ms);
            }
        }
    }

    class GreetingWord 
    {
        public String Word { get; set; }
        public PointF Location { get; set; }

        static float x = 700f;
        static float y = 300f;
        public static List<GreetingWord> SetGreetingPoints()
        {
            List<GreetingWord> greetingpoints = new List<GreetingWord>();
            foreach(var item in InMemoryInfoHolder.SelectedGreeting)
            {
                var CurrentWord = item.BoldLetter.ToString() + item.RemainingString;
                PointF point = new PointF(x, y);
                y += 100;
                greetingpoints.Add(new GreetingWord() { Word = CurrentWord, Location = point });
                

            }
            return greetingpoints;
        }
    }
}