using System;
using System.Collections.Generic;
using System.Text;

namespace ACBH.Model
{
    public class Beer
    {
        public Guid ID { get; set; }
        public string Brewery { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int Rank { get; set; }
        public int? Change { get; set; }
    }
}
