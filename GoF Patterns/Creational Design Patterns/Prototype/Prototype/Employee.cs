namespace Prototype
{
    internal class Employee : Prototype
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address Address { get; set; }

        public Employee(string name, string department, Address address)
        {
            Name = name;
            Department = department;
            Address = address;
        }

        public override Employee Clone()
        {
            var newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Address = new Address(this.Address.Street); 
            return newEmployee;
        }

        public void ShowDetails() => Console.WriteLine($"Name:{this.Name}, Department: {this.Department}, Street: {this.Address.Street}\n");
    }

    internal class Address
    {
        public string Street { get; set; }

        public Address(string street) => Street = street;
    }
}
