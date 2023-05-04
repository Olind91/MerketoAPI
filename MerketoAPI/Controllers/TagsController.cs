using MerketoAPI.Helpers.Services;
using MerketoAPI.Models.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerketoAPI.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }


        #region Create Tag
        [HttpPost]
        public async Task<IActionResult> Create(TagSchemas tagSchemas)
        {
            //Kollar om tag redan finns, finns det -> Felmeddelande. Annars Skapas tag.
            if(ModelState.IsValid)
            {
                //1:34:00 ish f.10.
                var tag = await _tagService.GetTagAsync(tagSchemas.TagName);
                if (tag != null)
                            //409
                    return Conflict(new { tag, error = "This tag already exists mylord." });

                tag = await _tagService.CreateTagAsync(tagSchemas);
                if (tag != null)

                            //201
                    return Created("", tag);              
            }
            
            return BadRequest(tagSchemas);
        }
        #endregion


        #region Get Tags
        [HttpGet]
        //Hämtar alla tags eller specifik tag efter sökkriterie.
        public async Task<IActionResult> Get(string? tag) //1:50:00 ish f.10
        {
            //Hämtar specifik
            if (!string.IsNullOrEmpty(tag))
            {
                var _tag = await _tagService.GetTagAsync(tag);
                if (_tag != null)
                    return Ok(_tag); //200
            }
            else
            {
                //Om inte sökkriterie är ifyllt, hämtar alla.
                var tags = await _tagService.GetAllTagsAsync();
                if (tags != null)
                    return Ok(tags); //200
            }

            return NotFound(new { tag, error = "This is not the tag you are looking for, are you sure it exists?" }); //404
        }
        #endregion
           

    }
}
