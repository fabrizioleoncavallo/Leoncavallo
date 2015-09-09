using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestCSharp.BusinessEntity;
using TestCSharp.BusinessLayer;

namespace TestCSharp.Pages
{
    public partial class ListaMagazzini : System.Web.UI.Page
    {

        BLMagazzino _blMagazzino = new BLMagazzino();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    RicercaMagazzini();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            try
            {
                RicercaMagazzini();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnResetta_Click(object sender, EventArgs e)
        {
            try
            {
                txtNome.Text = string.Empty;
                RicercaMagazzini();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CreaMagazzino.aspx", false);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDettaglio_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);
                Session["IdMagazzino"] = id;
                Response.Redirect("DettaglioMagazzino.aspx", false);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);
                BLMagazzino blMagazzino = new BLMagazzino();
                BEMagazzino magazzino = new BEMagazzino()
                {
                    Id = id
                };
                blMagazzino.CancellaMagazzino(magazzino);
                RicercaMagazzini();
            }
            catch (Exception ex)
            {

            }

        }

        private void RicercaMagazzini()
        {
            BEMagazzino magazzino = new BEMagazzino()
            {
                Nome = txtNome.Text
            };
            List<BEMagazzino> listaMagazzini = _blMagazzino.RicercaMagazzini(magazzino);
            BindGvMagazzini(listaMagazzini);
        }

        private void BindGvMagazzini(List<BEMagazzino> listaMagazzini)
        {
            gvMagazzini.DataSource = listaMagazzini;
            gvMagazzini.DataBind();
        }

    }
}