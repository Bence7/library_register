using LibraryRegisterAPI.Services;
using NUnit.Framework;

namespace LibraryRegisterAPI.Tests
{
    [TestFixture]
    public class MemberServiceTests
    {
        private MemberService _memberService;

        [SetUp]
        public void Setup()
        {
            _memberService = new MemberService();
        }

        [Test]
        public void IsNameValid_ValidName_ReturnsTrue()
        {
            string name = "HarryPotter";

            bool result = _memberService.IsNameValid(name);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNameValid_NameWithSpaces_ReturnsFalse()
        {
            string name = "Harry Potter";

            bool result = _memberService.IsNameValid(name);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsNameValid_NameWithSpecialCharacters_ReturnsFalse()
        {
            string name = "!@:;-#$%^&*()";

            bool result = _memberService.IsNameValid(name);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsNameValid_EmptyName_ReturnsFalse()
        {
            string name = string.Empty;

            bool result = _memberService.IsNameValid(name);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsNameValid_WhitespaceName_ReturnsFalse()
        {
            string name = "   ";

            bool result = _memberService.IsNameValid(name);

            Assert.IsFalse(result);
        }
    }
}