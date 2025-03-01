namespace Catalog.API.Repositories
{
    public class PlatesRepository(ApplicationDbContext dbContext) : IPlatesRepository
    {
        public IQueryable<Plate> Get() => dbContext.Plates;

        public async Task<bool> Reserve(Guid plateId)
        {
            var plate = await dbContext.Plates.FindAsync(plateId);

            if (plate is null)
            {
                //log error here 
                return false;
            }

            plate.Availability = Availability.Reserved;
            dbContext.Plates.Update(plate);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }

    public interface IPlatesRepository
    {
        public IQueryable<Plate> Get();

        public Task<bool> Reserve(Guid plateId);
    }
}