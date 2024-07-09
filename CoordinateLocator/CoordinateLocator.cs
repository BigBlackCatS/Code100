using Code100.CoordinateLocator;

namespace Code100.CoordinateLocator
{
    public static class CoordinateLocator
    {
        public static bool IsPointWithinCircle(Point point, Circle circle)
        {
            return SubstitutePointToCircleEquation(point, circle) <= 0;
        }

        public static bool IsPointBeyondCircle(Point point, Circle circle)
        {
            return SubstitutePointToCircleEquation(point, circle) >= 0;
        }

        public static bool IsPointWithinRectangle(Point point, Rectangle rectangle)
        {
            return rectangle.LeftTop.X <= point.X && rectangle.RightBottom.X >= point.X
                && rectangle.LeftTop.Y <= point.Y && rectangle.RightBottom.Y >= point.Y;
        }

        private static double SubstitutePointToCircleEquation(Point point, Circle circle)
        {
            return Math.Pow(point.X - circle.Center.X, 2)
                + Math.Pow(point.Y - circle.Center.Y, 2)
                - Math.Pow(circle.Radius, 2);
        }
    }
}
