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
    public partial class DettaglioArticolo : System.Web.UI.Page
    {

        private BLArticolo _blArticolo = new BLArticolo();
        private BLCausale _blCausale = new BLCausale();
        private BLMagazzino _blMagazzino = new BLMagazzino();
        private BEArticolo _Articolo
        {
            set
            {
                ViewState["Articolo"] = value;
            }
            get
            {
                return ViewState["Articolo"] != null ? (BEArticolo)ViewState["Articolo"] : null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Bind();
                    fsAggiungiMovimentazione.Visible = false;
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
                    _Articolo.Nome = txtNome.Text;
                    bool result = _blArticolo.ModificaArticolo(_Articolo);
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

        protected void btnAggiungiMovimentazione_Click(object sender, EventArgs e)
        {
            try
            {
                List<BECausale> listaCausali = _blCausale.RicercaCausali(new BECausale());
                List<BEMagazzino> listaMagazzini = _blMagazzino.RicercaMagazzini(new BEMagazzino());
                BindDdlCausali(listaCausali);
                BindDdlMagazziniPartenza(listaMagazzini);
                BindDdlMagazziniDestinazione(listaMagazzini);
                fsAggiungiMovimentazione.Visible = true;
            }
            catch (Exception ex)
            {
                UtilityPopup.PopupErrore(Page, ex.Message);
            }
        }

        protected void btnSalvaMovimentazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BEMagazzino magazzinoPartenza = new BEMagazzino()
                    {
                        Id = Convert.ToInt32(ddlMagazzinoPartenza.SelectedValue),
                        Nome = ddlMagazzinoPartenza.SelectedItem.Text
                    };
                    BEMagazzino magazzinoDestinazione = new BEMagazzino()
                    {
                        Id = Convert.ToInt32(ddlMagazzinoDestinazione.SelectedValue),
                        Nome = ddlMagazzinoDestinazione.SelectedItem.Text
                    };
                    BECausale causale = new BECausale()
                    {
                        Id = Convert.ToInt32(ddlCausale.SelectedValue),
                        Nome = ddlCausale.SelectedItem.Text
                    };
                    BEMovimentazioneArticolo movimentazione = new BEMovimentazioneArticolo()
                    {
                        MagazzinoPartenza = magazzinoPartenza,
                        MagazzinoDestinazione = magazzinoDestinazione,
                        Causale = causale
                    };
                    bool result = AggiungiMovimentazione(movimentazione);
                    if (result)
                    {
                        Bind();
                        fsAggiungiMovimentazione.Visible = false;
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

        private void CaricaArticolo()
        {
            int id = (int)Session["IdArticolo"];
            if (id > 0)
            {
                BEArticolo articolo = new BEArticolo()
                {
                    Id = id
                };
                _Articolo = _blArticolo.DettaglioArticolo(articolo);
            }
        }

        private void Bind()
        {
            CaricaArticolo();
            if (_Articolo != null)
            {
                txtNome.Text = _Articolo.Nome;
                BindGvMovimentazioni(_Articolo.Movimentazioni);
            }
        }

        private void BindGvMovimentazioni(List<BEMovimentazioneArticolo> listaMovimentazioni)
        {
            gvMovimentazioni.DataSource = listaMovimentazioni;
            gvMovimentazioni.DataBind();
        }

        private bool AggiungiArticolo(BEArticolo articolo)
        {
            bool result = _blArticolo.AggiungiArticolo(articolo);
            return result;
        }

        private void BindDdlCausali(List<BECausale> listaCausali)
        {
            ddlCausale.DataSource = listaCausali;
            ddlCausale.DataTextField = "Nome";
            ddlCausale.DataValueField = "Id";
            ddlCausale.DataBind();
        }

        private void BindDdlMagazziniPartenza(List<BEMagazzino> listaMagazzini)
        {
            ddlMagazzinoPartenza.DataSource = listaMagazzini;
            ddlMagazzinoPartenza.DataTextField = "Nome";
            ddlMagazzinoPartenza.DataValueField = "Id";
            ddlMagazzinoPartenza.DataBind();
        }

        private void BindDdlMagazziniDestinazione(List<BEMagazzino> listaMagazzini)
        {
            ddlMagazzinoDestinazione.DataSource = listaMagazzini;
            ddlMagazzinoDestinazione.DataTextField = "Nome";
            ddlMagazzinoDestinazione.DataValueField = "Id";
            ddlMagazzinoDestinazione.DataBind();
        }

        private bool AggiungiMovimentazione(BEMovimentazioneArticolo movimentazione)
        {
            bool result = _blArticolo.AggiungiMovimentazione(_Articolo, movimentazione);
            return result;
        }

    }
}