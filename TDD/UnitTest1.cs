namespace TDD
{
    using Xunit;
    using clases;

    public class CoffeeMachineTest
    {
        private CoffeeMachine coffeeMachine;

        public CoffeeMachineTest()
        {
            coffeeMachine = new CoffeeMachine();
            coffeeMachine.AddCups(5, 5, 5);  // 5 vasos de cada tama�o
            coffeeMachine.AddCoffee(20);  // 20 oz de caf�
            coffeeMachine.AddSugar(10);   // 10 unidades de az�car
        }

        [Fact]
        public void TestGetSmallCup()
        {
            var cup = coffeeMachine.GetTipoVaso("small");
            Assert.Equal(3, cup.Size);
            Assert.Equal(5, cup.Quantity);
        }

        [Fact]
        public void TestDispenseCoffeeSuccessful()
        {
            var result = coffeeMachine.GetVasoDeCafe("medium", 1, 2);
            Assert.Equal("Dispensing 1 medium cup(s) of coffee with 2 sugar units.", result);
        }

        [Fact]
        public void TestErrorNoCups()
        {
            coffeeMachine.GetVasoDeCafe("small", 5, 1);  // Usa todos los vasos peque�os
            var result = coffeeMachine.GetVasoDeCafe("small", 1, 1);
            Assert.Equal("Error: No more cups available.", result);
        }

        [Fact]
        public void TestErrorNoCoffee()
        {
            coffeeMachine.GetVasoDeCafe("large", 3, 0);  // Usa gran parte del caf�
            var result = coffeeMachine.GetVasoDeCafe("large", 1, 0);
            Assert.Equal("Error: Not enough coffee available.", result);
        }

        [Fact]
        public void TestErrorNoSugar()
        {
            coffeeMachine.GetVasoDeCafe("medium", 2, 5);  // Usa gran parte del az�car
            var result = coffeeMachine.GetVasoDeCafe("medium", 1, 6);
            Assert.Equal("Error: Not enough sugar available.", result);
        }
    }

}