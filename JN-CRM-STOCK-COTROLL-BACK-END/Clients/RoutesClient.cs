using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Record;
using Microsoft.EntityFrameworkCore;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Routes
{
    public static class Client
    {
     public static void ClientRoute(WebApplication app)
     {
         //var routeClient app.MapGroup = app.MapGroup("clients");

         
       
       app.MapGet("Clients", async (DbContextJnTech cotext) =>{
         
         var ClientsDb = await cotext.ClientsData
         .Where(clients => clients.IsActive)
         .ToListAsync();
         
         return ClientsDb;
         });

       
       app.MapPost( "clients", async ( AddClientRequest request, DbContextJnTech context)=>{

          bool isExist = await context.ClientsData.AnyAsync(Clientdb => Clientdb.Cpf == request.Cpf); 
          if (isExist) 
            return Results.Conflict("Já existe na base de dados um CLiente com este CPF "+ request.Cpf);
          
          var newclient = new ClientData(request.Name, request.Cpf,request.Address,request.Socialnetwork,request.Phone, request.Whatsapp, request.Email);
          await context.ClientsData.AddAsync(newclient);
          context.SaveChangesAsync();
          return Results.Ok(newclient);
       }
);
       app.MapPut("/clients/{id:guid}",async( Guid id, UpdateClientRequest request, DbContextJnTech context)=>
       {


var Clients = await context.ClientsData.SingleOrDefaultAsync(Clients => Clients.Id == id );


if (Clients == null)
return Results.NotFound();
Clients.updateClient(request.Name,request.Cpf, request.Address,request.Socialnetwork, request.Phone, request.Whatsapp,request.Email);
 await context.SaveChangesAsync(); 
return Results.Ok();


       }

       
       );
 
      app.MapDelete("/clients/{id:guid}", async( Guid id, DbContextJnTech context)=> {
       var clients = await context.ClientsData.SingleOrDefaultAsync(clients => clients.Id == id);

      if (clients == null)
      return Results.NotFound();
      clients.Disable();

      await context.SaveChangesAsync();
      return Results.Ok();
       }
       
       );
     
     }   

     
    }
}