namespace HotelManagement.Persistence;

public class DbInitializer
{
    public static void Initialize(HotelManagementDbContext context)
    {
        context.Database.EnsureCreated();
    }

}