using AutoMapper;

namespace PictureToSQL.Dtos.Converters
{
    public class ByteArrayTypeConverter : ITypeConverter<string, byte[]>
    {
        public byte[] Convert(string source, byte[] destination, ResolutionContext context)
        {
            byte[] imageBytes = System.Convert.FromBase64String(source);
            return imageBytes;
        }
    }
}
