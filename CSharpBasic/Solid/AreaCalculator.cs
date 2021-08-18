namespace Solid
{
    public class AreaCalculator
    {
        public double TotalArea(Shape arrShapes)
        {
            double area = 0;
            area += arrShapes.Area();
            return area;
        }
    }
}
