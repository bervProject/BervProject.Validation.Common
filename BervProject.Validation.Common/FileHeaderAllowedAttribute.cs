using System;
using System.ComponentModel.DataAnnotations;

namespace BervProject.Validation.Common
{
    public class FileHeaderAllowedAttribute : ValidationAttribute
    {
        private readonly string[] allowedExtensions;
        public FileHeaderAllowedAttribute(string[] allowedExtensions)
        {
            this.allowedExtensions = allowedExtensions;
        }

        /// <summary>
        /// IsValid checking about if the FileName extension is allowed
        /// </summary>
        /// <param name="value">Expected as IFile Object</param>
        /// <returns>Return if FileName is allowed</returns>
        public override bool IsValid(object value)
        {
            throw new NotImplementedException();
        }
    }
}
