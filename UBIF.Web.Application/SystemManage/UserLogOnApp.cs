#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：UserLogOnApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/20 21:37:53
* 更新时间 ：2019/5/20 21:37:53
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Domain.SystemManage;
using UBIF.Web.Data;
using UBIF.Web.Repository.SystemManage;
using UBIF.Web.Code;

namespace UBIF.Web.Application.SystemManage
{
    public class UserLogOnApp
    {
        private IUserLogOnRepository service = new UserLogOnRepository();

        public SysUserlogon GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void UpdateForm(SysUserlogon userLogOnEntity)
        {
            service.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword, string keyValue)
        {
            SysUserlogon userLogOnEntity = new SysUserlogon();
            userLogOnEntity.FId = keyValue;
            userLogOnEntity.FUserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.FUserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), userLogOnEntity.FUserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnEntity);
        }
    }
}
