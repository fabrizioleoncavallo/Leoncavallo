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
    public partial class ListaArticoli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RicercaArticoli();
            }
        }

        private void RicercaArticoli()
        {
            BLArticolo blArticolo = new BLArticolo();
            List<BEArticolo> listaArticoli = new List<BEArticolo>();
            BindGvArticoli(listaArticoli);
        }

        private void BindGvArticoli(List<BEArticolo> listaArticoli)
        {
            gvArticoli.DataSource = listaArticoli;
            gvArticoli.DataBind();
        }

    }
}