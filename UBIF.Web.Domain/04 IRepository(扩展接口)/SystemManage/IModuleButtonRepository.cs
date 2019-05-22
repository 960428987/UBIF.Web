using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Data;
using UBIF.Web.Data.Repository;
namespace UBIF.Web.Domain.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<SysModulebutton>
    {
        void SubmitCloneButton(List<SysModulebutton> entitys);
    }
}
