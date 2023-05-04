using MerketoAPI.Contexts;
using MerketoAPI.Models.Entities;

namespace MerketoAPI.Helpers.Repositories
{
    public class TagRepo : Repo<TagEntity>
    {

        //Ärver all funktionalitet som finns i Repo.cs
        //Går att skriva över funktioner med "Generate overrides"
        public TagRepo(DataContext context) : base(context)
        {
        }
    }
}
