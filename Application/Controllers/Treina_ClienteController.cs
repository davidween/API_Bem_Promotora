using System;
using System.Threading.Tasks;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITreina_ClienteService _treina_ClienteService;

        public Treina_ClienteController(IMapper mapper, ITreina_ClienteService treina_ClienteService)
        {
            _mapper = mapper;
            _treina_ClienteService = treina_ClienteService;
        }

        
    }
}