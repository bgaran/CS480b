using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public sealed class Author
    {
        /// <summary>
        /// The unique identifier for the author.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The first name of the author.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name fo the author
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The relation of document to author
        /// </summary>
        public ICollection<QuoteAuthor> DocumentAuthor { get; set; }
    }
}
