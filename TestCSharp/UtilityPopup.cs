using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TestCSharp
{
    public static class UtilityPopup
    {

        public static void PopupErrore(Page page, string messaggio = "")
        {
            if (string.IsNullOrWhiteSpace(messaggio))
            {
                messaggio = "Errore";
            }
            page.ClientScript.RegisterStartupScript(page.GetType(), "alertResult", "alert('" + messaggio + "');", true);
        }

    }
}