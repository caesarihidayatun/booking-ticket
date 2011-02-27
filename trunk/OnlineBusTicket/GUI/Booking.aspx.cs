using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using BLL;
using DAL;

public partial class GUI_Booking : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    public void LoadData()
    {
        string from = Request.QueryString["From"].ToString().Trim();
        string to = Request.QueryString["To"].ToString().Trim();
        Router router = BLLRouter.getIDrouter(from, to);
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"].ToString().Trim());
        DateTime toDate = DateTime.Parse(Request.QueryString["toDate"].ToString().Trim());
        ViewState["router"] = from + " - " + to;
        GridView1.DataSource = BLLListBus.getListBusCustomer(fromDate, toDate, router.RouterID, true);
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ListBus  listbus = new ListBus();
            int index =  Convert.ToInt32(e.CommandArgument.ToString());
            
            GridViewRow row = GridView1.Rows[index];
            _listbusID.Value = row.Cells[0].Text;
            
            lbRouterName.Text = ViewState["router"].ToString();
            lbDeparture.Text = row.Cells[2].Text;
            lbArrival.Text = row.Cells[3].Text;
            lbPrice.Text = row.Cells[4].Text;
            MultiView1.ActiveViewIndex++;
        }
    }
    protected override void OnPreRender(EventArgs e)
    {

       
       
        if (MultiView1.ActiveViewIndex == 1)
        {
            int listBusID = int.Parse(_listbusID.Value.ToString());
            ListBus listbus = BLLListBus.getListBusByID(listBusID);           
            Bus bus = BLLBus.getBusByID(listbus.BusPlate);
            Ticket[] ticket = BLLTicket.getTicketByListBusID(listBusID);
            int count = 1;
            if(chkSeat.Items.Count == 0)
            {
            for (int i = 0; i < bus.Seat; i++)
            {
                chkSeat.Items.Add(count.ToString());
                for (int j = 0; j < ticket.Length; j++)
                {

                    if (count == ticket[j].NumberSeat)
                    {
                        chkSeat.Items[i].Selected = true;
                        chkSeat.Items[i].Enabled = false;
                    }
                }
                count++;
            }
            }
        }
        else if (MultiView1.ActiveViewIndex == 2)
        {
               lbRouterName1.Text = lbRouterName.Text;
               lbDeparture2.Text=  lbDeparture.Text ;
               lbArrival2.Text =  lbArrival.Text ;
               lbPrice2.Text = lbPrice.Text;
               ArrayList arrSeat = new ArrayList();
               for (int i = 0; i < chkSeat.Items.Count;i++ )
               {
                   if (chkSeat.Items[i].Selected == true & chkSeat.Items[i].Enabled == false)
                   {
                       int numberSeat = Int32.Parse(chkSeat.Items[i].Text);
                       arrSeat.Add(numberSeat);
                   }
               }
               ViewState["CountSeat"] = arrSeat;

            
        }
        //else if (MultiView1.ActiveViewIndex == 3)
        //{
        //    litCustomerNameStep4.Text = txtcustomername.Text;
        //    litSeatStep4.Text = litSeat.Text;
        //    litPriceStep4.Text = litPrices.Text;
        //}

        base.OnPreRender(e);
    }
    protected void bntNext(object sender, EventArgs e)
    {
        if (MultiView1.ActiveViewIndex == 1)
        {
            MultiView1.ActiveViewIndex++;
        }
        else if (MultiView1.ActiveViewIndex == 2)
        {
            
                MultiView1.ActiveViewIndex++;
            
        }
        if (MultiView1.ActiveViewIndex == 3)
        {
            Promote promote = new Promote();
            string age = (MultiView1.Views[2].FindControl("tbBirthday") as TextBox).Text;
            int age2 = tinhtuoi(age);
            int idPromote = 0;
            ArrayList arrSeart = (ArrayList)ViewState["CountSeat"];
            //kiem tra tuoi
            if (age2<=5) idPromote =1;
                         else if (5<age2 & age2<=12) idPromote =2;
                         else if (12< age2 & age2 <=50) idPromote = 3;
                         else if (50 < age2) idPromote = 4;
            ViewState["promoteID"] = idPromote;
            promote = BLLPromote.getPromoteByID(idPromote);
            lbDiscount.Text = promote.PromoteName.ToString();
            lbCustomer2.Text = tbName.Text;
            lbPromotePrent.Text =promote.Discount.ToString();

            lbNumberSeat.Text = arrSeart.Count.ToString();
            int countTicket = int.Parse(lbNumberSeat.Text);

            string litPrice = (MultiView1.Views[1].FindControl("lbPrice2") as Label).Text;
            float price = float.Parse(litPrice.ToString());
            int discount = int.Parse(lbPromotePrent.Text.ToString());
            float discoutPrent = (price * discount * countTicket) / 100;
            ViewState["totalFare"] = price * countTicket;
            float total = price * countTicket - discoutPrent;
            //litPromote.Text = discoutPrent.ToString();
            lbTotalPrice.Text = total.ToString();
        }
    }
    public int tinhtuoi(string ngaysinh)
    {
        DateTime dob = DateTime.Parse(ngaysinh);//Date of Birth
        DateTime now = DateTime.Now;
        DateTime nextBirthday = dob.AddYears(1);
        TimeSpan time = now - dob;

        return  Convert.ToInt32(time.TotalDays / 365);
    }
    protected void bntSaveOrder(object sender, EventArgs e)
    {
        Account customer = new Account();
        string customerName = (MultiView1.Views[3].FindControl("tbName") as TextBox).Text;
        customer.Birthday = DateTime.Parse((MultiView1.Views[3].FindControl("tbBirthday") as TextBox).Text);
        customer.Phone = (MultiView1.Views[3].FindControl("tbMoble") as TextBox).Text;
        customer.Email = (MultiView1.Views[3].FindControl("tbMail") as TextBox).Text;
        customer.Address = (MultiView1.Views[3].FindControl("tbAdd") as TextBox).Text;
        customer.IdentifyCode = "khong hieu";


        int row = BLLAccount.InsertAccount(customer);
        ArrayList arrSeart = (ArrayList)ViewState["CountSeat"];
        if (row > 0)
        {
            // save ticket
            for (int i = 0; i < arrSeart.Count;i++ )
            {
                Ticket ticket = new Ticket();
                ticket.DateBooking = DateTime.Now;
                ticket.CancelDate = DateTime.Now;
                ticket.ListBusID = int.Parse(_listbusID.Value.ToString());
                ticket.AccountID = row;
                ticket.NumberSeat =Int32.Parse( arrSeart[i].ToString());
                ticket.PromoteID = (int)ViewState["promoteID"];
                ticket.TotalFees = float.Parse(lbTotalPrice.Text);
                ticket.TotalFare = (float)ViewState["totalFare"];
                ticket.Status = "Pending";
                int rows = BLLTicket.InsertTicket(ticket);
            }
        }
        MultiView1.ActiveViewIndex++;
    }
    protected void BackBusSelect(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex--;
    }

}