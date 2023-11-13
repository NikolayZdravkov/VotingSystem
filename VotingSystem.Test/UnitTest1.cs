using Moq;

namespace VotingSystem.Test
{

    public class MathOne
    {
        private readonly ITestOne testOne;

        public MathOne(ITestOne testOne) 
        {
            this.testOne = testOne;
        }

        public int Add(int a, int b) => testOne.Add(a, b);
    }

    public class MathOneTests
    {
        [Fact]
        public void MathOneAddsTwoNumbers()
        {
            var testOneMock = new Mock<ITestOne>();

            testOneMock.Setup(x => x.Add(1, 1)).Returns(2);

            var mathOne = new MathOne(testOneMock.Object);

            Assert.Equal(2, mathOne.Add(1, 1));
        }
    }

    public interface ITestOne
    {
        public int Add(int a, int b);
    }

    public class TestOne : ITestOne
    {
        public int Add(int a, int b) => a + b;
    }
    public class TestOneTests
    {
        [Fact]
        public void Add_AddsTwoNumbersTogether()
        {
            var result = new TestOne().Add(1, 1);
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        public void Add_AddsTwoNumbersTogether_Theory(int a, int b, int expected)
        {
            var result = new TestOne().Add(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestListContainsValue()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Assert.Contains(1, list);
        }
    }
}