using System.IO;

namespace MvcCaptcha
{
    public interface ICaptchaImage
    {
        void SaveImageToStream(Stream outputStream, int quality, int width, int height);
        void SaveImageToStream(Stream outputStream, int quality, int width, int height, string s);
        string CaptchaUniqueId { get; set; }
    }

    internal interface ICaptchaValue
    {
        string RenderedValue { get; }
    }
}

