using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureToSQL.Dtos
{
    public class ProfilePictureResult
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
