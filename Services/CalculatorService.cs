
#nullable disable

using System;
using CalculatorApi.Interfaces;

namespace CalculatorApi.Services
{
    public class CalculatorService<T> : ICalculatorService<T>
    {
       public T Add(T a, T b)      => ((dynamic)a + b)!;
public T Subtract(T a, T b) => ((dynamic)a - b)!;
public T Multiply(T a, T b) => ((dynamic)a * b)!;
public T Divide(T a, T b)
{
    if ((dynamic)b == 0)
        throw new DivideByZeroException("Cannot divide by zero.");
    return ((dynamic)a / b)!;
}
    }
}
