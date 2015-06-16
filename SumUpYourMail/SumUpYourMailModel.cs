namespace SumUpYourMail
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SumUpYourMailModel : DbContext
    {
        // Your context has been configured to use a 'SumUpYourMailModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SumUpYourMail.SumUpYourMailModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SumUpYourMailModel' 
        // connection string in the application configuration file.
        public SumUpYourMailModel()
            : base("name=SumUpYourMailModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<MailProvider> MailProviders { get; set; }
         public virtual DbSet<UserMailAccount> UserMailAccounts { get; set; }
         public virtual DbSet<AccessDetail> AccessDetails { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

    }
    
    public class MailProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserMailAccount
    {
        public int Id { get; set; }
        public MailProvider Provider { get; set; }
        public User User { get; set; }
        public string EmailId { get; set; }
    }

    public class AccessDetail
    {
        public UserMailAccount Account { get; set; }
        public string RefreshToken { get; set; }

    }
}