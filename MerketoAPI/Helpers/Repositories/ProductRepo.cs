using MerketoAPI.Contexts;
using MerketoAPI.Models.Entities;

namespace MerketoAPI.Helpers.Repositories
{
    public class ProductRepo : Repo<ProductEntity>
    {
        //Ärver all funktionalitet som finns i Repo.cs
        //Går att skriva över funktioner med "Generate overrides"
        
        
        public ProductRepo(DataContext context) : base(context)
        {
        }
    }
}
