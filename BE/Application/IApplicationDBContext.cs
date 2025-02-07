using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;

using Domain.Entities;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IApplicationDBContext
    {

        DbSet<DgCore> dg_core { get; }
         DbSet<DgToRoles> dg_to_core { get; }
        DbSet<MasterDgTypes> master_Dg_Types { get; }
        DbSet<Role> role { get; }
        DbSet<DgField> dg_fields { get; }   
        DbSet<DgFieldCalculations> dg_field_calculations { get; }
        DbSet<DgFieldResponses> dg_field_responses { get; }
        DbSet<DgFieldCodes> dg_field_codes { get; }
        DbSet<DgFieldCPTCode> dg_field_cpt_code { get; }
        DbSet<MasterDgLookupDatasets> master_dg_lookup_datasets { get; }
        DbSet<MasterIcd>master_icd { get; }
        DbSet <MasterCpt> master_cpt { get; }       
        DbSet <Response> responsetable { get; }  
        DbSet<MultipleChoise> multiple_choise_table { get; }

       DbSet<TestDataSeeding> testDataSeedings{get; }   
        Task SaveChangesAsync();                  
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void PerformDataSeed<TEntity>(IEnumerable<TEntity> items, Func<TEntity, TEntity, bool> checkCondition)
            where TEntity : class;
    }
}
