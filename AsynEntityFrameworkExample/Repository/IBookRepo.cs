using AsynEntityFrameworkExample.Models;

namespace AsynEntityFrameworkExample.Repository
{
    public interface IBookRepo
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);

        Task<int> AddBook(Book book);

        Task<int> UpdateBook(Book book);

        Task<int> DeleteBook(int id);
    }
}
