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
    public partial class ListaCausali : System.Web.UI.Page
    {

        private BLCausale _blCausale = new BLCausale();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    RicercaCausali();
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
                RicercaCausali();
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
                RicercaCausali();
            }
            catch (Exception ex)
            {
            }
        }

        private void RicercaCausali()
        {
            BECausale causale = new BECausale()
            {
                Nome = txtNome.Text
            };
            List<BECausale> listaCausali = _blCausale.GetListaCausali(causale);
            BindGvCausali(listaCausali);
        }

        private void BindGvCausali(List<BECausale> listaCausali)
        {
            gvCausali.DataSource = listaCausali;
            gvCausali.DataBind();
        }

    }
}