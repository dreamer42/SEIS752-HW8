using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFMVC.Models
{
    public class FFUserDetail
    {
        public FFUser user { get; set; }
        public IEnumerable<FFUser> friends { get; set; }
    }
}