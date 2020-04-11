namespace MarsRoverBusiness
{
    using MarsRoverBusiness.Interface;
    public class Plateau : IPlateau
    {
        private int _x { get; set; }
        private int _y { get; set; }
        public Plateau(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
        public int xCoordinant {get{return _x;}}
        public int yCoordinant { get { return _y; } }
    }
}
