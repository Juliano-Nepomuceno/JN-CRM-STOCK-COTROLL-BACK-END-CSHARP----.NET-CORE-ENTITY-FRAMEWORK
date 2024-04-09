using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record AddSaleRequest(DateTime Date, string Seller, string Client, string Products, decimal Totalvalue, string Address, string Paymentmethod)
    {
        
    }
}