<h1>Adapter Design Pattern</h1>

<h3><b>The Adapter Design Pattern</b> is a structural pattern that allows objects with incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces. This pattern is useful when you want to use existing classes, but their interfaces do not match the one you need.</h3>

<p>
<b>Usage examples:</b> The Adapter Design Pattern acts as a bridge between two incompatible objects. Let’s say the first object is A and the second object is B. Object A wants to consume some of object B’s services. However, these two objects are incompatible and cannot communicate directly. In this case, the Adapter will come into the picture and act as a middleman or bridge between objects A and B. Now, object A will call the Adapter, and the Adapter will do the necessary transformations or conversions, and then it will call object B.
</p>


<p>
<b>Identification:</b> Decorator can be recognized by creation methods or constructors that accept objects of the same class or interface as a current class.</p>

<h3>Again, the Adapter Design Pattern in C# can be implemented in two ways. They are as follows.</h3>

<ul>
 <li>Object Adapter Pattern</li>
 <li>Class Adapter Pattern</li>
</ul>
<h3>Implementation of Object Adapter Design Pattern in C#:</h3>

<h4>Implementation of Object Adapter Design Pattern in C#:</h4>

<h4>Step 1: Creating Employee Class</h4>

```c#

namespace AdapterDesignPattern
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string designation, decimal salary)
        {
            ID = id;
            Name = name;
            Designation = designation;
            Salary = salary; 
        }
    }
}

```

<h4>Step2: Creating Adaptee</h4>


```c#

using System;
using System.Collections.Generic;
namespace AdapterDesignPattern
{
    // The Adaptee contains some functionality that is required by the client.
    // But this interface is not compatible with the client code.
    public class ThirdPartyBillingSystem
    {
        //ThirdPartyBillingSystem accepts employee's information as a List to process each employee's salary
        public void ProcessSalary(List<Employee> listEmployee)
        {
            foreach (Employee employee in listEmployee)
            {
                Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
            }
        }
    }
}

```

<h4>Step3: Creating ITarget interface</h4>

```c#
namespace AdapterDesignPattern
{
    // The ITarget defines the domain-specific interface used by the client code.
    // This interface needs to be implemented by the Adapter.
    // The client can only see this interface i.e. the class which implements the ITarget interface.
    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }
}

```

<h4>Step4: Create an Adapter</h4>

```c#
using System;
using System.Collections.Generic;
namespace AdapterDesignPattern
{
    // This is the class that makes two incompatible interfaces or systems work together.
    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    public class EmployeeAdapter : ITarget
    {
        //To use Object Adapter Design Pattern, we need to create an object of ThirdPartyBillingSystem
        ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

        //The following will accept the employees in the form of string array
        //Then convert the employee string array to List of Employees
        //After conversation, it will call the Adaptee's Method to Process the Salaries
        public void ProcessCompanySalary(string[,] employeesArray)
        {
            string Id = null;
            string Name = null;
            string Designation = null;
            string Salary = null;

            List<Employee> listEmployee = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Id = employeesArray[i, j];
                    }
                    else if (j == 1)
                    {
                        Name = employeesArray[i, j];
                    }
                    else if (j == 2)
                    {
                        Designation = employeesArray[i, j];
                    }
                    else
                    {
                        Salary = employeesArray[i, j];
                    }
                }

                listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Designation, Convert.ToDecimal(Salary)));
            }

            Console.WriteLine("Adapter converted Array of Employee to List of Employee");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employee salary\n");
            thirdPartyBillingSystem.ProcessSalary(listEmployee);
        }
    }
}

```

<h4>Step5: Client</h4>

```c#
using System;
namespace AdapterDesignPattern
{
    //Client 
    //The Client is Incompatible with ThirdPartyBillingSystem 
    class Program
    {
        static void Main(string[] args)
        {
            //Storing the Employees Data in a String Array
            string[,] employeesArray = new string[5, 4]
            {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
            };

            //The EmployeeAdapter Makes it possible to work with Two Incompatible Interfaces
            Console.WriteLine("HR system passes employee string array to Adapter\n");
            ITarget target = new EmployeeAdapter();
            target.ProcessCompanySalary(employeesArray);

            Console.Read();
        }
    }
}

```

<pre>
HR system passes employee string array to Adapter

Adapter converted Array of Employee to List of Employee
Then delegate to the ThirdPartyBillingSystem for processing the employee salary

Rs.10000 Salary Credited to John Account
Rs.20000 Salary Credited to Smith Account
Rs.30000 Salary Credited to Dev Account
Rs.40000 Salary Credited to Pam Account
Rs.50000 Salary Credited to Sara Account
</pre>

<img src="https://dotnettutorials.net/wp-content/uploads/2019/10/Object-Adapter-Design-Pattern-in-C-with-Examples.png?ezimgfmt=ng:webp/ngcb8">
</img>
<ol>
<li><strong>Client:</strong> The Client class can only see the ITarget interface, i.e., the class that implements the ITarget interface, i.e., the Adapter (in our example, it is the EmployeeAdapter). Using that Adapter (EmployeeAdapter) object, the client will communicate with the Adaptee, which is incompatible with the client.
</li>
<li style="text-align:justify">
<strong>ITarget:</strong>
<> This is going to be an interface that needs to be implemented by the Adapter. The client can only see this interface, i.e., the class which implements this interface.</li>

