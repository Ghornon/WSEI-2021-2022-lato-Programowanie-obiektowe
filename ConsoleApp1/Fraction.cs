using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Fraction : IComparable
    {
        private int numerator;
        private int denominator;

        public int Numerator { get => numerator; }
        public int Denominator { get => denominator; }

        public Fraction()
        {

        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(Fraction oldFraction)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = oldFraction.Numerator;
            this.denominator = oldFraction.Denominator;
        }

        public static Fraction operator + (Fraction a) => a;
        public static Fraction operator - (Fraction a) => new Fraction(-a.Numerator, a.Denominator);
        public static Fraction operator + (Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator + b.numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator - (Fraction a, Fraction b) => a + (-b);
        public static Fraction operator * (Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator / (Fraction a, Fraction b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException();

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public override string ToString() => $"{Numerator} / {Denominator}";
     
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Fraction otherFraction = obj as Fraction;
            if (otherFraction != null)
                return this.Numerator.CompareTo(otherFraction.Numerator);
            else
                throw new ArgumentException("Object is not a Fraction");
        }
    }
}
