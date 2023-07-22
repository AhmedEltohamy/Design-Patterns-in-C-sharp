namespace Template_Method.Entities;

internal abstract class CoffeeTemplate
{
    public void PrepareCoffee()
    {
        BoilWater();
        AddMilk();
        AddSugar();
        AddCoffeePowder();
        Console.WriteLine(this.GetType().Name + " is Ready");
    }
    protected abstract void BoilWater();
    protected abstract void AddMilk();
    protected abstract void AddSugar();
    protected abstract void AddCoffeePowder();
}