﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MTKDotNetCorePart2.RestClientApi.Model
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public bool IsActive { get; set; }
    }
}
