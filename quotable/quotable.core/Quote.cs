using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace quotable.core
{
    public sealed class Quote
    { 
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>

        public long Id { get; set; }

        /// <summary>
        /// The title of the document.
        /// </summary>
        public string QuoteContent { get; set; }

        /// <summary>
        /// The collection of authors of the document
        /// </summary>
        [NotMapped]
        public IEnumerable<Author> Authors => from x in QuoteAuthor select x.Author;

        /// <summary>
        /// The relation of document to author
        /// </summary>
        public ICollection<QuoteAuthor> QuoteAuthor { get; set; } = new List<QuoteAuthor>();
    }
}
