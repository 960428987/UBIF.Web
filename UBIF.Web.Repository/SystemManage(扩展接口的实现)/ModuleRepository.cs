#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Repository.SystemManage_扩展接口的实现_
* 项目描述 ：
* 类 名 称 ：ModuleRepository
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Repository.SystemManage_扩展接口的实现_
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/22 21:39:45
* 更新时间 ：2019/5/22 21:39:45
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Data;
using UBIF.Web.Data.Repository;
using UBIF.Web.Domain.IRepository.SystemManage;

namespace UBIF.Web.Repository.SystemManage
{
    public class ModuleRepository : RepositoryBase<SysModule>, IModuleRepository
    {
    }
}
