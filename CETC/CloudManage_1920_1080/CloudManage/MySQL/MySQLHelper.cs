using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CloudManage.MySQL
{
    class MySQLHelper
    {
        public MySqlConnection conn;   //连接对象
        private string DataSource = String.Empty;
        private string DbName = String.Empty;
        private string UserName = String.Empty;
        private string Password = String.Empty;
        private string connStr = String.Empty;


        public MySQLHelper(string host, string db, string user, string pw)
        {
            this.DataSource = host;
            this.DbName = db;
            this.UserName = user;
            this.Password = pw;
            connStr = "data source=" + DataSource + ";database=" + DbName + ";user id=" + UserName + ";password=" + Password + ";";

        }

        public string dataSource
        {
            get
            {
                return this.DataSource;
            }
            set
            {
                this.DataSource = value;
                connStr = "data source=" + DataSource + ";database=" + DbName + ";user id=" + UserName + ";password=" + Password + ";";

            }
        }

        public string dbName
        {
            get
            {
                return this.DbName;
            }
            set
            {
                this.DbName = value;
                connStr = "data source=" + DataSource + ";database=" + DbName + ";user id=" + UserName + ";password=" + Password + ";";

            }
        }

        public string userName
        {
            get
            {
                return this.UserName;
            }
            set
            {
                this.UserName = value;
                connStr = "data source=" + DataSource + ";database=" + DbName + ";user id=" + UserName + ";password=" + Password + ";";

            }
        }

        public string password
        {
            get
            {
                return this.Password;
            }
            set
            {
                this.Password = value;
                connStr = "data source=" + DataSource + ";database=" + DbName + ";user id=" + UserName + ";password=" + Password + ";";

            }
        }

        //mysql连接
        public bool _connectMySQL()
        {
            bool flag = false;
            try
            {
                this.conn = new MySqlConnection(this.connStr);
                this.conn.Open();
                flag = true;
            }
            catch(SystemException ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;
        }

        //mysql查询
        public bool _queryMySQL(string queryCmd, ref DataTable resultDt)
        {
            bool flag = false;
            try
            {
                MySqlCommand myCommand = new MySqlCommand(queryCmd, this.conn);//创建MySqlCommand对象
                myCommand.CommandTimeout = 12000;//超时
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();//开启连接
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(queryCmd, this.conn);//创建MySqlDataAdapter对象
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);//此处必须有，否则无法更新
                adapter.Fill(resultDt);//将查询的内容填充到数据表中
                flag = true;
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return flag;
        }


    }
}
