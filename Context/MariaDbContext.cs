using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Context
{
  public partial class MariaDbContext : DbContext
  {
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
    {
    }

    public virtual DbSet<WeatherForecastDataModel> weatherforecasts { get; set; }
  }
}