using ProjectEuler;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class MathToolsTests
    {
        [Fact]
        public void TestGCD()
        {
            Assert.Equal(0, MathTools.GCD(0, 0));
            Assert.Equal(1, MathTools.GCD(0, 1));
            Assert.Equal(1, MathTools.GCD(111, 1));
            Assert.Equal(2, MathTools.GCD(4, 1234));
            Assert.Equal(3, MathTools.GCD(9, 6));
            Assert.Equal(4, MathTools.GCD(4, 8));
            Assert.Equal(5, MathTools.GCD(-5, 25));
        }

        [Fact]
        public void TestDigitCount()
        {
            Assert.Equal(0, MathTools.DigitCount(0));
            Assert.Equal(1, MathTools.DigitCount(5));
            Assert.Equal(3, MathTools.DigitCount(111));
            Assert.Equal(10, MathTools.DigitCount(1234567890));
            Assert.Equal(20, MathTools.DigitCount(12345678901234567890));
        }

        [Fact]
        public void TestNthDigit()
        {
            Assert.Equal(0, MathTools.NthDigit(10000, 2));
            Assert.Equal(8, MathTools.NthDigit(8, 0));
            Assert.Equal(1, MathTools.NthDigit(12345, 0));
            Assert.Equal(3, MathTools.NthDigit(12345, 2));
            Assert.Equal(-1, MathTools.NthDigit(12345, 5));
        }

        [Fact]
        public void TestIsPrime()
        {
            Assert.True(MathTools.IsPrime(2));
            Assert.True(MathTools.IsPrime(3));
            Assert.True(MathTools.IsPrime(7));
            Assert.True(MathTools.IsPrime(101));
            Assert.True(MathTools.IsPrime(104729));
            Assert.False(MathTools.IsPrime(0));
            Assert.False(MathTools.IsPrime(1));
            Assert.False(MathTools.IsPrime(4));
            Assert.False(MathTools.IsPrime(99));
            Assert.False(MathTools.IsPrime(100000));
        }

        [Fact]
        public void TestGetPrimes()
        {
            var primes = MathTools.GetPrimes(9973);
            Assert.Equal(1229, primes.Count);
            Assert.Equal(2U, primes[0]);
            Assert.Equal(3U, primes[1]);
            Assert.Equal(5U, primes[2]);
            Assert.Equal(9973U, primes.Last());
        }

        [Fact]
        public void TestNextPermutation()
        {
            var array = new[] { 1, 2, 3 };

            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(2, array[2]);
            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal(2, array[0]);
            Assert.Equal(1, array[1]);
            Assert.Equal(3, array[2]);
            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal(2, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(1, array[2]);
            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal(3, array[0]);
            Assert.Equal(1, array[1]);
            Assert.Equal(2, array[2]);
            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal(3, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(1, array[2]);
            Assert.False(MathTools.NextPermutation(array));
            Assert.Equal(3, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(1, array[2]);
        }

        [Fact]
        public void TestNextPermutationT()
        {
            var array = new string[] { "b", "c", "a" };

            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal("c", array[0]);
            Assert.Equal("a", array[1]);
            Assert.Equal("b", array[2]);
            Assert.True(MathTools.NextPermutation(array));
            Assert.Equal("c", array[0]);
            Assert.Equal("b", array[1]);
            Assert.Equal("a", array[2]);
            Assert.False(MathTools.NextPermutation(array));
            Assert.Equal("c", array[0]);
            Assert.Equal("b", array[1]);
            Assert.Equal("a", array[2]);
        }
    }
}
