using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace BervProject.Validation.Common.Test
{
    public class FileExtensionAttributeValidationTest
    {
        private readonly string[] allowedExtension = new string[] { ".xls", ".jpg", ".pdf" };

        [Theory]
        [InlineData("myexcel.xls")]
        [InlineData("randomname.jpg")]
        [InlineData("mypdf.pdf")]
        [InlineData("mypdf.double.pdf")]
        public void ExtenstionAttributeValidTest(string fileNameTest)
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns(fileNameTest);

            var attributeValidator = new FileExtensionAttributeValidation(allowedExtension);

            var fileObject = fileMock.Object;
            var validResult = attributeValidator.IsValid(fileObject);
            Assert.True(validResult);
        }

        [Theory]
        [InlineData("myexcel.zip")]
        [InlineData("randomname.png")]
        [InlineData("mypdf.txt")]
        [InlineData("noextension")]
        [InlineData("noextension.is.zip")]
        public void ExtenstionAttributeNotValidTest(string fileNameTest)
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns(fileNameTest);

            var attributeValidator = new FileExtensionAttributeValidation(allowedExtension);

            var fileObject = fileMock.Object;
            var validResult = attributeValidator.IsValid(fileObject);
            Assert.False(validResult);
        }
    }
}
