#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：AreaApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/22 21:45:08
* 更新时间 ：2019/5/22 21:45:08
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBIF.Web.Domain.IRepository.SystemManage;
using UBIF.Web.Repository.SystemManage;
using UBIF.Web.Data;
using UBIF.Web.Code;

namespace UBIF.Web.Application.SystemManage
{
    public class AreaApp
    {
        private IAreaRepository service = new AreaRepository();

        public List<SysArea> GetList()
        {
            return service.IQueryable().ToList();
        }
        public SysArea GetForm(string keyValue)
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
        public void SubmitForm(SysArea areaEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.FId = keyValue;
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    areaEntity.FLastModifyUserId = LoginInfo.UserId;
                }
                areaEntity.FLastModifyTime = DateTime.Now;
                service.Update(areaEntity);
            }
            else
            {
                areaEntity.FId = Common.GuId();
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    areaEntity.FCreatorUserId = LoginInfo.UserId;
                }
                areaEntity.FCreatorTime = DateTime.Now;
                service.Insert(areaEntity);
            }
        }
    }
}
