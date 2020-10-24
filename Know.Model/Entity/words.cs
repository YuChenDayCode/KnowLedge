using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Know.Model.Entity
{
    [EntityMapper_TableName("words")]
    public class words
    {
        public int w_id { get; set; }

        public string word { get; set; }

        public string word_ci { get; set; }

        public int freq { get; set; }
    }
}
