using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace GreetingCardGenerator.Helper
{
    public class ImageHelper
    {
        

        public ImageHelper()
        { 
        }
        public static async Task<string> ConvertIFormFIleToString(IFormFile file)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
               
            }
            var ImageString = Convert.ToBase64String(bytes);
            return ImageString;
        }

        //public static IActionResult DownloadCard(String CardImage)
        //{
        //    Image Image;
        //    byte[] arr = Convert.FromBase64String(CardImage);
        //    using (var memoryStream =new MemoryStream(arr))
        //    {
        //        Image = Image.FromStream(memoryStream);
        //        Image.Save("D:\\file.png");
        //    }
          
            
            

        //}
    }
}
