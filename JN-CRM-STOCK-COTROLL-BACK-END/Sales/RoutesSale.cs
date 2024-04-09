using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Record;
using Microsoft.EntityFrameworkCore;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Routes
{
    public static class Sale
    {
     public static void SaleRoute(WebApplication app)
     {
        

         
       
       app.MapGet("sales", async (DbContextJnTech cotext) =>{
         
         var SalesDb = await cotext.SalesData
         .Where(sales => sales.IsActive)
         .ToListAsync();
         
         return SalesDb;
         });

        
       app.MapPost( "sales", async ( AddSaleRequest request, DbContextJnTech context)=>{

          
          var newsale = new SaleData(request.Date, request.Seller,request.Client,request.Products,request.Totalvalue, request.Address, request.Paymentmethod);
          await context.SalesData.AddAsync(newsale);
          context.SaveChangesAsync();
          return Results.Ok(newsale);
       }
);
       app.MapPut("/sales/{id:guid}",async( Guid id, UpdateSaleRequest request, DbContextJnTech context)=>
       {


var Sales = await context.SalesData.SingleOrDefaultAsync(Sales => Sales.Id == id );


if (Sales == null)
return Results.NotFound();
Sales.updateSale(request.Date, request.Seller,request.Client,request.Products,request.Totalvalue, request.Address, request.Paymentmethod);
 await context.SaveChangesAsync(); 
return Results.Ok();


       }

       
       );
 
      app.MapDelete("/sales/{id:guid}", async( Guid id, DbContextJnTech context)=> {
       var Sales = await context.SalesData.SingleOrDefaultAsync(sales => sales.Id == id);

      if (Sales == null)
      return Results.NotFound();
      Sales.Disable();

      await context.SaveChangesAsync();
      return Results.Ok();
       }
       
       );
     
     }   

     
    }
}