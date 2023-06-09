namespace LibraryRegisterAPI.Repositories
{
    using LibraryEntityFramework;
    using LibraryRegisterAPI.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository class for managing members.
    /// </summary>
    public class MemberRepository : IEntityRepository<Member>
    {
        private readonly LibraryDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing the member entities.</param>
        public MemberRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new member to the database.
        /// </summary>
        /// <param name="entity">The member entity to be added.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Add(Member entity)
        {
            try
            {
                this.dbContext.Member.Add(entity);
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
        /// Deletes a member from the database.
        /// </summary>
        /// <param name="id">The ID of the member to be deleted.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var member = await this.dbContext.Member.FindAsync(id);

                if (member == null)
                {
                    return false;
                }

                this.dbContext.Member.Remove(member);
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
        /// Retrieves a member from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the member to be retrieved.</param>
        /// <returns>The member entity if found, otherwise null.</returns>
        public async Task<Member> Get(int id)
        {
            var member = await this.dbContext.Member.FindAsync(id);

            return member!;
        }


        /// <summary>
        /// Retrieves all members from the database.
        /// </summary>
        /// <returns>A collection of all members in the database.</returns>
        public async Task<IEnumerable<Member>> GetAll()
        {
            try
            {
                var members = await this.dbContext.Member.ToListAsync();

                return members;
            }
            catch (Exception ex)
            {
                // TODO (Serilog): Hiba
                return Enumerable.Empty<Member>();
            }
        }


        /// <summary>
        /// Updates the details of a member in the database.
        /// </summary>
        /// <param name="id">The ID of the member to be updated.</param>
        /// <param name="entity">The updated member entity.</param>
        /// <returns>A boolean value indicating whether the operation was successful or not.</returns>
        public async Task<bool> Update(int id, Member entity)
        {
            try
            {
                var member = await this.dbContext.Member.FindAsync(id);

                if (member == null)
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
