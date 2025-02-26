
using Microsoft.EntityFrameworkCore;
using SaudeIA.Models;
using System;

namespace SaudeIA.Data
{
  public class Context : DbContext
  {
    public DbSet<UserModel> User { get; set; }

    public DbSet<BodyModel> Body { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
  }
}