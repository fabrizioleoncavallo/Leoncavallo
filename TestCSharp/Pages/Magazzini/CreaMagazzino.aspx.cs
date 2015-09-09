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
    public partial class CreaMagazzino : System.Web.UI.Page
    {

        BLMagazzino _blMagazzino = new BLMagazzino();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BEMagazzino magazzino = new BEMagazzino()
                    {
                        Nome = txtNome.Text
                    };
                    AggiungiMagazzino(magazzino);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertResult", "alert('Operazione eseguita con successo');", true);
                    Response.Redirect("ListaMagazzini.aspx", false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ListaMagazzini.aspx", false);
            }
            catch (Exception ex)
            {
            }
        }

        private bool AggiungiMagazzino(BEMagazzino magazzino)
        {
            BLMagazzino blMagazzino = new BLMagazzino();
            bool result = blMagazzino.AggiungiMagazzino(magazzino);
            return result;
        }

    }
}