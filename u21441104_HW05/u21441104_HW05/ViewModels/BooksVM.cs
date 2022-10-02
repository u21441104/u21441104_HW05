using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21441104_HW05.ViewModels
{
    public class BooksVM
    {

        public int ID { get; set; }
        public string NAME { get; set; }
        public string AUTHOR { get; set; }
        public string TYPE { get; set; }
        public int PAGE_COUNT { get; set; }
        public int POINTS { get; set; }
        public bool STATUS { get; set; }
    }
}