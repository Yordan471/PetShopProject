using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Infrastructure.Data.Configurations
{
    public class ProductEntityConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.OrdersDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.HasData(SeedProductsToDb());
        }

        private List<Product> SeedProductsToDb()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Royal Canin Adult",
                    ShortDescription = "Пълноценна суха храна за възрастни кучета от средни породи.",
                    LongDescription = "Royal Canin Adult е специално разработена суха храна за възрастни кучета от средни породи (11-25 кг). Тя съдържа оптимален баланс от хранителни вещества, включително високо качествени протеини, за поддържане на здрава мускулна маса, и специфични хранителни вещества за поддържане на здравето на кожата и козината. Храната също така подпомага здравето на зъбите и венците чрез включването на хрупкави гранули, които помагат за намаляване на натрупването на зъбен камък.",
                    Price = 32.99m,
                    ImageUrl = "~/Images/Products/Dogs/DryFoods/Royal_Canin_Adult.jpg",
                    AnimalType = "Куче",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Hill's Science Plan Puppy",
                    ShortDescription = "Специално разработена суха храна за подрастващи кученца.",
                    LongDescription = "Hill's Science Plan Puppy е висококачествена суха храна, специално разработена за подрастващи кученца. Тя съдържа точния баланс от хранителни вещества, необходими за здравословен растеж и развитие, включително високо качествени протеини за изграждане на силни мускули, и DHA от рибено масло за подпомагане на здравето на мозъка и зрението. Храната е лесносмилаема и съдържа балансирано съотношение на калций и фосфор за здрави кости и зъби.",
                    Price = 28.99m,
                    ImageUrl = "~/Images/Products/Dogs/DryFoods/Hills_Science_Plan_Puppy.jpg",
                    AnimalType = "Куче",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Purina Pro Plan Adult",
                    ShortDescription = "Висококачествена суха храна за активни възрастни кучета.",
                    LongDescription = "Purina Pro Plan Adult е висококачествена суха храна, специално разработена за активни възрастни кучета. Тя съдържа високо качествени протеини от пиле като основна съставка, за поддържане на здрава мускулна маса, и оптимален баланс от хранителни вещества за цялостно здраве и жизненост. Храната включва и специфични хранителни вещества за поддържане на здравето на сърцето, както и омега-3 мастни киселини за здрава кожа и козина.",
                    Price = 39.99m,
                    ImageUrl = "~/Images/Products/Dogs/DryFoods/Purina_Pro_Plan_Adult_Dog.jpg",
                    AnimalType = "Куче",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Acana Wild Prairie",
                    ShortDescription = "Суха храна с високо съдържание на месо за кучета от всички възрасти.",
                    LongDescription = "Acana Wild Prairie е висококачествена суха храна за кучета от всички възрасти, с високо съдържание на месо. Тя съдържа 70% месо, включително пиле, пуйка, риба и яйца, които осигуряват богат източник на протеини за изграждане и поддържане на здрава мускулна маса. Храната включва и разнообразие от плодове, зеленчуци и билки, които предоставят естествени източници на антиоксиданти, витамини и минерали. Не съдържа зърнени продукти, изкуствени добавки или консерванти.",
                    Price = 49.99m,
                    ImageUrl = "~/Images/Products/Dogs/DryFoods/Arcana_Wild_Pairie_Adult_Dog.jpg",
                    AnimalType = "Куче",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Orijen Six Fish",
                    ShortDescription = "Суха храна за кучета с шест вида прясна риба.",
                    LongDescription = "Orijen Six Fish е висококачествена суха храна за кучета от всички възрасти, съдържаща шест вида прясна риба - сьомга, херинга, бяла риба, скумрия, американска менхадена и сардини. Тази богата на протеини и омега-3 мастни киселини храна подпомага здравето на кожата и козината, както и цялостното здраве и жизненост на кучетата. Не съдържа зърнени продукти, изкуствени добавки или консерванти, а само висококачествени, натурални съставки.",
                    Price = 54.99m,
                    ImageUrl = "~/Images/Products/Dogs/DryFoods/ORIJEN_Six_Fish Dry_Dog_Food.jpg",
                    AnimalType = "Куче",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 6,
                    Name = "Royal Canin Wet Food",
                    ShortDescription = "Меки хапки в сос за възрастни кучета от малки породи.",
                    LongDescription = "Royal Canin Wet Food е висококачествена консервирана храна, специално разработена за поддържане на оптимално здраве и жизненост при кучетата. Произведена от внимателно подбрани съставки, включително високо качествени протеини, тази храна осигурява балансирано хранене и отличен вкус. Меката и сочна текстура я прави лесна за дъвчене и поглъщане, дори за кучета с чувствителни зъби или венци. Съдържа и добавени витамини и минерали за цялостно здраве. Предлага се в различни вкусове, за да задоволи предпочитанията на всяко куче.",
                    Price = 2.49m,
                    ImageUrl = "~/Images/Products/Dogs/WetFoods/Royal_Canin_Wet_Good.jpg",
                    AnimalType = "Куче",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Hill's Science Plan Wet Food",
                    ShortDescription = "Балансирана консервирана храна за кучета с чувствителна кожа.",
                    LongDescription = "Hill's Science Diet Wet Food е научно разработена консервирана храна, предназначена да осигури оптимално хранене за кучета във всеки етап от живота. Формулирана от ветеринарни диетолози, тази храна съдържа висококачествени протеини за поддържане на здрави мускули, балансирани мазнини за енергия и основни витамини и минерали за цялостно здраве. Меката текстура и апетитният аромат я правят привлекателна дори за най-капризните кучета. Предлага се в различни формули, пригодени за специфичните хранителни нужди на кучета от различни възрасти, размери и породи. Идеална за самостоятелно хранене или като допълнение към суха храна Hill's Science Diet.",
                    Price = 2.99m,
                    ImageUrl = "~/Images/Products/Dogs/WetFoods/Hills_Science_Diet_Wet_Food.jpg",
                    AnimalType = "Куче",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Purina Pro Plan Wet Food",
                    ShortDescription = "Консервирана храна с пиле и ориз за възрастни кучета.",
                    LongDescription = "Purina ONE SmartBlend е висококачествена консервирана храна, предназначена да осигури цялостно и балансирано хранене за вашето куче. Приготвена от внимателно подбрани съставки, включително истинско месо като основен протеин, тази храна подкрепя здравето на мускулите и жизнеността. Съдържа и сложни въглехидрати за енергия, както и основни витамини и минерали за поддържане на имунната система. Меката и сочна текстура, комбинирана с апетитен аромат, гарантира, че вашето куче ще се наслаждава на всяко хранене. Подходяща за самостоятелно хранене или като допълнение към суха храна.",
                    Price = 2.79m,
                    ImageUrl = "~/Images/Products/Dogs/WetFoods/Purina_ONE_SmartBlend.jpg",
                    AnimalType = "Куче",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 9,
                    Name = "Pedigree Chopped Ground Dinner",
                    ShortDescription = "Питателна и вкусна консервирана храна с истинско месо.",
                    LongDescription = "Pedigree Chopped Ground Dinner е питателна и вкусна консервирана храна за кучета, приготвена с висококачествени съставки, включително истинско месо. Нарязаните парченца във вкусен сос осигуряват привлекателна текстура и аромат, които кучетата обожават. Тази балансирана формула съдържа оптимално съотношение на протеини, мазнини и въглехидрати за поддържане на здравето и енергията на вашето куче. Обогатена е с основни витамини и минерали за подкрепа на имунната система и цялостното здраве. Лесна за сервиране и перфектна като самостоятелно хранене или като добавка към суха храна.",
                    Price = 1.99m,
                    ImageUrl = "~/Images/Products/Dogs/WetFoods/Pedigree_Chopped_Ground_Food.jpg",
                    AnimalType = "Куче",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "Cesar Classic Loaf in Sauce",
                    ShortDescription = "Премиум консервирана храна с изключителен вкус.",
                    LongDescription = "Cesar Classic Loaf in Sauce е премиум консервирана храна за кучета, приготвена с внимателно подбрани съставки за изключителен вкус и хранителна стойност. Класическото руло в апетитен сос е изкусително ястие, на което никое куче не може да устои. Произведена от висококачествени протеини, включително истинско месо, тази храна осигурява балансирано и пълноценно хранене. Меката текстура я прави подходяща дори за кучета с чувствителни зъби или венци. Предлага се в различни вкусове, вдъхновени от човешката кухня, за разнообразие и удоволствие при всяко хранене.",
                    Price = 2.49m,
                    ImageUrl = "~/Images/Products/Dogs/WetFoods/CESAR_Adult_Wet_Dog_Food.jpg",
                    AnimalType = "Куче",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 11,
                    Name = "Zuke's Mini Naturals",
                    ShortDescription = "Натурални лакомства без изкуствени добавки.",
                    LongDescription = "Zuke's Mini Naturals са вкусни и хранителни лакомства, приготвени от висококачествени, натурални съставки. Тези меки хапки са богати на протеини от истинско месо и не съдържат изкуствени добавки, царевица, соя или пшеница. Малкият им размер ги прави идеални за тренировка или като здравословна награда. Предлагат се в различни вкусове, включително пиле, заек и патица, за да задоволят вкусовите предпочитания на всяко куче. Zuke's Mini Naturals са чудесен избор за собственици, които търсят питателни и вкусни лакомства за своите кучета.",
                    Price = 4.99m,
                    ImageUrl = "~/Images/Products/Dogs/Treats/Zukes_Mini_Naturals_Dog.jpg",
                    AnimalType = "Куче",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 12,
                    Name = "Blue Buffalo Wilderness Treats",
                    ShortDescription = "Лакомства с високо съдържание на протеини за активни кучета.",
                    LongDescription = "Blue Buffalo Wilderness Treats са високопротеинови лакомства, вдъхновени от естествената диета на вълците. Приготвени с истински дивеч като главна съставка, тези лакомства осигуряват хранителна доза протеини за поддържане на силни мускули и енергични нива. Те не съдържат изкуствени аромати, оцветители или консерванти, което ги прави чудесен избор за кучета с чувствителни стомаси. Хрупкавата текстура помага за премахване на зъбната плака и поддържане на здрави зъби. Blue Buffalo Wilderness Treats са перфектни за активни кучета, нуждаещи се от питателна закуска между храненията.",
                    Price = 6.99m,
                    ImageUrl = "~/Images/Products/Dogs/Treats/Blue_Buffalo_Wilderness_Trail_Treats.jpg",
                    AnimalType = "Куче",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 13,
                    Name = "Greenies Dental Chews",
                    ShortDescription = "Лакомства за дентална грижа, препоръчани от ветеринари.",
                    LongDescription = "Greenies Dental Chews са клинично доказани лакомства за грижа за зъбите, които помагат за намаляване на зъбната плака и зъбния камък. Техният уникален текстура и форма осигуряват почистващо действие, което достига до задните зъби и е трудно достъпно с традиционното четкане. Приготвени от висококачествени, лесносмилаеми съставки, тези лакомства са хранителни и лесни за смилане. Препоръчват се от ветеринари за ежедневна употреба като част от цялостната дентална грижа. Greenies Dental Chews са достъпни в различни размери, за да отговарят на нуждите на кучета от всички породи.",
                    Price = 8.99m,
                    ImageUrl = "~/Images/Products/Dogs/Treats/Greenies_Original_Dog_Dental_Chew.jpg",
                    AnimalType = "Куче",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 14,
                    Name = "Pup-Peroni Original Beef Flavor",
                    ShortDescription = "Ароматни лакомства с говеждо за максимална наслада.",
                    LongDescription = "Pup-Peroni Original Beef Flavor са вкусни лакомства със завладяващ аромат на говеждо, на който кучетата не могат да устоят. Приготвени от истинско говеждо като основна съставка, тези меки хапки имат привлекателна текстура, която ги прави перфектни за тренировки или просто за глезене. Не съдържат изкуствени аромати или оцветители и са обогатени с витамини и минерали за поддържане на цялостното здраве. Малкият им размер ги прави идеални за кучета от всякакъв размер. Pup-Peroni Original Beef Flavor са чудесен начин да наградите вашето куче и да укрепите връзката помежду ви.",
                    Price = 3.99m,
                    ImageUrl = "~/Images/Products/Dogs/Treats/Pup-Peroni_Original_Lean_Beef_Flavor.jpg",
                    AnimalType = "Куче",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 15,
                    Name = "Wellness Soft Puppy Bites",
                    ShortDescription = "Нежни лакомства с натурални съставки за кученца.",
                    LongDescription = "Wellness Soft Puppy Bites са специално разработени лакомства за растящите нужди на кученцата. Произведени от внимателно подбрани, натурални съставки, включително истинско месо от заек и сьомга, тези меки хапки осигуряват висококачествени протеини за здрави мускули и DHA за подкрепа на мозъчното развитие. Обогатени са с витамини и минерали за цялостно здраве и не съдържат изкуствени оцветители, аромати или консерванти. Нежната им текстура ги прави лесни за дъвчене и поглъщане от малките усти. Wellness Soft Puppy Bites са перфектното лакомство за тренировка и награждаване на вашето малко кученце.",
                    Price = 5.99m,
                    ImageUrl = "~/Images/Products/Dogs/Treats/Wellness_Soft_Puppy_Bites.jpg",
                    AnimalType = "Куче",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 16,
                    Name = "NuVet Plus All-in-One Supplement",
                    ShortDescription = "Пълноценна добавка за цялостно здраве и жизненост.",
                    LongDescription = "NuVet Plus All-in-One Supplement е висококачествена хранителна добавка, разработена за поддържане на цялостното здраве и жизненост на кучетата. Тази мощна формула съдържа внимателно подбрана комбинация от витамини, минерали, антиоксиданти и билки, които работят синергично за подкрепа на имунната система, ставите, храносмилането и козината. Произведена от висококачествени, натурални съставки, тази добавка не съдържа изкуствени консерванти, оцветители или аромати. Подходяща за кучета от всички възрасти и породи, NuVet Plus е чудесен начин да осигурите на вашия домашен любимец оптимално здраве и дълголетие.",
                    Price = 39.99m,
                    ImageUrl = "~/Images/Products/Dogs/SupplementsVitamins/nuvet_plus.jpg",
                    AnimalType = "Куче",
                    CategoryId = 4
                },
                new Product
                {
                    Id = 17,
                    Name = "Zesty Paws Multivitamin Treats",
                    ShortDescription = "Вкусни мултивитаминни лакомства за ежедневна подкрепа.",
                    LongDescription = "Zesty Paws Multivitamin Treats са вкусни и питателни лакомства, обогатени с основни витамини и минерали за ежедневна подкрепа на здравето. Тези меки хапки съдържат комплекс от витамини от група B за енергийно ниво и метаболизъм, витамин Е за здрава кожа и козина, и витамин С за укрепване на имунната система. Обогатени са и с минерали като цинк, биотин и фолиева киселина за цялостно здраве. Приготвени от висококачествени, натурални съставки, тези лакомства не съдържат изкуствени консерванти, оцветители или аромати. Zesty Paws Multivitamin Treats са вкусен и удобен начин да осигурите на вашето куче необходимите хранителни вещества за оптимално здраве.",
                    Price = 24.99m,
                    ImageUrl = "~/Images/Products/Dogs/SupplementsVitamins/Zesty_Paws_Multivitamin.jpg",
                    AnimalType = "Куче",
                    CategoryId = 4
                },
                new Product
                {
                    Id = 18,
                    Name = "PetHonesty Omega-3 Fish Oil",
                    ShortDescription = "Чист рибен омега-3 за здрава кожа, козина и мозък.",
                    LongDescription = "PetHonesty Omega-3 Fish Oil е висококачествена добавка, осигуряваща чисти и концентрирани омега-3 мастни киселини от дива риба. Тези есенциални мастни киселини подпомагат здравето на кожата и козината, подкрепят мозъчната функция и зрението, и спомагат за облекчаване на възпаленията. Произведен от устойчиви източници и молекулярно дестилиран за премахване на тежки метали и други замърсители, този рибен омега-3 е безопасен и ефективен. Лесно се добавя към храната на вашето куче за ежедневна подкрепа. PetHonesty Omega-3 Fish Oil е чудесен избор за собственици, които търсят висококачествена добавка за поддържане на оптималното здраве на своите домашни любимци.",
                    Price = 19.99m,
                    ImageUrl = "~/Images/Products/Dogs/SupplementsVitamins/Pet_Honesty_Omega-3_Oil.jpg",
                    AnimalType = "Куче",
                    CategoryId = 4
                },
                new Product
                {
                    Id = 19,
                    Name = "VetriScience Laboratories GlycoFlex Joint Support",
                    ShortDescription = "Клинично доказана формула за здраве на ставите.",
                    LongDescription = "VetriScience Laboratories GlycoFlex Joint Support е клинично доказана добавка за подпомагане на здравето на ставите при кучета от всички възрасти и породи. Тази мощна формула съдържа глюкозамин, хондроитин и MSM, които работят заедно за подкрепа на хрущялната функция, облекчаване на възпаленията и подобряване на подвижността. Обогатена е с мангански аскорбат за стимулиране на производството на хрущял и зелени миди от Нова Зеландия за допълнителни противовъзпалителни ползи. Подходяща за ежедневна употреба, тази добавка е особено полезна за по-възрастни кучета, едри породи и работни кучета. VetriScience Laboratories GlycoFlex Joint Support е надежден избор за поддържане на здравето и комфорта на ставите на вашето куче през целия му живот.",
                    Price = 29.99m,
                    ImageUrl = "~/Images/Products/Dogs/SupplementsVitamins/VetriScience_GlycoFlex.jpg",
                    AnimalType = "Куче",
                    CategoryId = 4
                },
                new Product
                {
                    Id = 20,
                    Name = "Purina Pro Plan Veterinary Diets FortiFlora Probiotic",
                    ShortDescription = "Мощен пробиотик за подкрепа на храносмилателното здраве.",
                    LongDescription = "Purina Pro Plan Veterinary Diets FortiFlora Probiotic е пробиотична добавка, специално разработена за подкрепа на храносмилателното здраве при кучета. Тази мощна формула съдържа живи, активни култури от бактерии, които спомагат за възстановяване на баланса на чревната микрофлора и укрепване на имунната система. Доказано е, че помага при храносмилателен дискомфорт, диария и стомашно-чревни разстройства. Лесно се добавя към храната и е подходяща за ежедневна употреба. Препоръчва се от ветеринари за кучета, които се възстановяват от заболяване или преминават през стресиращи ситуации. Purina Pro Plan Veterinary Diets FortiFlora Probiotic е надежден избор за поддържане на оптималното храносмилателно здраве на вашето куче.",
                    Price = 34.99m,
                    ImageUrl = "~/Images/Products/Dogs/SupplementsVitamins/Purina_Pro_Plan_Fortiflora.jpg",
                    AnimalType = "Куче",
                    CategoryId = 4
                },
                new Product
                {
                    Id = 21,
                    Name = "Kong Classic",
                    ShortDescription = "Класическа играчка Kong за дъвчене и игра.",
                    LongDescription = "Класическата играчка Kong, изработена от здрава гума, която е идеална за дъвчене и игра. Може да се напълни с лакомства за допълнително забавление и стимулация.",
                    Price = 12.99m,
                    ImageUrl = "~/Images/Products/Dogs/Аccessories/KONG_Classic_Dog_Toy.jpg",
                    AnimalType = "Куче",
                    CategoryId = 5
                },
                new Product
                {
                    Id = 22,
                    Name = "FurHaven Orthopedic Dog Bed",
                    ShortDescription = "Ортопедично легло за кучета с мемори пяна.",
                    LongDescription = "Висококачествено ортопедично легло за кучета, с мемори пяна, която осигурява комфорт и поддръжка на ставите. Подходящо за кучета от всички възрасти и породи.",
                    Price = 49.99m,
                    ImageUrl = "~/Images/Products/Dogs/Аccessories/Furhaven_Orthopedic_Dog_Bed.jpg",
                    AnimalType = "Куче",
                    CategoryId = 5
                },
                new Product
                {
                    Id = 23,
                    Name = "Ruffwear Front Range Harness",
                    ShortDescription = "Удобен и здрав нагръдник за кучета.",
                    LongDescription = "Удобен и здрав нагръдник за кучета, с подплатени презрамки и лесно закопчаване. Идеален за разходки и приключения на открито.",
                    Price = 39.99m,
                    ImageUrl = "~/Images/Products/Dogs/Аccessories/Ruffwear_Front_Range_Dog_Harness.jpg",
                    AnimalType = "Куче",
                    CategoryId = 5
                },
                new Product
                {
                    Id = 24,
                    Name = "Chuckit! Ultra Ball",
                    ShortDescription = "Издръжлива топка за игра и апортиране.",
                    LongDescription = "Издръжлива топка за игра и апортиране, изработена от здрав материал, който издържа на агресивно дъвчене. Подходяща за игра на открито и в парка.",
                    Price = 9.99m,
                    ImageUrl = "~/Images/Products/Dogs/Аccessories/Chuckit!_Ultra_Ball.jpg",
                    AnimalType = "Куче",
                    CategoryId = 5
                },
                new Product
                {
                    Id = 25,
                    Name = "Nylabone Dura Chew",
                    ShortDescription = "Здрава играчка за дъвчене, подходяща за агресивни дъвкачи.",
                    LongDescription = "Здрава играчка за дъвчене, специално разработена за кучета, които обичат да дъвчат агресивно. Помага за поддържане на здрави зъби и венци, като същевременно предотвратява скуката.",
                    Price = 8.99m,
                    ImageUrl = "~/Images/Products/Dogs/Аccessories/Nylabone_Dura_Chew.jpg",
                    AnimalType = "Куче",
                    CategoryId = 5
                },
            };

            return products;
        }
    }
}
