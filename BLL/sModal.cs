using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class sModal
    {
        public class sContent
        {
            public int id { get; set; }
            public string title { get; set; }
            public int boardid { get; set; }
            public string content { get; set; }
            public string summary { get; set; }
            public string addtime { get; set; }
            public string url { get; set; }
            public string tags { get; set; }
            public string flag { get; set; }
            public int pv { get; set; }
            public string cover { get; set; }
        }

        public class sCategory
        {
            public int id { get; set; }
            public string boardname { get; set; }
        }
    }
}
