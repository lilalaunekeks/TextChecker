using Moq;
using TextChecker.Commands;
using TextChecker.ViewModel;
using Xunit;

namespace TextChecker.Tests
{
    public class CheckCommandTests
    {
        [Fact]
        public void CanExecute_NotEmpty_IsTrue()
        {
            var checkCommand = CreateCheckCommand("123");

            var result = checkCommand.CanExecute("123");

            Assert.True(result);
        }

        [Fact]
        public void CanExecute_Empty_IsFalse()
        {
            var checkCommand = CreateCheckCommand("");

            var result = checkCommand.CanExecute("");

            Assert.False(result);
        }

        [Fact]
        public void CanExecute_Null_IsFalse()
        {
            var checkCommand = CreateCheckCommand(null);

            var result = checkCommand.CanExecute(null);

            Assert.False(result);
        }

        [Fact]
        public void Execute_Palindrome_IsTrue()
        {
            var checkCommand = CreateCheckCommand("abcba");

            checkCommand.Execute("abcba");
            var result = checkCommand.CheckerViewModel.CheckOutput;

            Assert.Equal("Yay! Your input is a palindrome!", result);
        }

        [Fact]
        public void Execute_NotPalindrome_IsFalse()
        {
            var checkCommand = CreateCheckCommand("abc");

            checkCommand.Execute("abc");
            var result = checkCommand.CheckerViewModel.CheckOutput;

            Assert.Equal("Nay! Your input is no palindrome!", result);
        }


        private CheckCommand CreateCheckCommand(string textInput){
            var checkerViewModel = new Mock<ICheckerViewModel>();
            checkerViewModel.SetupGet(x => x.TextInput).Returns(textInput);
            checkerViewModel.SetupProperty(x => x.CheckOutput);

            var checkCommand = new CheckCommand();
            checkCommand.CheckerViewModel = checkerViewModel.Object;

            return checkCommand;
        }
    }
}
