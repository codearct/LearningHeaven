
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Context;
using MealOrdering.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Server.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly MealOrderingDbContext context;
        private readonly IMapper mapper;

        public SupplierService(MealOrderingDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }


        public async Task<List<SupplierDTO>> GetSuppliers()
        {
            var list = await context.Suppliers//.Where(i => i.IsActive)
                      .ProjectTo<SupplierDTO>(mapper.ConfigurationProvider)
                      .OrderBy(i => i.CreateDate)
                      .ToListAsync();

            return list;
        }

        #region Post

        public async Task<SupplierDTO> CreateSupplier(SupplierDTO Supplier)
        {
            var dbSupplier = mapper.Map<MealOrdering.Server.Data.Models.Supplier>(Supplier);
            await context.AddAsync(dbSupplier);
            await context.SaveChangesAsync();

            return mapper.Map<SupplierDTO>(dbSupplier);
        }

        public async Task<SupplierDTO> UpdateSupplier(SupplierDTO Supplier)
        {
            var dbSupplier = await context.Suppliers.FirstOrDefaultAsync(i => i.Id == Supplier.Id);
            if (dbSupplier == null)
                throw new Exception("Supplier not found");

            mapper.Map(Supplier, dbSupplier);
            await context.SaveChangesAsync();

            return mapper.Map<SupplierDTO>(dbSupplier);
        }

        public async Task DeleteSupplier(Guid SupplierId)
        {
            var Supplier = await context.Suppliers.FirstOrDefaultAsync(i => i.Id == SupplierId);
            if (Supplier == null)
                throw new Exception("Supplier not found");

            int orderCount = await context.Suppliers.Include(i => i.Orders).Select(i => i.Orders.Count).FirstOrDefaultAsync();

            if (orderCount > 0)
                throw new Exception($"There are {orderCount} sub order for the order you are trying to delete");

            context.Suppliers.Remove(Supplier);
            await context.SaveChangesAsync();
        }

        public async Task<SupplierDTO> GetSupplierById(Guid Id)
        {
            var supplier = await context.Suppliers.Where(i => i.Id == Id)
                      .ProjectTo<SupplierDTO>(mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
            if (supplier == null)
                throw new Exception("Supplier not found");

            return supplier;
        }


        #endregion
    }
}