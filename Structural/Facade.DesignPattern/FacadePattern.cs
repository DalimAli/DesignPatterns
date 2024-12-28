namespace FacadePattern;

public class Product
{
    public void GetProductDetails()
    {
        Console.WriteLine("Fetching the Product Details");
    }
}

public class Payment
{
    public void MakePayment()
    {
        Console.WriteLine("Payment Done Successfully");
    }
}

public class Invoice
{
    public void Sendinvoice()
    {
        Console.WriteLine("Invoice Send Successfully");
    }
}

public class Order
{
    public void PlaceOrder()
    {
        Console.WriteLine("Place Order Started");
        //Get the Product Details
        Product product = new Product();
        product.GetProductDetails();
        //Make the Payment
        Payment payment = new Payment();
        payment.MakePayment();
        //Send the Invoice
        Invoice invoice = new Invoice();
        invoice.Sendinvoice();
        Console.WriteLine("Order Placed Successfully");
    }
}
