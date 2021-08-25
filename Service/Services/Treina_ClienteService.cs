using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_ClienteService : ITreina_ClienteService
    {
        private readonly IMapper _mapper;
        private readonly ITreina_ClienteRepository _treina_ClienteRepository;
        public Treina_ClienteService(IMapper mapper, ITreina_ClienteRepository treina_ClienteRepository)
        {
            _mapper = mapper;
            _treina_ClienteRepository = treina_ClienteRepository;
        }
    }
}