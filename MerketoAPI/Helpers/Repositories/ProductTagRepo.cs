using MerketoAPI.Contexts;
using MerketoAPI.Models.Entities;

namespace MerketoAPI.Helpers.Repositories
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {

        //Ärver all funktionalitet som finns i Repo.cs
        //Går att skriva över funktioner med "Generate overrides"

        public ProductTagRepo(DataContext context) : base(context)
        {
        }
    }
}
