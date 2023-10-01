using System.ComponentModel;

namespace Tests
{
    public class UnitTest
    {
        Parenthesis parenthesis = new();
        
        [Fact]
        public void TestParenthesisBalanced1()
        {
            string test = "{[()]}";
            bool result = parenthesis.IsBalanced(test);

            Assert.True(result);
            
        }
        [Fact]
        public void TestParentesisBalanced2()
        {
            string test = "[]{[()]}()";
            bool result = parenthesis.IsBalanced(test);

            Assert.True(result);

        }

        [Fact]
        public void TestParenthesisBalanced3()
        {
            string test = "List<int> list = new List<int>() { 1, 2, 3, 4 };";
            bool result = parenthesis.IsBalanced(test);

            Assert.True(result);

        }

        [Fact]
        public void TestParenthesisNotBalanced1() 
        {
            string test = "{[()]})";
            bool result = parenthesis.IsBalanced(test);

            Assert.False(result);
        }

        [Fact]
        public void TestParenthesisNotBalanced2()
        {
            string test = "({[()]}";
            bool result = parenthesis.IsBalanced(test);

            Assert.False(result);
        }
        
        [Fact]
        public void TestParenthesisNotBalanced3()
        {
            string test = "({[()]}))";
            bool result = parenthesis.IsBalanced(test);

            Assert.False(result);
        }

        [Fact]
        public void TestParenthesisNotBalanced4()
        {
            string test = "List<int> list = new List<int>() { 1, 2, 3, 4 );";
            bool result = parenthesis.IsBalanced(test);

            Assert.False(result);
        }

    }
}