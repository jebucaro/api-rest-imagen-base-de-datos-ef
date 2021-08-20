using AutoMapper;
using PictureToSQL.Dtos.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureToSQL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, byte[]>().ConvertUsing(new ByteArrayTypeConverter());
            CreateMap<byte[], string>().ConvertUsing(new Base64TypeConverter());

            CreateMap<Dtos.ProfilePictureEntry, Models.ProfilePicture>();
            CreateMap<Models.ProfilePicture, Dtos.ProfilePictureResult>();
        }
    }
}
