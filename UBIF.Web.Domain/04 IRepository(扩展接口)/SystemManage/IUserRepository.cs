using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Data;
using UBIF.Web.Data.Repository;

namespace UBIF.Web.Domain.SystemManage
{
    public interface IUserRepository : IRepositoryBase<SysUser>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(SysUser userEntity, SysUserlogon userLogOnEntity, string keyValue);
    }
}
