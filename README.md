```csharp
#region Q1 Overloading, Overriding, and Binding

// a) Method Overloading:
// Same method name with different parameters.

// Method Overriding:
// A derived class provides a new implementation
// for a virtual method using override.

// b) Static Binding:
// The method call is decided at compile time.

// Dynamic Binding:
// The method call is decided at runtime.

#endregion


#region Q2 Sealed Classes and Methods

// a) Sealed Class:
// A sealed class cannot be inherited.

// Example:
// sealed class Animal
// {
// }

// b) Sealed Class:
// Prevents inheritance.

// Sealed Method:
// Prevents further overriding.

// c) Can a sealed method be overridden?
// No, because sealed prevents further overriding.

#endregion
```
```csharp
#region Shipment

public class Shipment
{
    public string TrackingCode { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public double DeliveryFee { get; set; }
    public string Destination { get; set; }

    public virtual double EstimatedCost
    {
        get
        {
            return Weight * DeliveryFee;
        }
    }

    public void UpdateWeight(double weight)
    {
        Weight = weight;
    }

    public void UpdateWeight(double weight, double extraPackingWeight)
    {
        Weight = weight + extraPackingWeight;
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Destination: " + Destination);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
}

#endregion
```
#region Shipment

public class Shipment
{
    public string TrackingCode { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public double DeliveryFee { get; set; }
    public string Destination { get; set; }

    public Shipment(string trackingCode, string description, double weight,
                    double deliveryFee, string destination)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;
    }

    public virtual double EstimatedCost
    {
        get
        {
            return Weight * DeliveryFee;
        }
    }

    public void UpdateWeight(double weight)
    {
        Weight = weight;
    }

    public void UpdateWeight(double weight, double extraPackingWeight)
    {
        Weight = weight + extraPackingWeight;
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Destination: " + Destination);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
}

#endregion


#region StandardShipment

public class StandardShipment : Shipment
{
    public StandardShipment(string trackingCode, string description,
                            double weight, double deliveryFee,
                            string destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
    }

    public override void PrintShipment()
    {
        base.PrintShipment();
    }
}

#endregion


#region ExpressShipment

public class ExpressShipment : Shipment
{
    public double ExtraFee { get; set; }

    public ExpressShipment(string trackingCode, string description,
                           double weight, double deliveryFee,
                           string destination, double extraFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        ExtraFee = extraFee;
    }

    public override double EstimatedCost
    {
        get
        {
            return base.EstimatedCost + ExtraFee;
        }
    }

    public override void PrintShipment()
    {
        base.PrintShipment();
        Console.WriteLine("Extra Fee: " + ExtraFee);
    }
}

#endregion


#region InternationalShipment

public class InternationalShipment : Shipment
{
    public double CustomsFee { get; set; }

    public InternationalShipment(string trackingCode, string description,
                                 double weight, double deliveryFee,
                                 string destination, double customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        CustomsFee = customsFee;
    }

    public override double EstimatedCost
    {
        get
        {
            return base.EstimatedCost + CustomsFee;
        }
    }

    public override void PrintShipment()
    {
        base.PrintShipment();
        Console.WriteLine("Customs Fee: " + CustomsFee);
    }

    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine("Customs Report");
    }
}

#endregion


#region PriorityInternationalShipment

public class PriorityInternationalShipment : InternationalShipment
{
    public PriorityInternationalShipment(string trackingCode, string description,
                                         double weight, double deliveryFee,
                                         string destination, double customsFee)
        : base(trackingCode, description, weight, deliveryFee,
               destination, customsFee)
    {
    }

    public sealed override void GenerateCustomsReport()
    {
        Console.WriteLine("Priority Customs Report");
    }
}

#endregion


#region CompletedShipment

public sealed class CompletedShipment : Shipment
{
    public CompletedShipment(string trackingCode, string description,
                             double weight, double deliveryFee,
                             string destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
    }
}

#endregion
#region StandardShipment

public class StandardShipment : Shipment
{
    public StandardShipment(string trackingCode, string description,
        double weight, double deliveryFee, string destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
    }

    public override double EstimatedCost
    {
        get
        {
            return base.EstimatedCost;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
}

#endregion

#region ExpressShipment

public class ExpressShipment : Shipment
{
    public double ExtraFee { get; set; }

    public ExpressShipment(string trackingCode, string description,
        double weight, double deliveryFee, string destination,
        double extraFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        ExtraFee = extraFee;
    }

    public override double EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("Extra Fee: " + ExtraFee);
    }
}

#endregion

#region InternationalShipment

public class InternationalShipment : Shipment
{
    public string DestinationCountry { get; set; }
    public double CustomsFee { get; set; }

    public InternationalShipment(string trackingCode, string description,
        double weight, double deliveryFee, string destination,
        string destinationCountry, double customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }

    public override double EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + CustomsFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("Destination Country: " + DestinationCountry);
        Console.WriteLine("Customs Fee: " + CustomsFee);
    }
}

#endregion
