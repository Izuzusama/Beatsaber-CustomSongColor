namespace CustomSongColor.Data
{
    class CustomColor
    {
        public MapColor? _colorLeft;
        public MapColor? _colorRight;
        public MapColor? _envColorLeft;
        public MapColor? _envColorRight;
        public MapColor? _envColorLeftBoost;
        public MapColor? _envColorRightBoost;
        public MapColor? _obstacleColor;
    }
    public class MapColor
    {
        public float r;
        public float g;
        public float b;


        public MapColor(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
