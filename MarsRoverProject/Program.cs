namespace MarsRoverProject
{
    using System;
    using MarsRoverBLL;
    using MarsRoverBLL.Interface;
    class Program
    {
        static void Main(string[] args)
        {

            IPlateau plateau = new Plateau(5, 5);
            IRover rover = new Rover(1, 2, Direction.N, plateau);
            IRover rover2 = new Rover(3, 3, Direction.E, plateau);
            rover.Move("LMLMLMLMM");
            rover2.Move("MMRMMRMRRM");
            Console.WriteLine(rover.toString());
            Console.WriteLine(rover2.toString());
            Console.ReadKey();
        }
    }
}
