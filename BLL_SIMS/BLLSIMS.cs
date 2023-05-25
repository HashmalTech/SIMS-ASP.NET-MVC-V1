using BOL_SIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL_SIMS
{
    public class BLLSIMS
    {
        private readonly TBL_university un = new TBL_university();
        private readonly TBL_account acc = new TBL_account();
        private readonly TBL_view_manegerole role = new TBL_view_manegerole();

        public TBL_account[] Logins(String username, String password)
        {
            acc.username = username;
            acc.password = password;
            return acc.Login();
        }
        public TBL_university[] GetUnivs()
        {
            return un.GetUniv();
        }
        public TBL_view_manegerole[] GetRoles(String username)
        {
            role.username = username;
            return role.GetRole();
        }
    }
}