using System.ComponentModel.Design;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Data
{
    public class ClientData
    {

    public Guid Id  {get; init;}
    
    public string Name   {get;  set;}
       
    public int Cpf {get; private set;}

    
    public string Address {get; private set;}

    public string Socialnetwork {get; private set;}
     
    public int Phone {get; private set;}

    public int Whatsapp {get; private set;}

    public string  Email {get; private set;}

    public bool IsActive  {get; private set;}
    

public ClientData(string name, int cpf, string address, string socialnetwork, int phone, int whatsapp, string email){

Id = Guid.NewGuid();
 Name = name;
 Cpf = cpf;
 Address = address;
 Socialnetwork = socialnetwork;
 Phone = phone;
 Whatsapp = whatsapp;
 Email = email;
 IsActive = true;
 

}


public void updateClient(string name, int cpf, string address, string socialnetwork, int phone, int whatsapp, string email){
Name = name;
Cpf = cpf;
Address = address;
Socialnetwork = socialnetwork ;
Phone = phone;
Whatsapp = whatsapp;
Email = email;

    
}
    public void Disable(){

        IsActive = false;
    }
    


    }
}