//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KnilaTestEntities : DbContext
    {
        //public KnilaTestEntities()
        //    : base("name=KnilaTestEntities")
        //{
        //}
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblBook> tblBook { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> PriceofAllbooks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("PriceofAllbooks");
        }
    
        public virtual ObjectResult<SortByLAT_Result> SortByLAT()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SortByLAT_Result>("SortByLAT");
        }
    
        public virtual ObjectResult<SortByPLAT_Result> SortByPLAT()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SortByPLAT_Result>("SortByPLAT");
        }
    
        public virtual int splocal_Book_IUD(Nullable<int> transTypeID, ObjectParameter res)
        {
            var transTypeIDParameter = transTypeID.HasValue ?
                new ObjectParameter("TransTypeID", transTypeID) :
                new ObjectParameter("TransTypeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("splocal_Book_IUD", transTypeIDParameter, res);
        }
    }
}
