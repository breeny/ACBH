using System;
using System.Collections.Generic;
using System.Text;

namespace ACBH.Model
{
    class BeerEntry
    {
        public Beer Beer { get; set; }
        public UserBeer UserBeer { get; set; }
        public YearDetails YearDetails { get; set; }
    }
}
