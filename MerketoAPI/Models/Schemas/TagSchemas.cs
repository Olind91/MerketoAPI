using MerketoAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace MerketoAPI.Models.Schemas
{
    public class TagSchemas
    {
        [Required] //1:16:00 föreläsning 10.
        [MinLength(2)]
        public string TagName { get; set; } = null!;




        public static implicit operator TagEntity(TagSchemas schema)
        {
            return new TagEntity
            {
                TagName = schema.TagName,
            };
        }
    }
}
