﻿using System;
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
            catch (SystemException ex)
            {
                ex.ToString();
                flag = false;
            }
            return flag;
        }

        //mysql查询
        public bool _queryTableMySQL(string queryCmd, ref DataTable resultDt)
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
                resultDt.Rows.Clear();
                adapter.Fill(resultDt);//将查询的内容填充到数据表中
                flag = true;
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return flag;
        }

        //mysql插入记录
        public bool _insertMySQL(string insertCmd)
        {
            bool flag = false;
            try
            {
                MySqlCommand myCommand = new MySqlCommand(insertCmd, this.conn);//创建MySqlCommand对象
                myCommand.CommandType = CommandType.Text;//命令类型
                myCommand.CommandTimeout = 12000;

                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();//开启连接
                }
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }//更新内容(返回受影响函数，如增、删、改操作)
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return flag;
        }

        //mysql删除记录
        public bool _deleteMySQL(string delCmd)
        {
            bool flag = false;
            try
            {
                MySqlCommand myCommand = new MySqlCommand(delCmd, this.conn);//创建MySqlCommand对象
                myCommand.CommandType = CommandType.Text;//命令类型
                myCommand.CommandTimeout = 12000;

                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();//开启连接
                }
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }//更新内容(返回受影响函数，如增、删、改操作)
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return flag;
        }

        public bool _updateMysql(string updateCmd)
        {
            bool flag = false;
            try
            {
                MySqlCommand myCommand = new MySqlCommand(updateCmd, this.conn);//创建MySqlCommand对象
                myCommand.CommandType = CommandType.Text;//命令类型
                myCommand.CommandTimeout = 12000;

                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();//开启连接
                }
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }//更新内容(返回受影响函数，如增、删、改操作)
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return flag;
        }

    }
}
