using Application;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbContextClass : DbContext, IApplicationDBContext
    {

        public DbContextClass(DbContextOptions options) : base(options) { }

        public DbSet<DgCore> dg_core => Set<DgCore>();

        public DbSet<DgToRoles> dg_to_core => Set<DgToRoles>();
        public DbSet<MasterDgTypes> master_Dg_Types => Set<MasterDgTypes>();
        public DbSet<Role> role => Set<Role>();


     

        public DbSet<DgField> dg_fields => Set<DgField>();

        public DbSet<DgFieldCalculations> dg_field_calculations => Set<DgFieldCalculations>();

        public DbSet<DgFieldResponses> dg_field_responses => Set<DgFieldResponses>();

        public DbSet<DgFieldCodes> dg_field_codes => Set<DgFieldCodes>();

        public DbSet<DgFieldCPTCode> dg_field_cpt_code => Set<DgFieldCPTCode>();

        public DbSet<MasterDgLookupDatasets> master_dg_lookup_datasets => Set<MasterDgLookupDatasets>();

        public DbSet<MasterIcd> master_icd => Set<MasterIcd>();

        public DbSet<MasterCpt> master_cpt => Set<MasterCpt>();

        public DbSet<Response> responsetable => Set<Response>();

        public DbSet<MultipleChoise> multiple_choise_table => Set<MultipleChoise>();

        public DbSet<TestDataSeeding> testDataSeedings => Set<TestDataSeeding>();

        public DbSet<MasterDgFieldTypes> master_dg_field_types => Set<MasterDgFieldTypes>();    



        public async Task SaveChangesAsync()
        {


            await base.SaveChangesAsync();
        }
        public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void PerformDataSeed<TEntity>(IEnumerable<TEntity> items, Func<TEntity, TEntity, bool> checkCondition)
      where TEntity : class
        {
            var dbSet = this.Set<TEntity>();

            // Load all existing entities from the database into memory
            var existingEntities = dbSet.ToList();

            foreach (var item in items)
            {
                // Ensure the ID is not set (assuming the ID property is named "Id")
                var property = typeof(TEntity).GetProperty("Id");
                if (property != null && property.PropertyType == typeof(int))
                {
                    property.SetValue(item, 0);
                }

                // Check if any entity in the existingEntities matches the condition
                var exists = existingEntities.Any(existingItem => checkCondition(existingItem, item));

                if (!exists)
                {
                    dbSet.Add(item);
                }
            }

            this.SaveChanges(); // Save changes to the database
        }

    }
}
