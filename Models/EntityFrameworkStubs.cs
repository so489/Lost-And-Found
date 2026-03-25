// Minimal stubs for System.Data.Entity types so the project compiles without EF installed.
// These are temporary and should be removed once you install the full EntityFramework package.
using System;
using System.Collections.Generic;

namespace System.Data.Entity
{
    // Minimal DbContext stub with a constructor that accepts a name/connection string.
    public class DbContext : IDisposable
    {
        public DbContext() { }
        public DbContext(string nameOrConnectionString) { }
        public void Dispose() { }
    }

    // Minimal DbSet stub — simple List<T> wrapper for compilation.
    public class DbSet<T> : List<T>
        where T : class
    {
        public DbSet() : base() { }
    }
}
