using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NutritionistPreview.Api.Business.Services.Base;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Exceptions;
using NutritionistPreview.Api.Core.Resources;
using NutritionistPreview.Api.Core.Util;
using NutritionistPreview.Api.Infrastructure.Interfaces;

namespace NutritionistPreview.Api.Business.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public ClientService(IClientRepository clientRepository, IAddressRepository addressRepository, ILogger<Client> logger) : base(logger)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public Task<Client> GetById(long id)
        {
            _logger.LogInformation("Method GetById ClientService");

            var result = _clientRepository.GetQueryable(x => x.Id == id)
                .Include(x => x.Address)
                .Include(x => x.Appointments)
                .FirstOrDefault();

            if (result == null)
                throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND).Replace("{PropertyName}", "Client"));

            return Task.FromResult(result);
        }

        public Task<Client> GetByDocumentNumber(long documentNumber)
        {
            _logger.LogInformation("Method GetByDocumentNumber ClientService");
            var result = _clientRepository.GetQueryable(x => x.DocumentNumber == documentNumber)
                 .Include(x => x.Address)
                 .Include(x => x.Appointments)
                 .FirstOrDefault();

            if (result == null)
                throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND).Replace("{PropertyName}", "Document Number"));

            return Task.FromResult(result);
        }

        public Task<Client> SaveClient(Client client)
        {
            _logger.LogInformation("Method AddClient ClientService");

            try
            {
                if (client == null || client?.DocumentNumber == null)
                {
                    throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.CLIENT_INVALID));
                }

                if (client.Id > 0)
                    UpdateData(client);
                else
                    _clientRepository.Add(client);

                _clientRepository.Save();

                return Task.FromResult(client);
            }
            catch (BusinessException ex)
            {
                if (ex.Problem is null)
                {
                    _logger.LogError(message: ex.Message, string.Format("{0}.{1}", typeof(ClientService), nameof(SaveClient)));
                    throw new BusinessException(ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Problem.Erros[0].FieldErros.First(), string.Format("{0}.{1}", typeof(ClientService), nameof(SaveClient)));
                    throw new BusinessException(ex.Problem.Erros[0].FieldErros.First());
                }
                throw;
            }

        }

        private void UpdateData(Client clientNew)
        {
            var client = _clientRepository.GetQueryable(x => x.Id == clientNew.Id)
                .Include(x => x.Address)
                .Include(x => x.Appointments)
                .FirstOrDefault();
            if (client == null)
                return;

            _clientRepository.Attach(client);
            _addressRepository.Attach(client.Address);

            MountClient(clientNew, client);
            MountAddress(clientNew.Address, client.Address);
        }

        private static void MountClient(Client newClient, Client dbClient)
        {
            dbClient.Name = newClient.Name;
            dbClient.DocumentNumber = newClient.DocumentNumber;
            dbClient.TelephoneNumber = newClient.TelephoneNumber;
            dbClient.Email = newClient.Email;
            dbClient.BirthDate = newClient.BirthDate;
        }

        private static void MountAddress(Address newAddress, Address dbAddress)
        {
            if (newAddress == null || dbAddress == null)
                return;

            dbAddress.Id = newAddress.Id;
            dbAddress.DescriptionAddress = newAddress.DescriptionAddress;
            dbAddress.Number = newAddress.Number;
            dbAddress.ZipCode = newAddress.ZipCode;
            dbAddress.City = newAddress.City;
            dbAddress.State = newAddress.State;
        }

        public Task<bool> Delete(long id)
        {
            _logger.LogInformation("Method Delete ClientService");

            var result = _clientRepository.Delete(id);

            _logger.LogInformation($"Success on delete entity: {result}");

            if (!result)
                throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND).Replace("{PropertyName}", "Cliente"));

            return Task.FromResult(result);
        }

    }
}
