using System.ComponentModel.Design;
using JN_CRM_STOCK_COTROLL_BACK_END.Routes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Data
{
    public class SaleData
    {

    public Guid Id  {get; init;}
    public DateTime Date   {get;  set;}
    public string Seller   {get;  set;}
    public string Client {get; private set;}
    public string Products {get; private set;}
    public decimal Totalvalue {get; private set;}
    public string Address {get; private set;}
    public string Paymentmethod {get; private set;}
    public bool IsActive  {get; private set;}
    

public SaleData(DateTime date, string seller, string client, string products, decimal totalvalue, string address, string paymentmethod){

Id = Guid.NewGuid();
 Date = date;
 Seller = seller;
 Client  = client;
 Products = products;
 Totalvalue = totalvalue;
 Address = address;
 Paymentmethod = paymentmethod;
 IsActive = true;
 

}


public void updateSale(DateTime date, string seller, string client, string products, decimal totalvalue, string address, string paymentmethod){
Date = date;
 Seller = seller;
 Client  = client;
 Products = products;
 Totalvalue = totalvalue;
 Address = address;
 Paymentmethod = paymentmethod;

    
}
    public void Disable(){

        IsActive = false;
    }
    


    }
}