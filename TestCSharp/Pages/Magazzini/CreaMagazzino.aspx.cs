﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestCSharp.BusinessEntity;
using TestCSharp.BusinessLayer;

namespace TestCSharp.Pages.Magazzini
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
                    bool result = AggiungiMagazzino(magazzino);
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

        private bool AggiungiMagazzino(BEMagazzino magazzino)
        {
            bool result = _blMagazzino.AggiungiMagazzino(magazzino);
            return result;
        }

    }
}