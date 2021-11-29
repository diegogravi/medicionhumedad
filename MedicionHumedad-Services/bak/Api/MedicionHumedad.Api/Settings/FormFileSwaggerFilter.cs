using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MedicionHumedad.Api.Settings
{
    /// <summary>
    /// Filter to enable handling file upload in swagger
    /// </summary>
    public class FormFileSwaggerFilter : IOperationFilter
    {
        private const string formDataMimeType = "multipart/form-data";
        private static readonly string[] formFilePropertyNames =
            typeof(IFormFile).GetTypeInfo().DeclaredProperties.Select(p => p.Name).ToArray();

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //if (operation.OperationId.ToLower() == "apivaluesuploadpost")
            //{
            //    operation.Parameters.Clear();
            //    operation.Parameters.Add(new NonBodyParameter
            //    {
            //        Name = "uploadedFile",
            //        In = "formData",
            //        Description = "Upload File",
            //        Required = true,
            //        Type = "file"
            //    });
            //    operation.Consumes.Add("multipart/form-data");
            //}
        }
    }
}
