using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestCSharp.BusinessEntity;
using TestCSharp.BusinessLayer;

namespace TestCSharp.Pages.Magazzini
{
    public partial class DettaglioMagazzino : System.Web.UI.Page
    {

        private BLMagazzino _blMagazzino = new BLMagazzino();
        private BEMagazzino _Magazzino
        {
            set
            {
                ViewState["Magazzino"] = value;
            }
            get
            {
                return ViewState["Magazzino"] != null ? (BEMagazzino)ViewState["Magazzino"] : null;
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
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    _Magazzino.Nome = txtNome.Text;
                    bool result = _blMagazzino.ModificaMagazzino(_Magazzino);
                    if (result)
                    {
                        Response.Redirect("ListaMagazzini.aspx", false);
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
                Response.Redirect("ListaMagazzini.aspx", false);
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
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
            bool result = _blMagazzino.AggiungiMagazzino(magazzino);
            return result;
        }

    }
}