using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool AddUser(string id, string password);
        public bool AddUser(string id,string password,string salt);
        public int CheckUser(string id, string password);
        public int UpdatePassword(string id, string password);
        public int UpdatePasswordAndSalt(string id, string password);
        public int UpdatePasswordAndSalt(string id, string password, string salt);
    }
}
