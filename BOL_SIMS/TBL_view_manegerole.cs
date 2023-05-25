using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_SIMS
{
    public partial class TBL_view_manegerole
    {
        private readonly DCSIMSDataContext dc = new DCSIMSDataContext("Data Source=DESKTOP-906252G;Initial Catalog=DB_SIMS;Integrated Security=True");
        public TBL_view_manegerole[] GetRole()
        {
            var role = from ro in dc.TBL_view_manegeroles
                       where ro.username == _username
                       select ro;
            return role.ToArray<TBL_view_manegerole>();
        }
    }
}