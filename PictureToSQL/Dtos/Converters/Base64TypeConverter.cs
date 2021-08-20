using AutoMapper;
using System.IO;

namespace PictureToSQL.Dtos.Converters
{
    public class Base64TypeConverter : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            using (MemoryStream m = new MemoryStream())
            {
                // Convert byte[] to Base64 String
                string base64String = System.Convert.ToBase64String(source);
                return base64String;
            }
        }
    }
}
