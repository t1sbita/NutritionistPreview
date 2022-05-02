using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Infrastructure.Data.Context;
using NutritionistPreview.Api.Infrastructure.Data.Repository.Base;
using NutritionistPreview.Api.Infrastructure.Interfaces;

namespace NutritionistPreview.Api.Infrastructure.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(NutritionistContext contexto) : base(contexto)
        {
        }
    }
}
