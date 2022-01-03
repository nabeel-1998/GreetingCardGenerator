using GreetingCardGenerator.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GreetingCardGenerator.Helper
{
    public class CardGenerator
    {
        public static string CreateCard(Template selectedTemplate,float x, float y)
        {
            byte[] ImageArray = Convert.FromBase64String(selectedTemplate.IMAGE);
            var bitmap = ByteArrayToImage(ImageArray);
           
            foreach(var item in GreetingWord.SetGreetingPoints(x,y))
            {
                int offset = 100;
                var word = item.Word.Substring(0, 1);
                var remainingword = item.Word.Substring(1);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Happy Monkey", 35,FontStyle.Bold))
                    {
                        graphics.DrawString(word, arialFont, Brushes.DarkCyan, item.Location);
                        
                    }
                }
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Happy Monkey", 35, FontStyle.Bold))
                    {
                        var point = new PointF() { X = item.Location.X + offset, Y = item.Location.Y };
                        graphics.DrawString(remainingword, arialFont, Brushes.Peru, point);

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

        
        public static List<GreetingWord> SetGreetingPoints(float x, float y)
        {
            if(y==0)
            {
                y = 350f; // X oosition
            }
            if(x==0)
            {
                x = 500f; // Y Position
            }
            List<GreetingWord> greetingpoints = new List<GreetingWord>();
            foreach(var item in InMemoryInfoHolder.SelectedGreeting)
            {
                var CurrentWord = item.BoldLetter.ToString() + item.RemainingString;
                PointF point = new PointF(x, y);
                y += 130;
                greetingpoints.Add(new GreetingWord() { Word = CurrentWord, Location = point });
                

            }
            return greetingpoints;
        }
    }
}