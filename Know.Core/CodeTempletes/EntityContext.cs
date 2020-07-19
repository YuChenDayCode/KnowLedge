using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Know.Core.CodeTempletes
{
    public class EntityContext
    {
        public static string GetEntityInfo(string tablename)
        {
            return tablename;
            string dbaseName = "qa_know";
            string connStr = $"Server=192.168.8.150;Port=3306;Database={dbaseName};Uid=root;Pwd=123456;SslMode=none;";
            IDbConnection con = new MySqlConnection(connStr);
            IDbCommand com = con.CreateCommand();
            string sqltxt = $"select  COLUMN_NAME  , DATA_TYPE  ,IS_NULLABLE ,IFNULL(COLUMN_COMMENT,'') ,EXTRA , COLUMN_KEY, COLUMN_TYPE  from information_schema.COLUMNS where table_name=@tableName and TABLE_SCHEMA='{dbaseName}'";

            var param = new MySql.Data.MySqlClient.MySqlParameter("@tableName", tablename);
            com.CommandText = sqltxt.ToString();
            com.Parameters.Add(param);
            try
            {
                con.Open();
                using (var read = com.ExecuteReader())
                {

                    while (!read.IsClosed && read.Read())
                    {
                        var d = read.GetString(1);
                        //var c = (MySqlDbType)System.Enum.Parse(typeof(MySqlDbType), d, true);

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    }

    public class EntityInfo
    {

        public string Entity_Type { get; set; }
        public string Entity_Name { get; set; }
        public string Entity_Desc { get; set; }

        public EntityInfo(string entitytype, string entityname,string entitydesc)
        {
            this.Entity_Type = entitytype;
            this.Entity_Name = entityname;
            this.Entity_Desc = entitydesc;
        }
    }
}
