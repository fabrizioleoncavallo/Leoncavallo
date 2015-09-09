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
    public partial class DettaglioMagazzino : System.Web.UI.Page
    {

        private BLMagazzino _blMagazzino = new BLMagazzino();
        private BEMagazzino _Magazzino
        {
            set
            {
                ViewState["_Magazzino"] = value;
            }
            get
            {
                return ViewState["_Magazzino"] != null ? (BEMagazzino)ViewState["_Magazzino"] : null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Bind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    _Magazzino.Nome = txtNome.Text;
                    _blMagazzino.ModificaMagazzino(_Magazzino);
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

        private void CaricaMagazzino()
        {
            int id = (int)Session["IdMagazzino"];
            if (id > 0)
            {
                BEMagazzino magazzino = new BEMagazzino()
                {
                    Id = id
                };
                _Magazzino = _blMagazzino.DettaglioMagazzino(magazzino);
            }
        }

        private void Bind()
        {
            CaricaMagazzino();
            if (_Magazzino != null)
            {
                txtNome.Text = _Magazzino.Nome;
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