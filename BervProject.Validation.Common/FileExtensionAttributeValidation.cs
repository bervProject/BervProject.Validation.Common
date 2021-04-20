using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace BervProject.Validation.Common
{
    public class FileExtensionAttributeValidation : ValidationAttribute
    {
        private readonly string[] extensions;
        /// <summary>
        /// FileExtensionAttributeValidation to check if extension that supplied are allowed
        /// </summary>
        /// <param name="extensions">Allowed Extensions List</param>
        public FileExtensionAttributeValidation(string[] extensions)
        {
            this.extensions = extensions;
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
            var fileExtension = Path.GetExtension(file.FileName);
            return extensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }
    }
}
