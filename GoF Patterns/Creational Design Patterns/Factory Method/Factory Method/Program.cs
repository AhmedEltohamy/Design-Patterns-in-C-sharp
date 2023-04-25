using Factory_Method;

CreditCard creditCard;

creditCard = new PlatinumFactory().CreateCard();
creditCard.Details();
Console.WriteLine();


creditCard = new TitaniumFactory().CreateCard();
creditCard.Details();
Console.WriteLine();


creditCard = new MoneyBackFactory().CreateCard();
creditCard.Details();
Console.WriteLine();