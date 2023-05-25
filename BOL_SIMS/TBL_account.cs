using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_SIMS
{
    public partial class TBL_account
    {
        private readonly DCSIMSDataContext dc = new DCSIMSDataContext("Data Source=DESKTOP-906252G;Initial Catalog=DB_SIMS;Integrated Security=True");
        public TBL_account[] Login()
        {
            var login = from log in dc.TBL_accounts
                        where log.username == _username && log.password == _password
                        select log;
            return login.ToArray<TBL_account>();
        }
    }
}