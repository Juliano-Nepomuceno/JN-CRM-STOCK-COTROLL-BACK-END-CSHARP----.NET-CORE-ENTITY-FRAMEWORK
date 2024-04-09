using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Record;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Routes
{
    public static class Seller
    {
     public static void SellerRoute(WebApplication app)
     {
         //var routeClient app.MapGroup = app.MapGroup("clients");

         
       
       app.MapGet("Sellers", async (DbContextJnTech cotext) =>{
         var SellerDb = await cotext.SellersData
         .Where(sellers => sellers.IsActive)
         .ToListAsync();
         
         return SellerDb;

        
         });

       
       app.MapPost( "sellers", async ( AddSellerRequest request, DbContextJnTech context)=>{

          bool isExist = await context.SellersData.AnyAsync(Sellerdb => Sellerdb.Cpf == request.Cpf); 
          if (isExist) 
            return Results.Conflict("Já existe na base de dados um Vendedor com este CPF "+ request.Cpf);
          
          var newseller = new SellerData(request.Name, request.Cpf,request.Address,request.Phone, request.Wage, request.Admissiondate, request.User);
          await context.SellersData.AddAsync(newseller);
           context.SaveChangesAsync();
          return Results.Ok(newseller);
       }
);
       app.MapPut("/sellers/{id:guid}",async( Guid id, UpdateSellerRequest request, DbContextJnTech context)=>
       {


var Sellers = await context.SellersData.SingleOrDefaultAsync(Sellers => Sellers.Id == id );


if (Sellers == null)
return Results.NotFound();
Sellers.updateSeller(request.Name,request.Cpf, request.Address, request.Phone, request.Wage,request.Admissiondate, request.User);
 await context.SaveChangesAsync(); 
return Results.Ok();


       }

       
       );
 
      app.MapDelete("/sellers/{id:guid}", async( Guid id, DbContextJnTech context)=> {
       var sellers = await context.SellersData.SingleOrDefaultAsync(sellers => sellers.Id == id);

      if (sellers == null)
      return Results.NotFound();
      sellers.Disable();

      await context.SaveChangesAsync();
      return Results.Ok();
       }
       
       );
     
     }   

     
    }
}