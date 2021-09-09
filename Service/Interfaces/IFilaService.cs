using System;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFilaService
    {
        Task Enviar(decimal proposta, DateTime data_nascimento, decimal prazo);
    }
}