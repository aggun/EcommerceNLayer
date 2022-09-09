using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            Context context = new Context();
            if (context.Database.GetPendingMigrations().Any())
            {
                //context.Database.Migrate(); // Execute migration
            }
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                //if (context.Categories.Count() == 0)
                //{
                //    context.Categories.AddRange(Categories);
                //}
                //if (context.Products.Count() == 0)
                //{
                //    context.Products.AddRange(Productes);
                //}
                //if (context.Features.Count() == 0)
                //{
                //    context.Features.AddRange(Features);
                //}
                //if (context.Brands.Count() == 0)
                //{
                //    context.Brands.AddRange(Brands);
                //}

            }
            context.SaveChanges();
        }
        private static Brand[] Brands ={
        new Brand() { Name="Samsung",Status=true},
        new Brand() { Name="Apple",Status=true},
        new Brand(){ Name="Huawei",Status=true}
        };
      
        private static Category[] Categories ={
        new Category() { Name="Telefon"},
        new Category() { Name="Bilgisayar"},
        new Category(){ Name="Elektronik"}
        };
        private static Feature[] Features ={
        new Feature() { FeatureName="Renk",FeatureValu="Kırmızı",DicountRate=15,IsDiscounted=true},
        new Feature() { FeatureName="Renk",FeatureValu="Sarı",DicountRate=16,IsDiscounted=false},
        new Feature() { FeatureName="Boyut",FeatureValu="Small",DicountRate=15,IsDiscounted=true},
        new Feature() { FeatureName="Boyut",FeatureValu="Large",DicountRate=25,IsDiscounted=false}

        };
        private static Product[] Productes ={
        new Product() { Name="Samsung S9", ImageUrl="\\Product-img\\1.jpg",Price=2000},
        new Product() { Name="Samsung S8", ImageUrl="\\Product-img\\2.jpg",Price=3000},
        new Product() { Name="Samsung S7", ImageUrl="\\Product-img\\3.jpg",Price=6000},
        new Product() { Name="Samsung S6", ImageUrl="\\Product-img\\4.jpg",Price=5000},
        new Product() { Name="Samsung S5", ImageUrl="\\Product-img\\5.jpg",Price=4000,Status=false},

        };
    }
}
