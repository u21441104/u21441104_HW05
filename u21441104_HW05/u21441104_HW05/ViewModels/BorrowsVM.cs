using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21441104_HW05.ViewModels
{
    public class BorrowsVM
    {
        public int ID { get; set; }
        public DateTime TAKEN_DATE { get; set; }
        public DateTime BROUGHT_DATE { get; set; }
        public string BORROWED_BY { get; set; }
    }
}