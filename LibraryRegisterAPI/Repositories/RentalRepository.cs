namespace LibraryRegisterAPI.Repositories
{
    using LibraryEntityFramework;
    using LibraryRegisterAPI.Models.Entities;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public class RentalRepository : IEntityRepository<Rental>
    {
        private readonly LibraryDbContext dbContext;

        public RentalRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Add(Rental entity)
        {
            try
            {
                this.dbContext.Rental.Add(entity);
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var rental = await this.dbContext.Rental.FindAsync(id);

                if (rental == null)
                {
                    return false;
                }

                this.dbContext.Rental.Remove(rental);
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

        public async Task<Rental> Get(int id)
        {
            var rental = await this.dbContext.Rental.FindAsync(id);

            return rental!;
        }

        public async Task<IEnumerable<Rental>> GetAll()
        {
            try
            {
                var rentals = await dbContext.Rental
                                            .Include(r => r.Member)
                                            .Include(r => r.Book)
                                            .ToListAsync();

                return rentals;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Rental>();
            }
        }

        public async Task<IEnumerable<Rental>> GetDetailed()
        {
            try
            {
                var rentals = await dbContext.Rental
                                            .Include(r => r.Member)
                                            .Include(r => r.Book)
                                            .ToListAsync();

                return rentals;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Rental>();
            }
        }

        public async Task<Rental> GetDetailed(int id)
        {
            var rental = await dbContext.Rental
                            .Include(r => r.Member)
                            .Include(r => r.Book)
                            .FirstOrDefaultAsync(r => r.Id == id);

            return rental!;
        }

        public async Task<Rental> GetDetailedByBookId(int bookId)
        {
            var rental = await dbContext.Rental
                            .Include(r => r.Member)
                            .Include(r => r.Book)
                            .FirstOrDefaultAsync(r => r.BookId == bookId);

            return rental!;
        }

        public async Task<IEnumerable<Rental>> GetAllDetailedByMemberId(int memberId)
        {
            var rental = await dbContext.Rental
                            .Include(r => r.Member)
                            .Include(r => r.Book)
                            .Where(r => r.MemberId == memberId)
                            .ToListAsync();

            return rental!;
        }

        public async Task<bool> Update(int id, Rental entity)
        {
            try
            {
                var rental = await this.dbContext.Rental.FindAsync(id);

                if (rental == null)
                {
                    return false;
                }

                // TODO

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
