using It_Expert.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace It_Expert.DataBase;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Data> Data { get; set; }
}
