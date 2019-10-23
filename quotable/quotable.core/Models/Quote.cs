using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core.Models
{
    public class Quote
    {
        public Quote(string text,int id,string author)
        {
            Text = text;
            ID = id;
            Author = author;
        }
        public string Text { get; }
        public int ID { get;}
        public string Author { get;}
    }
}
