
using Microsoft.EntityFrameworkCore;
using SaudeIA.Models;
using System;

namespace SaudeIA.Data
{
  public class Context : DbContext
  {
    public DbSet<DetalhesModel> Hotel { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    { 

    }
  }
}