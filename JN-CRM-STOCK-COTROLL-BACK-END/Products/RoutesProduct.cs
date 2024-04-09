using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Record;
using Microsoft.EntityFrameworkCore;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Routes
{
    public static class Product
    {
     public static void ProductRoute(WebApplication app)
     {
       

         
       
       app.MapGet("products", async (DbContextJnTech cotext) =>{
         
         var ProductsDb = await cotext.ProductsData
         .Where(products => products.IsActive)
         .ToListAsync();
         
         return ProductsDb;
         });

        
       app.MapPost( "products", async ( AddProductRequest request, DbContextJnTech context)=>{

          bool isExist = await context.ProductsData.AnyAsync(Productsdb => Productsdb.Name == request.Name); 
          if (isExist) 
            return Results.Conflict("Já existe na base de dados um Produto com este Nome "+ request.Name);
          
          var newproduct = new ProductData(request.Name,request.Description, request.Expirationdate,request.Category,request.Brand,request.Price, request.Quatity, request.Supplier);
          await context.ProductsData.AddAsync(newproduct);
          context.SaveChangesAsync();
          return Results.Ok(newproduct);
       }
);
       app.MapPut("/products/{id:guid}",async( Guid id, UpdateProductRequest request, DbContextJnTech context)=>
       {


var Products = await context.ProductsData.SingleOrDefaultAsync(Products => Products.Id == id );


if (Products == null)
return Results.NotFound();
Products.updateProduct(request.Name, request.Description, request.Expirationdate,request.Category,request.Brand,request.Price, request.Quatity, request.Supplier);
 await context.SaveChangesAsync(); 
return Results.Ok();


       }

       
       );
 
      app.MapDelete("/products/{id:guid}", async( Guid id, DbContextJnTech context)=> {
       var products = await context.ProductsData.SingleOrDefaultAsync(products => products.Id == id);

      if (products == null)
      return Results.NotFound();
      products.Disable();

      await context.SaveChangesAsync();
      return Results.Ok();
       }
       
       );
     
     }   

     
    }
}