using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public class QuoteAuthor
    {
        /// <summary>
        /// The ID of the quote related to the author.
        /// </summary>
        public long QuoteId { get; set; }
        /// <summary>
        /// The quote related to the author.
        /// </summary>
        public Quote Quote { get; set; }

        /// <summary>
        /// The ID of the author related to the document.
        /// </summary>
        public long AuthorId { get; set; }
        /// <summary>
        /// The author related to the document.
        /// </summary>
        public Author Author { get; set; }
    }
}
