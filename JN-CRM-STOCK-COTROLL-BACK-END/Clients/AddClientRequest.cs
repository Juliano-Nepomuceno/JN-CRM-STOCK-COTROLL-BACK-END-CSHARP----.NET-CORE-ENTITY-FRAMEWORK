using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record AddClientRequest(string Name, int Cpf, string Address, string Socialnetwork, int Phone, int Whatsapp, string Email)
    {
        
    }
}