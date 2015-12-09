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
    public class ASQLHelper
    {
        protected static string connectionString;
        static ASQLHelper()
        {
            string connName = System.Configuration.ConfigurationManager.AppSettings["connName"];
            if (string.IsNullOrWhiteSpace(connName))
            {
                connName = "default";
            }
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
        }

        #region 方法示例
        //#region 公用方法
        ///// <summary>
        ///// 判断是否存在某表的某个字段
        ///// </summary>
        ///// <param name="tableName">表名称</param>
        ///// <param name="columnName">列名称</param>
        ///// <returns>是否存在</returns>
        //abstract public static bool ColumnExists(string tableName, string columnName);
        
        //abstract public static int GetMaxID(string FieldName, string TableName);
        //public static bool Exists(string strSql);
        
        ///// <summary>
        ///// 表是否存在
        ///// </summary>
        ///// <param name="TableName"></param>
        ///// <returns></returns>
        //public static bool TabExists(string TableName);
        
        //#endregion

        //#region  执行简单SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString);

        //public static int ExecuteSqlByTime(string SQLString, int Times);

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">多条SQL语句</param>		
        //public static int ExecuteSqlTran(List<String> SQLStringList);

        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString, string content);

        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static object ExecuteSqlGet(string SQLString, string content);

        ///// <summary>
        ///// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        ///// </summary>
        ///// <param name="strSQL">SQL语句</param>
        ///// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSqlInsertImg(string strSQL, byte[] fs);

        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string SQLString);

        //public static object GetSingle(string SQLString, int Times);

        /////// <summary>
        /////// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        /////// </summary>
        /////// <param name="strSQL">查询语句</param>
        /////// <returns>MySqlDataReader</returns>
        ////public static MySqlDataReader ExecuteReader(string strSQL);

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString);

        //public static DataSet Query(string SQLString, int Times);



        //#endregion

        //#region 执行带参数的SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms);


        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTran(Hashtable SQLStringList);

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList);

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList);

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList);

        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string SQLString, params SqlParameter[] cmdParms);


        ///// <summary>
        ///// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>MySqlDataReader</returns>
        //public static MySqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms);


        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString, params SqlParameter[] cmdParms);


        //private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, SqlParameter[] cmdParms);

        //#endregion

        //#region 存储过程操作

        ///// <summary>
        ///// 执行存储过程，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>MySqlDataReader</returns>
        //public static MySqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters);


        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="tableName">DataSet结果中的表名</param>
        ///// <returns>DataSet</returns>
        //public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName);
        //public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times);


        ///// <summary>
        ///// 构建 MySqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        ///// </summary>
        ///// <param name="connection">数据库连接</param>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>MySqlCommand</returns>
        //private static MySqlCommand BuildQueryCommand(MySqlConnection connection, string storedProcName, IDataParameter[] parameters);

        ///// <summary>
        ///// 执行存储过程，返回影响的行数		
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="rowsAffected">影响的行数</param>
        ///// <returns></returns>
        //public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected);

        ///// <summary>
        ///// 创建 MySqlCommand 对象实例(用来返回一个整数值)	
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>MySqlCommand 对象实例</returns>
        //private static MySqlCommand BuildIntCommand(MySqlConnection connection, string storedProcName, IDataParameter[] parameters);
        //#endregion
        #endregion
    }
}
