using System;

namespace PictureToSQL.Models
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
