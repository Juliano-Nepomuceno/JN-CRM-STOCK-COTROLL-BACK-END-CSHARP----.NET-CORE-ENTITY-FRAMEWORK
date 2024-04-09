using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record AddUserRequest(string Name, string Username, int Password)
    {
        
    }
}