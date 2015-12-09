using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/12/9-星期三 15:49:30
 * ID: b92f06f8-e96e-49e3-b64f-bfb76f13a223
 ***************************************************/
namespace DBUtil
{
    /// <summary>
    /// SQLHelper的基类，用于导入连接字符串
    /// </summary>
    public class ASQLHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        protected static string connectionString;
        
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ASQLHelper()
        {
            string connName = System.Configuration.ConfigurationManager.AppSettings["connName"];
            if (string.IsNullOrWhiteSpace(connName))
            {
                connName = "default";
            }
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public static void SetConnectionString(string connectionString)
        {
            ASQLHelper.connectionString = connectionString;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString()
        {
            return ASQLHelper.connectionString;
        }

        #region Method Sample (base on SQLServer)

        //#region 公用方法
        ///// <summary>
        ///// 判断是否存在某表的某个字段
        ///// </summary>
        ///// <param name="tableName">表名称</param>
        ///// <param name="columnName">列名称</param>
        ///// <returns>是否存在</returns>
        //public static bool ColumnExists(string tableName, string columnName)
        //{
        //    string sql = "select count(1) from syscolumns where [id]=object_id(@tableName) and [name]='@columnName";
        //    SqlParameter paraTableName = new SqlParameter("@tableName", SqlDbType.VarChar);
        //    paraTableName.Value = tableName;
        //    SqlParameter paraColumnName = new SqlParameter("@columnName", SqlDbType.VarChar);
        //    paraColumnName.Value = columnName;
        //    object res = GetSingle(sql, paraTableName, paraColumnName);
        //    if (res == null)
        //    {
        //        return false;
        //    }
        //    return Convert.ToInt32(res) > 0;
        //}

        ///// <summary>
        ///// 获取最大ID
        ///// </summary>
        ///// <param name="FieldName">字段名</param>
        ///// <param name="tableName">表名</param>
        ///// <returns>最大ID</returns>
        //public static int GetMaxID(string fieldName, string tableName)
        //{
        //    string strsql = "select max(@fieldName) from @tableName";
        //    SqlParameter paraFieldName = new SqlParameter("@columnName", SqlDbType.VarChar);
        //    paraFieldName.Value = fieldName;
        //    SqlParameter paraTableName = new SqlParameter("@tableName", SqlDbType.VarChar);
        //    paraTableName.Value = tableName;
        //    object obj = GetSingle(strsql, paraFieldName, paraTableName);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}

        ///// <summary>
        ///// 获取下一个ID
        ///// </summary>
        ///// <param name="FieldName">字段名</param>
        ///// <param name="tableName">表名</param>
        ///// <returns>最大ID</returns>
        //public static int GetNextID(string fieldName, string tableName)
        //{
        //    string strsql = "select max(@fieldName)+1 from @tableName";
        //    SqlParameter paraFieldName = new SqlParameter("@columnName", SqlDbType.VarChar);
        //    paraFieldName.Value = fieldName;
        //    SqlParameter paraTableName = new SqlParameter("@tableName", SqlDbType.VarChar);
        //    paraTableName.Value = tableName;
        //    object obj = GetSingle(strsql, paraFieldName, paraTableName);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}


        ///// <summary>
        ///// 表是否存在
        ///// </summary>
        ///// <param name="tableName">表名</param>
        ///// <returns></returns>
        //public static bool TabExists(string tableName)
        //{
        //    string strsql =
        //        "select count(*) from sysobjects " +
        //            "where id = object_id(N'[@tableName]') " +
        //              "and OBJECTPROPERTY(id, N'IsUserTable') = 1";
        //    SqlParameter paraTableName = new SqlParameter("@tableName", SqlDbType.VarChar);
        //    paraTableName.Value = tableName;
        //    object obj = GetSingle(strsql, paraTableName);
        //    int cmdresult;
        //    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// 存在性判断
        ///// </summary>
        ///// <param name="strSql">sql语句</param>
        ///// <param name="cmdParms">参数列表</param>
        ///// <returns></returns>
        //public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        //{
        //    object obj = GetSingle(strSql, cmdParms);
        //    int cmdresult;
        //    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //#endregion

        //#region  执行简单SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="sqlString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string sqlString)
        //{

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 在限定时间内执行SQL语句
        ///// </summary>
        ///// <param name="sqlString">SQL语句</param>
        ///// <param name="time">时间限制（秒）</param>
        ///// <returns>受影响行数</returns>
        //public static int ExecuteSqlByTime(string sqlString, int time)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                cmd.CommandTimeout = time;
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="sqlStringList">多条SQL语句</param>		
        //public static int ExecuteSqlTran(List<String> sqlStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        SqlTransaction tx = conn.BeginTransaction();
        //        cmd.Transaction = tx;
        //        try
        //        {
        //            int count = 0;
        //            for (int n = 0; n < sqlStringList.Count; n++)
        //            {
        //                string strsql = sqlStringList[n];
        //                if (strsql.Trim().Length > 1)
        //                {
        //                    cmd.CommandText = strsql;
        //                    count += cmd.ExecuteNonQuery();
        //                }
        //            }
        //            tx.Commit();
        //            return count;
        //        }
        //        catch
        //        {
        //            tx.Rollback();
        //            return 0;
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="sqlString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string sqlString, string content)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(sqlString, connection);

        //        SqlParameter myParameter = new SqlParameter("?content", SqlDbType.Text);
        //        myParameter.Value = content;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (System.Data.SqlClient.SqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="sqlString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static object ExecuteSqlGet(string sqlString, string content)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(sqlString, connection);
        //        SqlParameter myParameter = new SqlParameter("?content", SqlDbType.Text);
        //        myParameter.Value = content;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            object obj = cmd.ExecuteScalar();
        //            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                return obj;
        //            }
        //        }
        //        catch (System.Data.SqlClient.SqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 向数据库里插入图像格式的字段!!-UNCHECKED
        ///// </summary>
        ///// <param name="strSQL">SQL语句</param>
        ///// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(strSQL, connection);
        //        SqlParameter myParameter = new SqlParameter("?fs", SqlDbType.Image);
        //        myParameter.Value = fs;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (System.Data.SqlClient.SqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="sqlString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string sqlString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                object obj = cmd.ExecuteScalar();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}
        //public static object GetSingle(string sqlString, int Times)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                cmd.CommandTimeout = Times;
        //                object obj = cmd.ExecuteScalar();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>SqlDataReader</returns>
        //public static SqlDataReader ExecuteReader(string strSQL)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand(strSQL, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        return myReader;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw e;
        //    }

        //}
        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="sqlString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string sqlString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            SqlDataAdapter command = new SqlDataAdapter(sqlString, connection);
        //            command.Fill(ds, "ds");
        //        }
        //        catch (System.Data.SqlClient.SqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}
        //public static DataSet Query(string sqlString, int Times)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            SqlDataAdapter command = new SqlDataAdapter(sqlString, connection);
        //            command.SelectCommand.CommandTimeout = Times;
        //            command.Fill(ds, "ds");
        //        }
        //        catch (System.Data.SqlClient.SqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}



        //#endregion

        //#region 执行带参数的SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="sqlString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string sqlString, params SqlParameter[] cmdParms)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
        //                int rows = cmd.ExecuteNonQuery();
        //                cmd.Parameters.Clear();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                throw e;
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTran(Hashtable sqlStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                //循环
        //                foreach (DictionaryEntry myDE in sqlStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                int count = 0;
        //                //循环
        //                foreach (CommandInfo myDE in cmdList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

        //                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //                    {
        //                        if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }

        //                        object obj = cmd.ExecuteScalar();
        //                        bool isHave = false;
        //                        if (obj == null && obj == DBNull.Value)
        //                        {
        //                            isHave = false;
        //                        }
        //                        isHave = Convert.ToInt32(obj) > 0;

        //                        if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        continue;
        //                    }
        //                    int val = cmd.ExecuteNonQuery();
        //                    count += val;
        //                    if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //                    {
        //                        trans.Rollback();
        //                        return 0;
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //                return count;
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> sqlStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                int indentity = 0;
        //                //循环
        //                foreach (CommandInfo myDE in sqlStringList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.InputOutput)
        //                        {
        //                            q.Value = indentity;
        //                        }
        //                    }
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.Output)
        //                        {
        //                            indentity = Convert.ToInt32(q.Value);
        //                        }
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(Hashtable sqlStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                int indentity = 0;
        //                //循环
        //                foreach (DictionaryEntry myDE in sqlStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.InputOutput)
        //                        {
        //                            q.Value = indentity;
        //                        }
        //                    }
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.Output)
        //                        {
        //                            indentity = Convert.ToInt32(q.Value);
        //                        }
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行查询语句，返回第一条第一项查询结果（object）。
        ///// </summary>
        ///// <param name="sqlString">查询语句</param>
        ///// <returns>查询结果</returns>
        //public static object GetSingle(string sqlString, params SqlParameter[] cmdParms)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
        //                object obj = cmd.ExecuteScalar();
        //                cmd.Parameters.Clear();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                throw e;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>SqlDataReader</returns>
        //public static SqlDataReader ExecuteReader(string sqlString, params SqlParameter[] cmdParms)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        PrepareCommand(cmd, connection, null, sqlString, cmdParms);
        //        SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Parameters.Clear();
        //        return myReader;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw e;
        //    }

        //}

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="sqlString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string sqlString, params SqlParameter[] cmdParms)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        PrepareCommand(cmd, connection, null, sqlString, cmdParms);
        //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                da.Fill(ds, "ds");
        //                cmd.Parameters.Clear();
        //            }
        //            catch (System.Data.SqlClient.SqlException ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //            return ds;
        //        }
        //    }
        //}


        //private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;
        //    cmd.CommandType = CommandType.Text;//cmdType;
        //    if (cmdParms != null)
        //    {


        //        foreach (SqlParameter parameter in cmdParms)
        //        {
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            cmd.Parameters.Add(parameter);
        //        }
        //    }
        //}

        //#endregion

        //#region 存储过程操作

        ///// <summary>
        ///// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlDataReader</returns>
        //public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlDataReader returnReader;
        //    connection.Open();
        //    SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        //    command.CommandType = CommandType.StoredProcedure;
        //    returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    return returnReader;

        //}


        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="tableName">DataSet结果中的表名</param>
        ///// <returns>DataSet</returns>
        //public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet dataSet = new DataSet();
        //        connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.Fill(dataSet, tableName);
        //        connection.Close();
        //        return dataSet;
        //    }
        //}
        //public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet dataSet = new DataSet();
        //        connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.SelectCommand.CommandTimeout = Times;
        //        sqlDA.Fill(dataSet, tableName);
        //        connection.Close();
        //        return dataSet;
        //    }
        //}


        ///// <summary>
        ///// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        ///// </summary>
        ///// <param name="connection">数据库连接</param>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlCommand</returns>
        //private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        //{
        //    SqlCommand command = new SqlCommand(storedProcName, connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    foreach (SqlParameter parameter in parameters)
        //    {
        //        if (parameter != null)
        //        {
        //            // 检查未分配值的输出参数,将其分配以DBNull.Value.
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            command.Parameters.Add(parameter);
        //        }
        //    }

        //    return command;
        //}

        ///// <summary>
        ///// 执行存储过程，返回影响的行数		
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="rowsAffected">影响的行数</param>
        ///// <returns></returns>
        //public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        int result;
        //        connection.Open();
        //        SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
        //        rowsAffected = command.ExecuteNonQuery();
        //        result = (int)command.Parameters["ReturnValue"].Value;
        //        //Connection.Close();
        //        return result;
        //    }
        //}

        ///// <summary>
        ///// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlCommand 对象实例</returns>
        //private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        //{
        //    SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        //    command.Parameters.Add(new SqlParameter("ReturnValue",
        //        SqlDbType.Int, 4, ParameterDirection.ReturnValue,
        //        false, 0, 0, string.Empty, DataRowVersion.Default, null));
        //    return command;
        //}
        //#endregion

        #endregion
    }
}
