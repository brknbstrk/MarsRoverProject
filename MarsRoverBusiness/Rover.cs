namespace MarsRoverBusiness
{
    using MarsRoverBusiness.Interface;
    using System;

    public class Rover : IRover
    {
        private int plateauRoverPositionX;
        private int plateauRoverPositionY;
        private Direction direction;
        public IPlateau Plateau { get; set; }
        public Rover(int startX, int startY, Direction _direction, IPlateau _plateau)
        {
            this.plateauRoverPositionX = startX;
            this.plateauRoverPositionY = startY;
            this.direction = _direction;
            this.Plateau = _plateau;
        }
        public void Move(string movesCommand)
        {
            foreach (var command in movesCommand)
            {
                Enum.TryParse<Command>(command.ToString(), out Command result);
                switch (result)
                {
                    case Command.L:
                        TurnLeft();
                        break;
                    case Command.M:
                        TurnLeft();
                        break;
                    case Command.R:
                        TurnRight();
                        break;
                }
                RangeControl();
            }
        }
        private void TurnLeft()
        {
            switch (direction)
            {
                case Direction.E:
                    this.direction = Direction.N;
                    break;
                case Direction.W:
                    this.direction = Direction.S;
                    break;
                case Direction.N:
                    this.direction = Direction.W;
                    break;
                case Direction.S:
                    this.direction = Direction.E;
                    break;
                default:
                    break;
            }
        }
        private void TurnRight()
        {
            switch (direction)
            {
                case Direction.E:
                    this.direction = Direction.S;
                    break;
                case Direction.W:
                    this.direction = Direction.N;
                    break;
                case Direction.N:
                    this.direction = Direction.E;
                    break;
                case Direction.S:
                    this.direction = Direction.W;
                    break;
                default:
                    break;
            }
        }
        private void SameDirection()
        {
            switch (direction)
            {
                case Direction.N:
                    this.plateauRoverPositionY += 1;
                    break;
                case Direction.S:
                    this.plateauRoverPositionY -= 1;
                    break;
                case Direction.E:
                    this.plateauRoverPositionX += 1;
                    break;
                case Direction.W:
                    this.plateauRoverPositionX -= 1;
                    break;
                default:
                    break;
            }
        }
        private void RangeControl()
        {
            if (this.plateauRoverPositionX < 0 || this.plateauRoverPositionX > Plateau.xCoordinant || this.plateauRoverPositionY < 0 || this.plateauRoverPositionY > Plateau.yCoordinant)
            {
                throw new Exception($"Position can not be beyond bounderies (0 , 0) and ({Plateau.xCoordinant} , {Plateau.yCoordinant})");
            }
        }
        public string toString()
        {
            return plateauRoverPositionX + " " + plateauRoverPositionY + " " + direction;
        }
    }
}
