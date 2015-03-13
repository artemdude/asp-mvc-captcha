using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MvcCaptcha
{
    public class CaptchaResult : ActionResult
    {
        private const int BufferSize = 0x1000;
 
        private readonly ICaptchaImage image;
        private readonly int quality;
        private readonly int width;
        private readonly int height;

        internal CaptchaResult(ICaptchaImage image, int quality, int width, int height)
        {
            this.image = image;
            this.quality = quality;
            this.width = width;
            this.height = height;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/jpeg";
            var ms = new MemoryStream();
            image.SaveImageToStream(ms, quality, width, height);
            ms.Position = 0;
            WriteStream(response, ms);
        }

        protected void WriteStream(HttpResponseBase response, Stream stream)
        {
            // grab chunks of data and write to the output stream 
            var outputStream = response.OutputStream;
            using (stream)
            {
                var buffer = new byte[BufferSize];
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, BufferSize);
                    if (bytesRead == 0)
                    {
                        // no more data 
                        break;
                    }
                    outputStream.Write(buffer, 0, bytesRead);
                }
            }
        } 
    }
}
