using System.Collections.Generic;

namespace  Devil7.Automation.BNI.Scrapper.Models
{
    class SearchResult
    {
        public List<string> aaData { get; set; }

        public SearchResult()
        {
            this.aaData = new List<string>();
        }
    }
}
