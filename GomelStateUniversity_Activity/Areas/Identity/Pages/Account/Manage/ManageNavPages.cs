using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GomelStateUniversity_Activity.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Email => "Email";

        public static string ChangePassword => "ChangePassword";

        public static string DeletePersonalData => "DeletePersonalData";

        public static string PersonalData => "PersonalData";

        public static string AccountManager => "AccountManager";

        public static string CreativityApplicationForms => "CreativityApplicationForms";
        public static string SportApplicationForms => "SportApplicationForms";
        public static string LaborApplicationForms => "LaborApplicationForms";


        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string AccountManagerNavClass(ViewContext viewContext) => PageNavClass(viewContext, AccountManager);

        public static string CreativityApplicationFormsNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreativityApplicationForms);
        public static string SportApplicationFormsNavClass(ViewContext viewContext) => PageNavClass(viewContext, SportApplicationForms);
        public static string LaborApplicationFormsNavClass(ViewContext viewContext) => PageNavClass(viewContext, LaborApplicationForms);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
