namespace MarsRoverBLL
{
    using System;
    using MarsRoverBLL.Interface;
    public class Rover : IRover
    {
        private int plateauRoverPositionX;
        private int plateauRoverPositionY;
        private IPlateau _plateau;
        private Direction Direction;
        public Rover(int startX, int startY, Direction _direction, IPlateau plateau)
        {
            this.plateauRoverPositionX = startX;
            this.plateauRoverPositionY = startY;
            this.Direction = _direction;
            this._plateau = plateau;
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
                        SameDirection();
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
            switch (Direction)
            {
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                default:
                    break;
            }
        }
        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                default:
                    break;
            }
        }
        private void SameDirection()
        {
            switch (Direction)
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
            if (this.plateauRoverPositionX < 0 || this.plateauRoverPositionX > _plateau.xCoordinant || this.plateauRoverPositionY < 0 || this.plateauRoverPositionY > _plateau.yCoordinant)
            {
                Console.WriteLine($"Position can not be beyond bounderies (0 , 0) and ({_plateau.xCoordinant} , {_plateau.yCoordinant})");
            }
        }
        public string toString()
        {
            return plateauRoverPositionX + " " + plateauRoverPositionY + " " + Direction;
        }
    }
}
