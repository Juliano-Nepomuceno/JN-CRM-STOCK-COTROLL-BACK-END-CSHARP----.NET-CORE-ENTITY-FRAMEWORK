using Microsoft.VisualBasic;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record UpdateProductRequest(string Name,string Description, DateTime Expirationdate, string Category, string Brand, decimal Price, int Quatity, string Supplier )
    {
        
    }
}