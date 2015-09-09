using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestCSharp.BusinessEntity;
using TestCSharp.BusinessLayer;

namespace TestCSharp.Pages.Articoli
{
    public partial class CreaArticolo : System.Web.UI.Page
    {

        BLArticolo _blArticolo = new BLArticolo();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BEArticolo articolo = new BEArticolo()
                    {
                        Nome = txtNome.Text
                    };
                    bool result = AggiungiArticolo(articolo);
                    if (result)
                    {
                        Response.Redirect("ListaArticoli.aspx", false);
                    }
                    else
                    {
                        UtilityPopup.PopupErrore(Page);
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ListaArticoli.aspx", false);
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        private bool AggiungiArticolo(BEArticolo articolo)
        {
            bool result = _blArticolo.AggiungiArticolo(articolo);
            return result;
        }
        
    }
}