public class OrderDC
{
    public int Starters { get; set; }
    public int Mains { get; set; }
    public int Drinks { get; set; }
    public string OrderTime { get; set; }
}

public class BillDC
{
    public double  Price { get; set; }
    public double ServiceCharge { get; set; }
    public double Total { get; set; }
}
