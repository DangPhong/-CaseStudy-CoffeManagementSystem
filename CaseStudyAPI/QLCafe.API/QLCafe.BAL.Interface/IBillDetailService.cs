using QLCafe.Domain.Requets;
using QLCafe.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLCafe.BAL.Interface
{
    public interface IBillDetailService
    {
        IList< BillDetail> BillDetailGetByID(int Id);
        IList<BillDetailsView> BillDetailsView(int Id);
        bool BillDetailAddByID(BillDetailAdd request);
        int BillDetailDelete(int Id);
        bool Pay(int Id);
    }
}
