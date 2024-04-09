using System.ComponentModel.Design;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Data
{
    public class UserData
    {

    public Guid Id  {get; init;}
    
    public string Name   {get;  set;}

    public string Username {get;set;}
       
    public int Password {get; private set;}

     
    public bool IsActive  {get; private set;}
    

public UserData(string name, string username, int password){

Id = Guid.NewGuid();
 Name = name;
 Username = username;
 Password = password;

 IsActive = true;
 

}


public void updateUser(string name, string username, int password ){
Name = name;
Username = username;
Password = password;
   
}
    public void Disable(){

        IsActive = false;
    }
    


    }
}