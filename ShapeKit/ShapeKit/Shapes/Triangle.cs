using ShapeKit.Interfaces;
using ShapeKit.Models;

namespace ShapeKit.Shapes;

public class Triangle : Shape, ITriangleCalculator
{
    private const int COUNT_SIDE = 3;
    // Спорное решение со сторонами в виде массива, но я подумал об многоугольниках, и риализовывать для 100 угольника поля, как-то не очень.
    // В тоже время, в небольшом количестве сторон все-таки захотел уточнить, что значит значение в квардратных скобках.
    private const int FIRST_SIDE_INDEX = 0;
    private const int SECOND_SIDE_INDEX = 1;
    private const int THIRD_SIDE_INDEX = 2;

    private float _semiperimeter;

    public IList<ShapeSide> Sides { get; private set; }

    public Triangle(IEnumerable<ShapeSide> sides)
    {
        ValidateSide(sides);

        Sides = sides.ToList();
    }

    private void ValidateSide(IEnumerable<ShapeSide> sides)
    {
        if (sides == null)
            throw new ArgumentNullException(nameof(sides));

        if (sides.Count() > COUNT_SIDE)
            throw new Exception("Invalid number of sides for a triangle");

        // Можно продолжить добавлять валидацию на различные вещи, например на то, чтобы длина была положительная и т.д.
        // При это дробя на функции, каждая из которых будет делать свои проверки.
    }

    public override void CalculateArea()
    {
        // Специально присваиваю значеине не в методе, чтобы задать строгое поочередное выполнение.
        _semiperimeter = GetCalculateSemiperimeter();
        Area = GetCalculateArea(_semiperimeter);
    }

    private float GetCalculateSemiperimeter()
    => Sides.Sum(side => side.Length) / 2;

    private float GetCalculateArea(float _semiperimeter)
    {
        float firstSideLenght = Sides[FIRST_SIDE_INDEX].Length;
        float secondSideLenght = Sides[SECOND_SIDE_INDEX].Length;
        float thirdSideLenght = Sides[THIRD_SIDE_INDEX].Length;

        return (float)Math.Sqrt(_semiperimeter * (_semiperimeter - firstSideLenght) * (_semiperimeter - secondSideLenght) * (_semiperimeter - thirdSideLenght));
    }

    public bool IsRightAngle()
    {
        const int HYPOTENUSE_INDEX = 2;
        const int FIRST_CATHETUS_INDEX = 0;
        const int SECOND_CATHETUS_INDEX = 1;

        var lenghtSides = Sides.Select(side => side.Length).ToList();
        lenghtSides.Sort();

        if (Math.Pow(lenghtSides[HYPOTENUSE_INDEX], 2) == Math.Pow(lenghtSides[FIRST_CATHETUS_INDEX], 2) + Math.Pow(lenghtSides[SECOND_CATHETUS_INDEX], 2))
        {
            return true;
        }

        return false;
    }
}
