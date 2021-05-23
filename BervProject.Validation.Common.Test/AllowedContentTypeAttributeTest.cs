using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BervProject.Validation.Common.Test
{
    public class AllowedContentTypeAttributeTest
    {
        private readonly string[] allowedContentType = new string[] { "application/pdf", "application/zip", "image/jpeg", "image/png" };

        [Theory]
        [InlineData("image/png")]
        [InlineData("application/pdf")]
        [InlineData("application/zip")]
        [InlineData("image/jpeg")]
        public void ValidContentTypeTest(string fileNameTest)
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.ContentType).Returns(fileNameTest);

            var attributeValidator = new AllowedContentTypeAttribute(allowedContentType);

            var fileObject = fileMock.Object;
            var validResult = attributeValidator.IsValid(fileObject);
            Assert.True(validResult);
        }

        [Theory]
        [InlineData("application/html")]
        [InlineData("application/javascript")]
        [InlineData("image/bmp")]
        [InlineData("application/*")]
        [InlineData("image/*")]
        public void InvalidContentTypeTest(string fileNameTest)
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.ContentType).Returns(fileNameTest);

            var attributeValidator = new AllowedContentTypeAttribute(allowedContentType);

            var fileObject = fileMock.Object;
            var validResult = attributeValidator.IsValid(fileObject);
            Assert.False(validResult);
        }

        [Fact]
        public void NullFileTest()
        {
            var attributeValidator = new AllowedContentTypeAttribute(allowedContentType);
            var validResult = attributeValidator.IsValid(null);
            Assert.False(validResult);
        }

        [Fact]
        public void InjectAnotherTypeTest()
        {
            var anotherObject = "hello";
            var attributeValidator = new AllowedContentTypeAttribute(allowedContentType);
            var validResult = attributeValidator.IsValid(anotherObject);
            Assert.False(validResult);
        }
    }
}
