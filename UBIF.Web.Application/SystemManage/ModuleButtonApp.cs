#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：ModuleButtonApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/22 21:52:39
* 更新时间 ：2019/5/22 21:52:39
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
    public class ModuleButtonApp
    {
        private IModuleButtonRepository service = new ModuleButtonRepository();

        public List<SysModulebutton> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<SysModulebutton>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.FModuleId == moduleId);
            }
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public SysModulebutton GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.FParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.FId == keyValue);
            }
        }
        public void SubmitForm(SysModulebutton moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.FId = keyValue;
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    moduleButtonEntity.FLastModifyUserId = LoginInfo.UserId;
                }
                moduleButtonEntity.FLastModifyTime = DateTime.Now;
                service.Update(moduleButtonEntity);
            }
            else
            {
                moduleButtonEntity.FId = Common.GuId();
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    moduleButtonEntity.FCreatorUserId = LoginInfo.UserId;
                }
                moduleButtonEntity.FCreatorTime = DateTime.Now;
                service.Insert(moduleButtonEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<SysModulebutton> entitys = new List<SysModulebutton>();
            foreach (string item in ArrayId)
            {
                SysModulebutton moduleButtonEntity = data.Find(t => t.FId == item);
                moduleButtonEntity.FId = Common.GuId();
                moduleButtonEntity.FModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            service.SubmitCloneButton(entitys);
        }
    }
}
