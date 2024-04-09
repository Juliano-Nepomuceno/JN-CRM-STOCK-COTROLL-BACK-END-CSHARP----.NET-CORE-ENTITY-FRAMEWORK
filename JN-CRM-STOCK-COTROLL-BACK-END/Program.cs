using JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext;
using JN_CRM_STOCK_COTROLL_BACK_END.Routes;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContextJnTech>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Client.ClientRoute(app);
Seller.SellerRoute(app);
User.UserRoute(app);
Product.ProductRoute(app);
Sale.SaleRoute(app);


app.Run();
