using MerketoAPI.Contexts;
using MerketoAPI.Models.Entities;

namespace MerketoAPI.Helpers.Repositories
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {

        //Ärver all funktionalitet som finns i Repo.cs
        //Går att skriva över funktioner med "Generate overrides"
        public ProductCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
