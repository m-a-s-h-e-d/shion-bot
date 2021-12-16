﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shion.Data.Context
{
    /// <summary>
    /// The class representing the <see cref="DbContext"/> for the Shion project.
    /// </summary>
    public class ShionDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShionDbContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions"/> to be passed.</param>
        public ShionDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
