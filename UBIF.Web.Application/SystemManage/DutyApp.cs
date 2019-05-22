#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：DutyApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/22 21:48:01
* 更新时间 ：2019/5/22 21:48:01
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Domain.IRepository.SystemManage;
using UBIF.Web.Repository.SystemManage;
using UBIF.Web.Data;
using UBIF.Web.Code;
using System.Linq;

namespace UBIF.Web.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = new RoleRepository();

        public List<SysRole> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<SysRole>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FFullName.Contains(keyword));
                expression = expression.Or(t => t.FEnCode.Contains(keyword));
            }
            expression = expression.And(t => t.FCategory == 2);
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public SysRole GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.FId == keyValue);
        }
        public void SubmitForm(SysRole roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.FId = keyValue;
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    roleEntity.FLastModifyUserId = LoginInfo.UserId;
                }
                roleEntity.FLastModifyTime = DateTime.Now;
                service.Update(roleEntity);
            }
            else
            {
                roleEntity.FId = Common.GuId();
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    roleEntity.FCreatorUserId = LoginInfo.UserId;
                }
                roleEntity.FCreatorTime = DateTime.Now;
                roleEntity.FCategory = 2;
                service.Insert(roleEntity);
            }
        }
    }
}
