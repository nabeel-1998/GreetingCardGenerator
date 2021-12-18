using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace GreetingCardGenerator.Helper
{
    public class ImageHelper
    {
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
    }
}
