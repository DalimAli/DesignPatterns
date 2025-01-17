
<h1>
    Facade Design Pattern in C#
</h1>

<h3>
    As per the GOF definition, Facade Design Pattern states
    that you need to provide a unified interface to a set of interfaces in a subsystem.
    The Facade Design Pattern defines
    a higher-level interface that makes the subsystem easier to use.
</h3>

<p>
    The Facade Design Pattern is a structural pattern that provides a simplified interface to a
    complex system of classes, libraries, or frameworks. The primary goal of the Facade pattern is to present a
    clear, simplified, and minimized interface to the external clients while delegating all
    the complex underlying operations to the appropriate classes within the system. The Facade (usually a wrapper)
    class sits on the top of a group of subsystems and allows them to communicate in a unified manner.
</p>

<h2>Understanding Facade Design Pattern in C# with one Real-Time Example:</h2>

<ul>
    <li>Identify Complex Subsystems: First, identify the complex parts of your system that need simplification.
        These could be complex libraries or systems with multiple interacting classes.
    </li>
    <li>Create a Facade Class: Design a facade class that provides a simple interface to the complex subsystems.
    </li>
    <li>Delegate Calls to Subsystems: The facade should delegate the client requests to the appropriate objects
        within the subsystem. The facade should handle all the intricacies and dependencies of the subsystems.</li>
    <li>Client Code Interaction: The client interacts with the system through the facade, simplifying its use of the
        complex subsystems.</li>
</ul>

<p>
    Let us understand the Facade Design Pattern in C# with one Real-Time Example. Please have a look at the
    following diagram for a better understanding.
    Here, we need to design an application to place an order in an E-Commerce Application.
</p>
<img src="images/Facade-Design-Pattern-in-C.webp" alt="" srcset="">
<p>
    As shown in the above image, to place an order first, the Client needs to create an object of the
    Product class and get the product details by calling the GetProductDetails method.
    Then, if everything is fine (i.e. if the Product is available in stock), you need to make the Payment.
    To do this, the Client needs to create an instance of the Payment class and need to call the MakePayment
    method. If Payment is successful, then we need to send the Invoice to the customer and to do so,
    the Client needs to create an instance of the Invoice class and call the SendInvoice method.
    So, to place the order, the Client needs to do the above-mentioned steps in a particular order.
</p>

<h3>
    The Facade Design Pattern in C# is actually an extra class (i.e., a Wrapper class or, you can say, Facade Class)
    that sits at the top of the above classes. Please have a look at the following diagram for a better
    understanding.
</h3>

<img src="images/Facade-Design-Pattern-in-C-with-Examples.webp" alt="" srcset="">

<p>
    So, here, the extra class Order is nothing but the Facade class, which will be responsible for placing the
    order. This class internally creates the instance of the respective classes and calls the methods in a
    particular order. Now, the Client will not call the respective classes and their methods to place the order;
    instead, the Client will call the Order Class, PlaceOrder to method to place an order. The PlaceOrder method
    will internally use the Product, Payment, and Invoice classes to place the order.
</p>

<p>
    <b> Note:</b> The point that you need to remember is the Facade Design Pattern not only decreases the overall
    complexity of the application but also helps to move the unwanted dependencies to one place. Facade deals with
    interfaces, not implementation. The actual implementation is going to be provided by the Subsystems.
</p>

<h3>UML Diagram</h3>

<img src="images/UML-Diagram-of-Facade-Design-Pattern.png" alt="" srcset="">

<p>
    As shown in the above image, three classes are involved in the Facade Design Pattern. They are as follows:
</p>

<ol>
    <li>The <b>Facade Class</b> knows which subsystem classes are responsible for a given request, and then it
        delegates
        the client requests to appropriate subsystem objects.</li>

    <li>The <b>Subsystem Classes</b> implement their respective functionalities assigned to them, and these
        Subsystem
        Classes do not know the Facade class.</li>

    <li>
        The <b>Client Class</b> uses the Façade Class to access the subsystems.
    </li>
</ol>

<h2>Implementing Facade Design Pattern in C#:</h2>

<h3>Step 1: Creating Subsystems</h3>

