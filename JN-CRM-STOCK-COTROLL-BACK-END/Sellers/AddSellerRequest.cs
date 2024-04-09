using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record AddSellerRequest(string Name, int Cpf, string Address, int Phone, decimal Wage, DateTime Admissiondate, string User)
    {
        
    }
}