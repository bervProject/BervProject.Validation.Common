using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BervProject.Validation.Common
{
    public class AllowedContentTypeAttribute : ValidationAttribute
    {
        private readonly string[] contentTypes;
        /// <summary>
        /// FileExtensionAttributeValidation to check if extension that supplied are allowed
        /// </summary>
        /// <param name="extensions">Allowed Extensions List</param>
        public AllowedContentTypeAttribute(string[] contentTypes)
        {
            this.contentTypes = contentTypes;
        }

        /// <summary>
        /// IsValid checking about if the FileName extension is allowed
        /// </summary>
        /// <param name="value">Expected as IFile Object</param>
        /// <returns>Return if FileName is allowed</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            if (!typeof(IFormFile).IsInstanceOfType(value))
            {
                return false;
            }
            var file = (IFormFile)value;
            var contentType = file.ContentType;
            return contentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase);
        }
    }
}
