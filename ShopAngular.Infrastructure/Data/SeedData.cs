using ShopAngular.Model.Entities;
using ShopAngular.ShopAngular.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAngular.Infrastructure.Data
{
    public class SeedData
    {
        //private readonly ShopAngularContext _context;
        //public SeedData(ShopAngularContext context)
        //{
        //    _context = context;
        //}

        public static async Task Seed(ShopAngularContext _context)
        {

            //product-type
            if(!_context.ProductTypes.Any())
            {
                _context.ProductTypes.AddRange(new List<ProductType>
                {
                    new ProductType{ Id=1,Name="Bags"},
                    new ProductType{ Id=2,Name="Shoes"},
                    new ProductType{ Id=3,Name="T-Shirt"},
                    new ProductType{ Id=4,Name="Caps"},

                });
                await _context.SaveChangesAsync();
            }

            if (!_context.ProductBrands.Any())
            {
                _context.ProductBrands.AddRange(new List<ProductBrand>
                {
                    new ProductBrand{ Id=1,Name="Nike"},
                    new ProductBrand{ Id=2,Name="Adidas"},
                    new ProductBrand{ Id=3,Name="Louis Vuitton"},
                    new ProductBrand{ Id=4,Name="MLB"},
                    new ProductBrand{ Id=5,Name="Gucci"},
                    new ProductBrand{ Id=6,Name="Hermes"},
                    new ProductBrand{ Id=7,Name="Alexander Mcqueen"},

                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Products.Any())
            {
                _context.Products.AddRange(new List<Product>
                {
                    //brand1
                    new Product{ Id=1, Name="Nike Sport Backpack", Description="Designed to fit the essentials and then some, this backpack offers versatile storage and style.", Price=200, PictureUrl="images/products/NikeSportBackpack.jpg",ProductTypeId=1,ProductBrandId=1},
                    new Product{ Id=2, Name="Nike CK7922", Description="Whether it's hanging out after school with friends or a day hike on your local trail, this backpack can do it all. ", Price=150, PictureUrl="images/products/NikeCK7922.jpg",ProductTypeId=1,ProductBrandId=1},
                    new Product{ Id=3, Name="Nike AirForce1", Description="Celebrating 40 years of pushing sport. Happy anniversary!", Price=180, PictureUrl="images/products/NikeAirForce1.jpg",ProductTypeId=2,ProductBrandId=1},
                    new Product{ Id=4, Name="Nike AirZoom Pegasus", Description="Let the Nike Pegasus FlyEase, a balanced and energised ride for any run, help you ascend to new heights. ", Price=300, PictureUrl="images/products/NikeAirZoomPegasus.jpg",ProductTypeId=2,ProductBrandId=1},
                    new Product{ Id=5, Name="Polo Nike Sportswear", Description="The Nike Sportswear Club T-Shirt is made with our everyday cotton fabric and a classic fit. An embroidered Futura logo on the chest provides a signature Nike look.", Price=250, PictureUrl="images/products/PoloNikeSportswear.jpg",ProductTypeId=3,ProductBrandId=1},
                    new Product{ Id=6, Name="Nike Jordan Jumpman", Description="The Jordan Jumpman has an unstructured crown made from lightweight twill that's washed for a worn-in look. It adjusts at the back with a strap.", Price=120, PictureUrl="images/products/NikeJordanJumpman.jpg",ProductTypeId=4,ProductBrandId=1},
                    new Product{ Id=7, Name="Nike Sportswear", Description="The Nike Sportswear has a durable 6-panel design with an adjustable strap for the perfect fit. adds a classic look you can wear anywhere.", Price=10, PictureUrl="images/products/NikeSportswear.jpg",ProductTypeId=4,ProductBrandId=1},


                    //brand2 new Product{Id=13,Name="",Description="",Price=,PictureUrl="",ProductTypeId=,ProductBrandId=2},
                    new Product{Id=8,Name="Adicolor Festival Bag",Description="Simple, clean and modern. This adidas festival bag matches up perfectly with your style.",Price=8,PictureUrl="images/products/AdicolorFestivalBag.jpg",ProductTypeId=1,ProductBrandId=2},
                    new Product{Id=9,Name="Adidas Adventure Backpack",Description="Can one bag do everything, from workday commutes to weekend adventures? This pick from adidas is raising its hand.",Price=15,PictureUrl="images/products/AdidasAdventureBackpack.jpg",ProductTypeId=1,ProductBrandId=2},
                    new Product{Id=10,Name="SuperStar Shoes",Description=" The world-famous shell toe feature remains, providing style and protection.",Price=18,PictureUrl="images/products/SuperStarShoes.jpg",ProductTypeId=2,ProductBrandId=2},
                    new Product{Id=11,Name="Polo Adidas Goft",Description="Sporty style matched with game-changing performance.",Price=15,PictureUrl="images/products/PoloAdidasGoft.jpg",ProductTypeId=3,ProductBrandId=2},
                    new Product{Id=12,Name="Adidas RYV",Description="It represents a fearless energy and a clan of creators striving to be their best at every step.",Price=16,PictureUrl="images/products/AdidasRYV.jpg",ProductTypeId=3,ProductBrandId=2},
                    new Product{Id=13,Name="Adidas Cotton Bucket",Description="Whether you're on the treadmill or the trail, this adidas training hat tops off your workout.",Price=14,PictureUrl="images/products/AdidasCottonBucket.jpg",ProductTypeId=4,ProductBrandId=2},

                    //brand3
                    new Product{Id=14,Name="LV Poche Toilette",Description="Featuring a Monogram name tag, it pays homage to Louis Vuitton’s roots while its sleek design sets a new standard for casual business chic.",Price=450,PictureUrl="images/products/LouisVuittonPocheToilette.jpg",ProductTypeId=1,ProductBrandId=3},
                    new Product{Id=15,Name="LV Glove Loafer",Description="The LV Glove loafer is crafted from supple calf leather, which enhances its sleek, elegant lines.",Price=400,PictureUrl="images/products/LVGloveLoafer.jpg",ProductTypeId=2,ProductBrandId=3},
                    new Product{Id=16,Name="LV Monogram TShirt",Description="This short-sleeved shirt has a smart, crisp quality with its printed allover Optic Monogram motif containing clever signature details. ",Price=750,PictureUrl="images/products/LouisVuittonMonogramTShirt.jpg",ProductTypeId=3,ProductBrandId=3},
                    new Product{Id=17,Name="LV Vuitton Monogram Hat",Description="This standout piece has a boxy fit with dropped shoulders and has been stone-washed for a soft finish.",Price=900,PictureUrl="images/products/LouisVuittonMonogramHat.jpg",ProductTypeId=4,ProductBrandId=3},

                    //brand4
                    new Product{Id=18,Name="MLB Monogram Jacquard Mini",Description="The world-famous shell toe feature remains, providing style and protection.",Price=180,PictureUrl="images/products/MLBMonogramJacquardMini.jpg",ProductTypeId=1,ProductBrandId=4},
                    new Product{Id=19,Name="MLB High NewYork Yankees",Description="Sporty style matched with game-changing performance.",Price=145,PictureUrl="images/products/MLBHighNewYorkYankees.jpg",ProductTypeId=2,ProductBrandId=4},
                    new Product{Id=20,Name="MLB Mega Overfit LA",Description="Sweat-wicking technology will help keep you dry, so you can stay comfortable.",Price=47,PictureUrl="images/products/MLBIllusionMegaOverfitLA.jpg",ProductTypeId=3,ProductBrandId=4},
                    new Product{Id=21,Name="MLB Shadow Cap Yankees",Description="From the court to the concrete, the MLB Shadow Cap keeps you comfortable thanks to soft knit fabric",Price=39,PictureUrl="images/products/MLBShadowCapYankees.jpg",ProductTypeId=4,ProductBrandId=4},

                    //brand5
                    new Product{Id=22,Name="Gucci Jumbo GG",Description="Ready to take on work or party, the Gucci Jumbo GG updates a classic look with smart storage options to keep your electronics stashed securely.",Price=145,PictureUrl="images/products/GucciJumboGG.jpg",ProductTypeId=1,ProductBrandId=5},
                    new Product{Id=23,Name="Gucci 1977 Ebony",Description="That kind of versatility is uncommon in the party arena. But who said you can't have it all?",Price=478,PictureUrl="images/products/Gucci1977Ebony.jpg",ProductTypeId=2,ProductBrandId=5},
                    new Product{Id=24,Name="Polo Gucci GG Interlocking",Description="Made from soft cotton in a relaxed fit, it puts your pride on bold display.",Price=190,PictureUrl="images/products/Gucci1977PoloGucciGGInterlocking.jpg",ProductTypeId=3,ProductBrandId=5},
                    new Product{Id=25,Name="Gucci Canvas",Description="Updating the classic silhouette, the Gucci Canvas features our classic graphic embroidered on the front panel and an adjustable snapback closure.",Price=210,PictureUrl="images/products/GucciCanvas.jpg",ProductTypeId=4,ProductBrandId=5},

                    //brand6

                    new Product{Id=26,Name="Hermes Garden Party",Description="Very beautyful in party ",Price=168,PictureUrl="images/products/HermesGardenParty.jpg",ProductTypeId=1,ProductBrandId=6},
                    new Product{Id=27,Name="Hermes Mocca Taiga",Description="Very very very beautyful in party ",Price=330,PictureUrl="images/products/HermesMoccaTaiga.jpg",ProductTypeId=2,ProductBrandId=6},
                    new Product{Id=28,Name="PoloHermes",Description="Flex his favourite show on soft and heavyweight cotton that's perfect from workouts to hangouts.",Price=287,PictureUrl="images/products/PoloHermes.jpg",ProductTypeId=3,ProductBrandId=6},

                    //brand7
                    new Product{Id=29,Name="Alexander Mcqueen SkullBlack",Description="Black calf leather Grip tote bag featuring the signature SkullBag metal handles and finished with an Alexander McQueen signature at the base.",Price=333,PictureUrl="images/products/AlexanderMcqueenSkullBlack.jpg",ProductTypeId=1,ProductBrandId=7},
                    new Product{Id=30,Name="Backpack Multicolour",Description="Multicoloured nylon backpack detailed with an all-over Watercolour Graffiti print and a black harness. Finished with an Alexander McQueen signature at the base.",Price=287,PictureUrl="images/products/TheHarnessBackpackMulticolour.jpg",ProductTypeId=1,ProductBrandId=7},
                    new Product{Id=31,Name="Alexander Mcqueen StuddedHeels",Description="White and navy calf leather lace-up sneaker featuring an oversized frosted transaparent sole and color island inside.",Price=197,PictureUrl="images/products/AlexanderMcqueenStuddedHeels.jpg",ProductTypeId=2,ProductBrandId=7},
                    new Product{Id=32,Name="Slim Tread",Description="Black leather Slim Tread Derby lace-up featuring a slim stacked sole with a rubber layer. Finished with an embossed Alexander McQueen Seal logo at the back.",Price=250,PictureUrl="images/products/SlimTread.jpg",ProductTypeId=2,ProductBrandId=7},
                    new Product{Id=33,Name="Alexander McQueen Brushed",Description="The style features a crew neck and short sleeves.",Price=500,PictureUrl="images/products/AlexanderMcQueenBrushed.jpg",ProductTypeId=3,ProductBrandId=7},
                    new Product{Id=34,Name="Nettle Embroidery",Description="White T-shirt in cotton medium weight jersey featuring a beaded Nettle embroidery on the chest.",Price=321,PictureUrl="images/products/NettleEmbroidery.jpg",ProductTypeId=3,ProductBrandId=7},
                });
                await _context.SaveChangesAsync();
            }

        }
    }
}
