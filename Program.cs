// See https://aka.ms/new-console-template for more information
using Code100.CoordinateLocator;
using Code100.JsonFuctionality;

var dataSet = JsonHelper.LoadJson("coordinatesystem.json");

if (dataSet == null )
{
    Console.WriteLine("The data set was not defined. Try to fix load the file again.");
    return;
}

if (dataSet.Coords == null)
{
    Console.WriteLine("The coordinates were not defined properly within the json-file." +
        "Try to fix load the file again.");
    return;
}

// The width and height should be taken int account to scale locating of the '100' logo.
// For the simplicity we hardcode the points which define the location of the '100' logo within the picture.
var firstZeroInnerCircle = new Circle(new Point(250, 150), 55);
var firstZeroOuterCircle = new Circle(new Point(250, 150), 75);

var secondZeroInnerCircle = new Circle(new Point(410, 150), 55);
var secondZeroOuterCircle = new Circle(new Point(410, 150), 75);

var rectangle = new Rectangle(new Point(145, 75), new Point(165, 225));

var pointsHittingLogo = new List<Point>();

foreach (var pointList in dataSet.Coords)
{
    if (pointList.Count < 2)
    {
        continue;
    }

    var point = new Point(pointList[0], pointList[1]);

    if (CoordinateLocator.IsPointWithinRectangle(point, rectangle))
    {
        pointsHittingLogo.Add(point);
    }
    else if (CoordinateLocator.IsPointWithinCircle(point, firstZeroOuterCircle)
        && CoordinateLocator.IsPointBeyondCircle(point, firstZeroInnerCircle))
    {
        pointsHittingLogo.Add(point);
    }
    else if (CoordinateLocator.IsPointWithinCircle(point, secondZeroOuterCircle)
        && CoordinateLocator.IsPointBeyondCircle(point, secondZeroInnerCircle))
    {
        pointsHittingLogo.Add(point);
    }
}

foreach (var point in pointsHittingLogo)
{
    Console.WriteLine($"The point {point.ToString()} is located within '100' logo.");
}

Console.WriteLine($"There are {pointsHittingLogo.Count} points in the '100' logo.");
