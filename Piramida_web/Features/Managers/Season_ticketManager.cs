using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Season_ticket;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Season_ticketManager : ISeason_ticketManager
    {
        private readonly IMapper _mapper;
        private readonly ISeason_ticketRepository _season_ticketRepository;
        private readonly ISeason_ticketService _season_ticketServices;
        private readonly DataContext _dataContext;

        public Season_ticketManager(ISeason_ticketRepository season_ticketRepository, ISeason_ticketService season_ticketServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _season_ticketRepository = season_ticketRepository;
            _season_ticketServices = season_ticketServices;
            _dataContext = dataContext;
        }

        public void Creat(EditSeason_ticketDto editSeason_ticket)
        {
            var Season_ticket = _mapper.Map<Season_ticket>(editSeason_ticket);

            //System.Console.WriteLine($"Случайный Guid: {Season_ticket.Id}");

            _season_ticketRepository.Create(_dataContext, Season_ticket);

            _dataContext.SaveChanges();

        }

        public void Update(EditSeason_ticketDto editSeason_ticket)
        {
            var Season_ticket = _mapper.Map<Season_ticket>(editSeason_ticket);

            _season_ticketRepository.Update(_dataContext, Season_ticket);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _season_ticketRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Season_ticketDto GetSeason_ticket(Guid Id)
        {
            var season_ticket = _season_ticketRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Season_ticketDto>(season_ticket);
        }

        public Season_ticketDto[] GetListSeason_ticket(Season_ticketFilterDto season_ticketFilter)
        {
            var season_ticket = _season_ticketServices.GetSeason_ticketQueryable(_dataContext, season_ticketFilter, true)
                .Select(x => new Season_ticketDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ClientId = x.ClientId,
                    Time_of_purchase = x.Time_of_purchase,

                }).ToArray();
            return season_ticket;
        }
    }
}
