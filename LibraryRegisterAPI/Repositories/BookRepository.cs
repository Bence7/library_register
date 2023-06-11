namespace LibraryRegisterAPI.Repositories
{
    using LibraryEntityFramework;
    using LibraryRegisterAPI.Models.Entities;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository class for managing books.
    /// </summary>
    public class BookRepository : IEntityRepository<Book>
    {
        private readonly LibraryDbContext dbContext;

        /// <summary >
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing the book entities.</param>
        public BookRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="entity">The book entity to be added.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Add(Book entity)
        {
            try
            {
                this.dbContext.Book.Add(entity);
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        // TODO (Serilog): Ütköző kulcs hiba (Duplikált rekord)
                    }
                    else if (sqlException.Number == 547)
                    {
                        // TODO (Serilog): Külső kulcs hiba (Referenciális integritás megsértése)
                    }
                    else
                    {
                        // TODO (Serilog): Egyéb SQL Server-specifikus hiba
                    }
                }
                else
                {
                    // TODO (Serilog): Általános adatbázis hiba
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Általános hiba
                return false;
            }
        }


        /// <summary>
        /// Deletes a book from the database.
        /// </summary>
        /// <param name="id">The ID of the book to be deleted.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var book = await this.dbContext.Book.FindAsync(id);

                if (book == null)
                {
                    return false; // Könyv nem található
                }

                this.dbContext.Book.Remove(book);
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                // TODO (Serilog): Adatbázis hiba
                return false;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Egyéb hiba
                return false;
            }
    }


        /// <summary>
        /// Retrieves a book from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to be retrieved.</param>
        /// <returns>The book entity if found, otherwise null.</returns>
        public async Task<Book> Get(int id)
        {
            var book = await this.dbContext.Book.FindAsync(id);

            return book!;
        }


        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>A collection of all books in the database.</returns>
        public async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                var books = await this.dbContext.Book.ToListAsync();

                return books;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Book>();
            }
        }

        public async Task<IEnumerable<Book>> GetAvailable()
        {
            try
            {
                var availableBooks = await dbContext.Book
                                            .Where(b => !dbContext.Rental.Any(r => r.BookId == b.Id && r.RentalStatus))
                                            .ToListAsync();
                return availableBooks;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Book>();
            }
        }

        public async Task<IEnumerable<Book>> GetUnavailable()
        {
            try
            {
                var availableBooks = await dbContext.Book
                                            .Where(b => dbContext.Rental.Any(r => r.BookId == b.Id && r.RentalStatus))
                                            .ToListAsync();
                return availableBooks;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Book>();
            }
        }

        /// <summary>
        /// Updates the details of a book in the database.
        /// </summary>
        /// <param name="id">The ID of the book to be updated.</param>
        /// <param name="entity">The updated book entity.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Update(int id, Book entity)
        {
            try
            {
                var book = await this.dbContext.Book.FindAsync(id);

                if (book == null)
                {
                    return false;
                }

                book.Title = entity.Title;
                book.Author = entity.Author;
                book.PublishDate = entity.PublishDate;
                book.Publisher = entity.Publisher;

                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                // TODO (Serilog): Adatbázis hiba
                return false;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba kezelése
                return false;
            }
        }
    }
}
