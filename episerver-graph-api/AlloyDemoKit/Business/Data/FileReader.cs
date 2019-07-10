using EPiServer.Core;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Data
{
    public class FileReader
    {
        public static string GetFileSize(MediaData media)
        {
            if (media != null && media.BinaryData != null)
            {
                using (var stream = media.BinaryData.OpenRead())
                {
                    return (stream.Length / 1024) + " kB";
                }
            }
            return string.Empty;
        }
    }
}
