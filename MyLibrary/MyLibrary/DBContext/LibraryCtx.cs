//namespace MyLibrary.DBContext
//{
//    using System;
//    using System.Data.Entity;
//    using System.Linq;

//    public class LibraryCtx : DbContext
//    {
//        // Your context has been configured to use a 'LibraryCtx' connection string from your application's 
//        // configuration file (App.config or Web.config). By default, this connection string targets the 
//        // 'MyLibrary.DBContext.LibraryCtx' database on your LocalDb instance. 
//        // 
//        // If you wish to target a different database and/or database provider, modify the 'LibraryCtx' 
//        // connection string in the application configuration file.
//        public LibraryCtx()
//            : base("name=LibraryCtx")
//        {
//        }

//        // Add a DbSet for each entity type that you want to include in your model. For more information 
//        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

//        // public virtual DbSet<MyEntity> MyEntities { get; set; }
//        //public virtual DbSet<Author> Authors { get; set; }
//        //public virtual DbSet<Book> Books { get; set; }
//        //public virtual DbSet<BookStatus> BookStatuses { get; set; }
//        //public virtual DbSet<Category> Categories { get; set; }
//        //public virtual DbSet<CoverType> CoverTypies { get; set; }
//        //public virtual DbSet<Description> Descriptions { get; set; }
//        //public virtual DbSet<Edition> Editions { get; set; }
//        //public virtual DbSet<FileExtension> FileExtensions { get; set; }
//        //public virtual DbSet<ISBN> ISBNs { get; set; }
//        //public virtual DbSet<Language> Languages { get; set; }
//        //public virtual DbSet<LanguageList> LanguageLists { get; set; }
//        //public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }
//        //public virtual DbSet<Tag> Tags { get; set; }
//        //public virtual DbSet<User> Users { get; set; }
//    }

//    //public class MyEntity
//    //{
//    //    public int Id { get; set; }
//    //    public string Name { get; set; }
//    //}
//}