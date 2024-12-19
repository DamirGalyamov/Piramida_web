using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Season_ticket_properties;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Season_ticket_propertiesManager : ISeason_ticket_propertiesManager
    {
        private readonly IMapper _mapper;
        private readonly ISeason_ticket_propertiesRepository _season_ticket_propertiesRepository;
        private readonly ISeason_ticket_propertiesService _season_ticket_propertiesServices;
        private readonly DataContext _dataContext;

        public Season_ticket_propertiesManager(ISeason_ticket_propertiesRepository season_ticket_propertiesRepository, ISeason_ticket_propertiesService season_ticket_propertiesServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _season_ticket_propertiesRepository = season_ticket_propertiesRepository;
            _season_ticket_propertiesServices = season_ticket_propertiesServices;
            _dataContext = dataContext;
        }

        public void Creat(EditSeason_ticket_propertiesDto editSeason_ticket_properties)
        {
            var Season_ticket_propertiess = _mapper.Map<Season_ticket_properties>(editSeason_ticket_properties);

            //System.Console.WriteLine($"Случайный Guid: {Season_ticket_properties.Id}");

            _season_ticket_propertiesRepository.Create(_dataContext, Season_ticket_propertiess);

            _dataContext.SaveChanges();

        }

        public void Update(EditSeason_ticket_propertiesDto editSeason_ticket_properties)
        {
            var Season_ticket_properties = _mapper.Map<Season_ticket_properties>(editSeason_ticket_properties);

            _season_ticket_propertiesRepository.Update(_dataContext, Season_ticket_properties);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _season_ticket_propertiesRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Season_ticket_propertiesDto GetSeason_ticket_properties(Guid Id)
        {
            var season_ticket_properties = _season_ticket_propertiesRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Season_ticket_propertiesDto>(season_ticket_properties);
        }

        public Season_ticket_propertiesDto[] GetListSeason_ticket_properties(Season_ticket_propertiesFilterDto season_ticket_propertiesFilter)
        {
            var season_ticket_properties = _season_ticket_propertiesServices.GetSeason_ticket_propertiesQueryable(_dataContext, season_ticket_propertiesFilter, true)
                .Select(x => new Season_ticket_propertiesDto
                {
                    Id = x.Id,
                    Season_ticketId = x.Season_ticketId,
                    Product_propertyId = x.Product_propertyId,

                }).ToArray();
            return season_ticket_properties;
        }
    }
}
