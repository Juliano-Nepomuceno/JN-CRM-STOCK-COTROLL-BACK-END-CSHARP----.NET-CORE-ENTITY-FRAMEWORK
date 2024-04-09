using System.ComponentModel.Design;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Data
{
    public class ProductData
    {

    public Guid Id  {get; init;}
    
    public string Name   {get;  set;}
    
    public string Description   {get;  set;}
       
    public DateTime Expirationdate {get; private set;}

    public string Category {get; private set;}

    public string Brand {get; private set;}
     
    public decimal Price {get; private set;}

    public int  Quatity  {get; private set;}

    public string Supplier {get;private set;}

    public bool IsActive  {get; private set;}
    

public ProductData(string name, string description, DateTime expirationdate, string category, string brand, decimal price, int quatity, string supplier){

Id = Guid.NewGuid();
 Name = name;
 Description = description;
 Expirationdate = expirationdate;
 Category = category;
 Brand = brand;
 Price = price;
 Quatity = quatity;
 Supplier =  supplier;
 IsActive = true;
 

}


public void updateProduct(string name, string description,DateTime expirationdate, string category, string brand, decimal price, int quatity, string supplier){
 Name = name;
 Description = description;
 Expirationdate = expirationdate;
 Category = category;
 Brand = brand;
 Price = price;
 Quatity = quatity;
 Supplier =  supplier;

    
}
    public void Disable(){

        IsActive = false;
    }
    


    }
}