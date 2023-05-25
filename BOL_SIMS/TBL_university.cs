using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_SIMS
{
    public partial class TBL_university
    {
        private readonly DCSIMSDataContext dc = new DCSIMSDataContext("Data Source=DESKTOP-906252G;Initial Catalog=DB_SIMS;Integrated Security=True");
        public TBL_university[] GetUniv()
        {
            var univ = from un in dc.TBL_universities
                       select un;
            return univ.ToArray<TBL_university>();
        }
    }
}