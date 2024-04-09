using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Record;
using Microsoft.EntityFrameworkCore;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Routes
{
    public static class User
    {
     public static void UserRoute(WebApplication app)
     {
                
       app.MapGet("Users", async (DbContextJnTech cotext) =>{
         
         var UsersDb = await cotext.UsersData
         .Where(users => users.IsActive)
         .ToListAsync();
         
         return UsersDb;
         });

       
       app.MapPost( "users", async ( AddUserRequest request, DbContextJnTech context)=>{

          bool isExist = await context.UsersData.AnyAsync(Userdb => Userdb.Username == request.Username); 
          if (isExist) 
            return Results.Conflict("Já existe na base de dados um Usuario com este Username "+ request.Username);
          
          var newuser = new UserData(request.Name, request.Username,request.Password);
          await context.UsersData.AddAsync(newuser);
          context.SaveChangesAsync();
          return Results.Ok(newuser);
       }
);
       app.MapPut("/users/{id:guid}",async( Guid id, UpdateUserRequest request, DbContextJnTech context)=>
       {


var Users = await context.UsersData.SingleOrDefaultAsync(Users => Users.Id == id );


if (Users == null)
return Results.NotFound();
Users.updateUser(request.Name,request.Username,request.Password);
 await context.SaveChangesAsync(); 
return Results.Ok();


       }

       
       );
 
      app.MapDelete("/users/{id:guid}", async( Guid id, DbContextJnTech context)=> {
       var users = await context.UsersData.SingleOrDefaultAsync(users => users.Id == id);

      if (users == null)
      return Results.NotFound();
      users.Disable();

      await context.SaveChangesAsync();
      return Results.Ok();
       }
       
       );
     
     }   

     
    }
}