using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FreeSql;

namespace Core.Data.MyFreeSql
{
    public class FreeSqlConfig
    {
        public string MasterConnectStr { get; set; }

        public System.Collections.Generic.List<SlaveConnection> SlaveConnects { get; set; }

        public FreeSql.DataType DataType { get; set; }

    }
    public class SlaveConnection
    {
        public string ConnectionString { get; set; }
    }
}
