﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCorePart2.RestClientConsoleApp
{
    public class BlogDto
    {
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public bool IsActive { get; set; }
    }
}
