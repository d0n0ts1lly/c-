using System;
using System.Collections.Generic;

public interface IShape
{
    void Draw();
}

public interface IColoredShape : IShape
{
    void SetColor(string color);
}

public class Circle : IColoredShape
{
    private string color;

    public Circle(string color)
    {
        this.color = color;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    public void Draw()
    {
        Console.WriteLine($"Малюю коло кольору: {color}");
    }

    public override string ToString()
    {
        return $"Коло (колір: {color})";
    }
}

class Program
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle("Червоний"),
            new Circle("Зелений"),
            new Circle("Синій")
        };

        Console.WriteLine("Список фігур:");
        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
