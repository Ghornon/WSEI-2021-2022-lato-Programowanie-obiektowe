using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ConsoleApp1;

namespace TestFraction
{
    [TestClass]
    public class UnitTestFraction
    {
        [TestMethod]
        public void CreateFractionWithoutError()
        {
            Fraction a = new Fraction(1, 4);
            Fraction b = new Fraction(a);
            Fraction c = new Fraction();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateFractionWithExpectedException()
        {
            var a = new Fraction(1, 0);
            Fraction b = new Fraction(a);
        }
        [TestMethod]
        public void ConvertFractionToString()
        {
            var a = new Fraction(1, 1);

            Assert.AreEqual("1/1", a.ToString());
        }

        [TestMethod]
        public void FractionOperatorOverload()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);

            Assert.AreEqual(new Fraction(6, 8), a + b);
            Assert.AreEqual(new Fraction(2, 8), a - b);
            Assert.AreEqual(new Fraction(4, 8), a * b);
            Assert.AreEqual(new Fraction(4, 2), a / b);
        }

        [TestMethod]
        public void FractionInterfaceImplementation()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            var c = new Fraction(1, 8);

            List<Fraction> fractions = new List<Fraction>();
            fractions.Add(a);
            fractions.Add(b);
            fractions.Add(c);
            fractions.Add(new Fraction(2, 4));
            fractions.Add(new Fraction(1, 6));

            fractions.Sort();

            Fraction test = new Fraction(1, 2);

            Assert.IsTrue(fractions.Contains(test));
            Assert.AreEqual(0, a.CompareTo(a));
            Assert.AreEqual(-1, a.CompareTo(b));
            Assert.AreEqual(1, b.CompareTo(a));
        }

        [TestMethod]
        public void FractionRound()
        {
            var a = new Fraction(1, 2);

            Assert.AreEqual(1, a.RoundUp());
            Assert.AreEqual(0, a.RoundDown());
        }
    }
}
