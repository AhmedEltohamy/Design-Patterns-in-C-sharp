using Simple_Factory;

try
{
    CreditCardFactory.GetCreditCard("Titanium").Details();
    Console.WriteLine();

    CreditCardFactory.GetCreditCard("Platinum").Details();
    Console.WriteLine();

    CreditCardFactory.GetCreditCard("MoneyBack").Details();
    Console.WriteLine();

    CreditCardFactory.GetCreditCard("Prime").Details();
}
catch (Exception)
{
    Console.WriteLine("\n!!! Un Supported Card Type\n");
}
