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
    public partial class ListaArticoli : System.Web.UI.Page
    {
        BLArticolo _blArticolo = new BLArticolo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    RicercaArticoli();
                }
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            try
            {
                RicercaArticoli();
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnResetta_Click(object sender, EventArgs e)
        {
            try
            {
                txtNome.Text = string.Empty;
                RicercaArticoli();
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CreaArticolo.aspx", false);
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                //recupera l'id dal command argument del bottone
                int id = int.Parse(((Button)sender).CommandArgument);
                Session["IdArticolo"] = id;
                Response.Redirect("DettaglioArticolo.aspx", false);
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            try
            {
                //recupera l'id dal command argument del bottone
                int id = int.Parse(((Button)sender).CommandArgument);
                BEArticolo articolo = new BEArticolo()
                {
                    Id = id
                };
                bool result = _blArticolo.CancellaArticolo(articolo);
                if (result)
                {
                    RicercaArticoli();
                }
                else
                {
                    UtilityPopup.PopupErrore(Page);
                }
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }

        }

        private void RicercaArticoli()
        {
            BEArticolo articolo = new BEArticolo()
            {
                Nome = txtNome.Text
            };
            List<BEArticolo> listaArticoli = _blArticolo.RicercaArticoli(articolo);
            BindGvArticoli(listaArticoli);
        }

        private void BindGvArticoli(List<BEArticolo> listaArticoli)
        {
            gvArticoli.DataSource = listaArticoli;
            gvArticoli.DataBind();
        }

    }
}