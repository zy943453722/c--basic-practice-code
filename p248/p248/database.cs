using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace p248
{
    class database
    {
        public SqlConnectionStringBuilder strings;
        public SqlConnection connection;//防止属性不断调用自身
        public SqlConnectionStringBuilder Strings
        {
            get
            {
                return strings;
            }
            set
            {
                this.strings = value;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                this.connection = value;
            }
        }
        public database()//写成构造方法，以便每次实例化时自动数据库
        {
            /*连接字符串生成器*/
            strings = new SqlConnectionStringBuilder();
            strings.DataSource = @".";
            strings.InitialCatalog = "Financing";
            strings.IntegratedSecurity = true;
            /*建立连接*/
            connection = new SqlConnection(strings.ConnectionString);
        }
    }
}
