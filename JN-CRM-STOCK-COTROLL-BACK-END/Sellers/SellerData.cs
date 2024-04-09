using System.ComponentModel.Design;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Data
{
    public class SellerData
    {

    public Guid Id  {get; init;}
    
    public string Name   {get;  set;}
       
    public int Cpf {get; private set;}

    
    public string Address {get; private set;}

   
     
    public int Phone {get; private set;}

    public decimal Wage {get; private set;}

    public DateTime  Admissiondate {get; private set;}
    
    public string  User {get; private set;}
    

    public bool IsActive  {get; private set;}
    

public SellerData(string name, int cpf, string address, int phone, decimal wage, DateTime admissiondate, string user){

Id = Guid.NewGuid();
 Name = name;
 Cpf = cpf;
 Address = address;
 
 Phone = phone;
  Wage = wage;
  Admissiondate = admissiondate;
  User =  user;

 IsActive = true;
 

}


public void updateSeller(string name, int cpf, string address, int phone, decimal wage, DateTime admissiondate, string user){
Name = name;
Cpf = cpf;
Address = address;
Phone = phone;
Wage = wage;
Admissiondate = admissiondate;
User = user;

    
}
    public void Disable(){

        IsActive = false;
    }
    


    }
}