namespace Code100.CoordinateLocator
{
    public record Rectangle
    {
        public Point LeftTop { get; set; }
        public Point RightBottom { get; set; }

        public Rectangle(Point leftTop, Point rightBottom)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }
    }
}
