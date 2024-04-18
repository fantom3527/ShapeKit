using ShapeKit.Interfaces;

namespace ShapeKit.Shapes;

// Абстрактным классом Shape я реализую 3 пункт задания: "Вычисление площади фигуры без знания типа фигуры в compile-time"
// С помощью паттерна стратегия и класса Shape можно реализовать вычипсление 
public abstract class Shape : IShapeCalculator
{
    public float Area { get; protected set; }

    public abstract void CalculateArea();
}
