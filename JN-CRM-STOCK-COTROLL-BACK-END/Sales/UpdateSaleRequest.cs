namespace JN_CRM_STOCK_COTROLL_BACK_END.Record
{
    public record UpdateSaleRequest(DateTime Date, string Seller, string Client, string Products, decimal Totalvalue, string Address, string Paymentmethod)
    {
        
    }
}