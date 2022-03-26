using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Fraction : IComparable, IEquatable<Fraction>
    {
        private int numerator;
        private int denominator;

        public int Numerator { get => numerator; }
        public int Denominator { get => denominator; }

        public Fraction()
        {

        }
        public Fraction(Fraction oldFraction)
        {
            this.numerator = oldFraction.Numerator;
            this.denominator = oldFraction.Denominator;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator + b.numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Denominator);
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException();

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Fraction otherFraction = obj as Fraction;

            if (otherFraction == null)
                throw new ArgumentException("Object is not a Fraction");

            if (this.Numerator.CompareTo(otherFraction.Numerator) == 0 && this.Denominator.CompareTo(otherFraction.Denominator) == 0)
                return 0;
            else
                return this.Numerator.CompareTo(otherFraction.Numerator) + this.Denominator.CompareTo(otherFraction.Denominator);
        }

        public bool Equals(Fraction other)
        {
            if (other == null)
                return false;

            if (this.Numerator == other.Numerator && this.Denominator == other.Denominator)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Fraction otherFraction = obj as Fraction;
            if (otherFraction == null)
                return false;
            else
                return Equals(otherFraction);
        }

        public override int GetHashCode()
        {
            return Numerator + Denominator;
        }

        public double RoundDown() {
            double number = (double)Numerator / (double)Denominator;
            return Math.Floor(number);
        }

        public double RoundUp()
        {
            double number = (double)Numerator / (double)Denominator;
            return Math.Ceiling(number);
        }
    }
}
