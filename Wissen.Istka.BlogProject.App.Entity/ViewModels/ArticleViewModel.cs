﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wissen.Istka.BlogProject.App.Entity.ViewModels
{
    public class ArticleViewModel 
    {
        public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
