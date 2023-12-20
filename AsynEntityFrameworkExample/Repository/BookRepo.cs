using AsynEntityFrameworkExample.Data;
using AsynEntityFrameworkExample.Models;

namespace AsynEntityFrameworkExample.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext db;

        public BookRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddBook(Book book)
        {
            int result = 0;
            db.Books.Add(book);
            result=await db.SaveChangesAsync();
            return result;
            
        }

        public async Task<int> DeleteBook(int id)
        {
           var book=db.Books.Find(id);
            if(book!=null)
            {
                db.Books.Remove(book);
                int result=await db.SaveChangesAsync();
                return result;
            }
            else
            {
                return 0;
            }
        }

        public async Task<Book> GetBookById(int id)
        {
           var book=db.Books.Find(id);
           if(book!=null)
            {
                return  book;
            }
           else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return  db.Books.ToList();
        }

        public async Task<int> UpdateBook(Book book)
        {
            var b = db.Books.Find(book);
            if(b!=null)
            {
               b.Name = book.Name;
               b.Author = book.Author;
               b.Price = book.Price;
               int result = await db.SaveChangesAsync();
                return result;
            }
            else
            {
                return 0;
            }

        }
    }
}
