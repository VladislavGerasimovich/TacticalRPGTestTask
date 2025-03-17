namespace GridLayout.DataStorage
{
    [System.Serializable]
    public class Tile
    {
        public int _positionX;
        public int _positionY;
        public string _type;

        public int PositionX => _positionX;
        public int PositionY => _positionY;
        public string Type => _type;

        public Tile(int positionX, int positionY, string type)
        {
            _positionX = positionX;
            _positionY = positionY;
            _type = type;
        }
    }
}