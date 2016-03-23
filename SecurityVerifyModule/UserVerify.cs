using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/12/6-星期日 17:53:02
 * ID: 50ac075a-c56e-4583-8131-98c1ea196748
 ***************************************************/
namespace SecurityVerifyModule
{
    /*
     * suit structure of User Table
     * 
     * CREATE TABLE `user` (
     *      `Id` int(11) NOT NULL AUTO_INCREMENT,
     *      `uid` varchar(255) NOT NULL DEFAULT '',
     *      `pwd` varchar(255) NOT NULL DEFAULT '',
     *      `salt` varchar(255) NOT NULL DEFAULT '',
     *      PRIMARY KEY (`Id`),
     *      UNIQUE KEY `uni_id` (`uid`)
     *  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
     * 
     */
    /// <summary>
    /// 用户认证方法类(MD5+Salt,MySQL)
    /// 适用用户表结构：
    /// CREATE TABLE `user` (
    ///     `Id` int(11) NOT NULL AUTO_INCREMENT,
    ///     `uid` varchar(255) NOT NULL DEFAULT '',
    ///     `pwd` varchar(255) NOT NULL DEFAULT '',
    ///     `salt` varchar(255) NOT NULL DEFAULT '',
    ///     PRIMARY KEY (`Id`),
    ///     UNIQUE KEY `uni_id` (`uid`)
    /// ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
    /// </summary>
    public class UserVerify
    {
        /// <summary>
        /// 添加用户，自动生成salt
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <returns>添加结果</returns>
        public bool AddUser(string id, string password)
        {
            return AddUser(id, password, Tools.GenerateRandomString(20));
        }

        /// <summary>
        /// 添加用户，自定义salt
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <param name="salt">salt</param>
        /// <returns>添加结果</returns>
        public bool AddUser(string id, string password, string salt)
        {
            string pwdHashString = Tools.getHashString(password.Trim() + salt.Trim());
            
            //DAL part begins here
            string sqlCmdStr = "insert into user(uid,pwd,salt) values(@id,@pwd,@salt)";
            MySql.Data.MySqlClient.MySqlParameter[] paramList = new MySql.Data.MySqlClient.MySqlParameter[3];
            paramList[0] = new MySql.Data.MySqlClient.MySqlParameter("@id", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[1] = new MySql.Data.MySqlClient.MySqlParameter("@pwd", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[2] = new MySql.Data.MySqlClient.MySqlParameter("@salt", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[0].Value = id;
            paramList[1].Value = pwdHashString;
            paramList[2].Value = salt;
            
            if (DBUtil.MySQLHelper.ExecuteSql(sqlCmdStr, paramList) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检验id-password
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <returns>1为通过，-1为未通过，0为不存在用户或其他</returns>
        public int CheckUser(string id, string password)
        {
            string sqlCmdStr = "select salt from user where uid=@uid";
            MySql.Data.MySqlClient.MySqlParameter paraUid = 
                new MySql.Data.MySqlClient.MySqlParameter("@uid", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paraUid.Value = id;
            string salt = DBUtil.MySQLHelper.GetSingle(sqlCmdStr, paraUid) as string;
            if (!string.IsNullOrWhiteSpace(salt))
            {
                string hashedPwd = Tools.getHashString(password.Trim() + salt.Trim());
                MySql.Data.MySqlClient.MySqlParameter paraPwd =
                new MySql.Data.MySqlClient.MySqlParameter("@pwd", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                paraPwd.Value = hashedPwd;

                sqlCmdStr = "select count(*) from user where uid=@uid and pwd=@pwd";
                long resultCount = (long)DBUtil.MySQLHelper.GetSingle(sqlCmdStr, paraUid, paraPwd);
                if (resultCount == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 更新密码(不改变salt)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <returns>1为成功，-1为失败，0为无此id或其他</returns>
        public int UpdatePassword(string id, string password)
        {
            string sqlCmdStr = "select salt from user where uid=@uid";

            MySql.Data.MySqlClient.MySqlParameter paraUid =
                new MySql.Data.MySqlClient.MySqlParameter("@uid", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paraUid.Value = id;
            string salt = DBUtil.MySQLHelper.GetSingle(sqlCmdStr, paraUid) as string;
            if (!string.IsNullOrWhiteSpace(salt))
            {
                string hashedPwd = Tools.getHashString(password.Trim() + salt.Trim());
                sqlCmdStr = "update user set pwd=@pwd where uid=@id;";
                MySql.Data.MySqlClient.MySqlParameter[] paramList = new MySql.Data.MySqlClient.MySqlParameter[2];
                paramList[0] = new MySql.Data.MySqlClient.MySqlParameter("@id", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                paramList[1] = new MySql.Data.MySqlClient.MySqlParameter("@pwd", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                paramList[0].Value = id;
                paramList[1].Value = hashedPwd;

                if (DBUtil.MySQLHelper.ExecuteSql(sqlCmdStr, paramList) == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新password并是生成新的随机salt
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <returns>1为成功，-1为失败</returns>
        public int UpdatePasswordAndSalt(string id, string password)
        {
            return UpdatePasswordAndSalt(id, password, Tools.GenerateRandomString(20));
        }

        /// <summary>
        /// 更新password及指定salt
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">password</param>
        /// <param name="salt">salt</param>
        /// <returns>1为成功，-1为失败</returns>
        public int UpdatePasswordAndSalt(string id, string password, string salt)
        {
            string pwdHashString = Tools.getHashString(password.Trim() + salt.Trim());

            //DAL part begins here
            string sqlCmdStr = "update user set pwd=@pwd , salt=@salt  where uid=@id;";
            MySql.Data.MySqlClient.MySqlParameter[] paramList = new MySql.Data.MySqlClient.MySqlParameter[3];
            paramList[0] = new MySql.Data.MySqlClient.MySqlParameter("@id", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[1] = new MySql.Data.MySqlClient.MySqlParameter("@pwd", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[2] = new MySql.Data.MySqlClient.MySqlParameter("@salt", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            paramList[0].Value = id;
            paramList[1].Value = pwdHashString;
            paramList[2].Value = salt;

            if (DBUtil.MySQLHelper.ExecuteSql(sqlCmdStr, paramList) == 1)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

}