<li> <strong> Adapter:</strong>This class makes two incompatible interfaces or systems work together. The Adapter class implements the ITrager interface and provides the implementation for the interface method. This class is also composed of the Adaptee, i.e., it has a reference to the Adaptee object as we are using the Object Adapter Design Pattern. In our example, the EmployeeAdapter class
&nbsp;implements the ITarget Interface and provides implementations to the ProcessCompanySalary method of the ITarget Interface. This class also has a reference to the ThirdPartyBillingSystem object.</li>

<li><strong> Adaptee:</strong>This class contains the client’s required functionality but is incompatible with the existing client code. So, it requires some adaptation or transformation before the client can use it. It means the client will call the Adapter, and the Adapter will do the required conversions and then make a call to the Adaptee.</li>
</ol>

<h3>Understanding Class Adapter Design Pattern in C#:</h3>
<p>This is another approach to implementing the Adapter Design Pattern in C#. In this approach, the Adapter calls will implement the ITarget interface and inherit from the Adaptee class. That means the Adapter class will now be a child of the Adaptee class. So, instead of creating a reference variable of Adaptee to call the Adaptee method, it can call that method directly as it is available via inheritance. Before implementing the same example using the Class Adapter Design Pattern, let us first understand the class diagram of the Class Adapter Design Pattern. Please have a look at the following image.</p>

<img src="https://dotnettutorials.net/wp-content/uploads/2019/10/UML-Diagram-of-Class-Adapter-Design-Pattern-in-C.png?ezimgfmt=ng:webp/ngcb8"></src>


<p>So, please modify the EmployeeAdapter class as shown below to use the Class Adapter Design Pattern in C#. The EmployeeAdapter class is now inherited from the Adaptee, i.e., the ThirdPartyBillingSystem class, and implements the ITarget interface.</p>

```C#
using System;
using System.Collections.Generic;
namespace AdapterDesignPattern
{
    // This is the class that makes two incompatible interfaces or systems work together.
    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    // To use Class Adapter Pattern, we need to inherit the Adapter class from the Adaptee class
    public class EmployeeAdapter : ThirdPartyBillingSystem, ITarget
    {
        //The following will accept the employees in the form of string array
        //Then convert the employee string array to List of Employees
        //After conversation, it will call the Adaptee's Method to Process the Salaries
        public void ProcessCompanySalary(string[,] employeesArray)
        {
            string Id = null;
            string Name = null;
            string Designation = null;
            string Salary = null;

            List<Employee> listEmployee = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Id = employeesArray[i, j];
                    }
                    else if (j == 1)
                    {
                        Name = employeesArray[i, j];
                    }
                    else if (j == 2)
                    {
                        Designation = employeesArray[i, j];
                    }
                    else
                    {
                        Salary = employeesArray[i, j];
                    }
                }

                listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Designation, Convert.ToDecimal(Salary)));
            }

            Console.WriteLine("Adapter converted Array of Employee to List of Employee");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employee salary\n");
            //Call the Base Class ProcessSalary Method to Process the Salary
            ProcessSalary(listEmployee);
        }
    }
}

```

<pre>
HR system passes employee string array to Adapter

Adapter converted Array of Employee to List of Employee
Then delegate to the ThirdPartyBillingSystem for processing the employee salary

Rs.10000 Salary Credited to John Account
Rs.20000 Salary Credited to Smith Account
Rs.30000 Salary Credited to Dev Account
Rs.40000 Salary Credited to Pam Account
Rs.50000 Salary Credited to Sara Account
</pre>

<h3>When to use the Object Adapter Pattern and Class Adapter Pattern in C#?</h3>
<p>
It is completely based on the situation. For example, if you have a Java class and want to make it compatible with the dot net class, then you need to use the Object Adapter Design Pattern because it is not possible to make the inheritance. On the other hand, if both the classes are within the same project and using the same programming language, and if inheritance is possible. then you need to go for the Class Adapter Design Pattern.</p>

<h3>When to use the Adapter Design Pattern in Real-Time Applications?</h3>
<p>The Adapter Design Pattern in C# is particularly useful in the following scenarios:</p>

<ul>
<li><b>Integration with Third-party or Legacy Systems:</b> When your application needs to interact with an external system or a legacy system, and the interfaces of the external systems are not compatible with your application’s interfaces.</li>
<li><b>Reusing Existing Code:</b> If you have existing classes with functionality that you need to use, but their interfaces don’t match the ones your system currently uses, an adapter can bridge this gap.</li>
<li><b>Creating a Common Interface for Different Classes:</b> When you have several classes with different interfaces but want to treat them uniformly through a common interface.</li>
<li><b>Supporting Multiple Data Sources:</b> When your application needs to handle data from different sources (like databases, file systems, web services) but wants to process them in a uniform manner.</li>
<li><b>Supporting Multiple Data Sources:</b> When your application needs to handle data from different sources (like databases, file systems, web services) but wants to process them in a uniform manner.</li>
<li><b>Providing Backward Compatibility:</b> When updating an application or library, adapters can be used to maintain backward compatibility with the old versions of APIs or data models.</li>
<li><b>Cross-Platform Compatibility:</b> In scenarios where you need to provide support for different platforms or environments while keeping the rest of the application code consistent.</li>
</ul>

<h3>TO READ MORE</h3>
<ul>

<li><a href="https://dotnettutorials.net/lesson/adapter-design-pattern/">Dot Net Tutorials</a></li>
</ul>