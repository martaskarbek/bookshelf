using Microsoft.EntityFrameworkCore;

namespace bookshelf.Model
{
    public class BookDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=/tmp/bookshelf.db");
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
    }
}