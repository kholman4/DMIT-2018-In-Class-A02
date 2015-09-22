using System;
using eRestaurant.Framework.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eRestaurant.Framework.BLL;

public partial class Sandbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var controller = new TempController();
            var data = controller.ListMenuCategories();
            //Hook up the data to the GridView
            MenuCategoryGrid.DataSource = data;
            MenuCategoryGrid.DataBind();
        }
    }
}