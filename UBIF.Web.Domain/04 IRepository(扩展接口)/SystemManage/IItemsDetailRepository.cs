using System;
using System.Collections.Generic;
using System.Text;
using UBIF.Web.Data.Repository;
using UBIF.Web.Data;
namespace UBIF.Web.Domain.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<SysItemsdetail>
    {
        List<SysItemsdetail> GetItemList(string enCode);
    }
}