```c#

// Product Subsystem:
using System;
namespace FacadeDesignPattern
{
    // Subsystem 1
    // The Subsystem can accept requests either from the facade or from the client directly. 
    // In this case, from the Subsystem, the Facade is also a client
    // Facade is not a part of the Subsystem.
    public class Product
    {
        public void GetProductDetails()
        {
            Console.WriteLine("Fetching the Product Details");
        }
    }
}
```

```c#
// Payment Subsystem:
using System;
namespace FacadeDesignPattern
{
    // Subsystem 2
    // The Subsystem can accept requests either from the facade or from the client directly. 
    // In this case, from the Subsystem, the Facade is also a client
    // Facade is not a part of the Subsystem.
    public class Payment
    {
        public void MakePayment()
        {
            Console.WriteLine("Payment Done Successfully");
        }
    }
}
```

```c#
// Invoice Subsystem:
using System;
namespace FacadeDesignPattern
{
    // Subsystem 3
    // The Subsystem can accept requests either from the facade or from the client directly. 
    // In this case, from the Subsystem, the Facade is also a client
    // Facade is not a part of the Subsystem.
    public class Invoice
    {
        public void Sendinvoice()
        {
            Console.WriteLine("Invoice Send Successfully");
        }
    }
}
```

<h3>
    Step 2: Creating the Facade Class
</h3>

```c#
using System;
namespace FacadeDesignPattern
{
    // The Facade class provides a simple interface to the complex logic of one
    // or several subsystems. The Facade delegates the client requests to the
    // appropriate objects within the subsystem. 
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
}
```

<h3>
    Step 3: Client
</h3>

```c#
using System;
namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Client will use the Facade Interface instead of the Subsystems
            Order order = new Order();
            order.PlaceOrder();
            Console.Read();
        }
    }
}
```

<pre>
    Place Order Started
    Fetching the Product Details
    Payment Done Successfully   
    Invoice Send Successfully   
    Order Placed Successfully   
</pre>

<h2>Advantages of Facade Design Pattern:</h2>

<ul>
    <li><span
            ><strong>Simplified Interface:</strong> Offers
            a single, simplified interface to the complex subsystems, making the subsystems easier to use.</span>
    </li>
    <li><span ><strong>Reduced
                Complexity:</strong> Clients interact with a single unified interface rather than directly with the
            complex subsystems, reducing the system’s perceived complexity.</span></li>
    <li><span
            ><strong>Isolation:</strong> Provides a degree
            of isolation from the complex subsystems, which can be beneficial when there are frequent subsystem
            changes.</span></li>
    <li><span ><strong>Improved
                Testability and Maintainability:</strong> Facade can simplify the testing process by limiting the
            interdependencies and focusing on system interfaces.</span></li>
</ul>


<h2>When to use Facade Design Patterns in Real-Time Applications?</h2>
<ul>
    <li><span
            ><strong>Simplifying Complex Systems:</strong>
            When dealing with a complex system or framework with multiple interdependent classes or layers, you want
            to provide a simple interface to these systems. The Facade pattern can encapsulate this complexity
            behind a simple, unified interface.</span></li>
    <li><span
            ><strong>Decoupling Systems:</strong> If you
            want to decouple a system where the components are tightly coupled or interdependent, a facade can
            provide loose coupling by not exposing the internal complexities to the client.</span></li>
    <li><span ><strong>Layered
                Architecture:</strong> A facade can act as an entry point to each layer in multi-layered
            architecture. This is particularly useful in large applications or systems where each layer has
            complexities.</span></li>
    <li><span ><strong>Improved
                Readability and Usability:</strong> When you aim to improve the readability and usability of a
            system. A facade can provide a clear and straightforward way to interact with a complex subsystem,
            making it easier for other developers to understand and use it.</span></li>
    <li><span ><strong>Reducing
                Dependencies:</strong> To reduce external code dependencies on the inner workings of a library or
            framework, thereby shielding the client code from future changes or complexities in the
            subsystem.</span></li>
    <li><span ><strong>Subsystem
                Interface Standardization:</strong> For standardizing the interfaces of subsystems. If different
            subsystems have different interfaces, a facade can provide a uniform interface to all these subsystems,
            making them easier to work with.</span></li>
</ul>

