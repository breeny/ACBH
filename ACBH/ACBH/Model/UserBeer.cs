using System;
using System.Collections.Generic;
using System.Text;

namespace ACBH.Model
{
    class UserBeer
    {
        public bool HasDrunk { get; set; }
        private double rating;
        public double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (value > 5)
                {
                    rating = 5;
                }
                else if (value < 0)
                {
                    rating = 0;
                }
                {
                    rating = value;
                }
            }
        }
    }
}
