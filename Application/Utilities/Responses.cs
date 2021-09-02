using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Utilities
{
    public static class Responses{
        public static ResultViewModelResponse ApplicationErrorMessage()
        {
            return new ResultViewModelResponse
            {
                Message = "Erro interno na aplicação, por favor tente novamente mais tarde!!!",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModelResponse DomainErrorMessage(string message)
        {
            return new ResultViewModelResponse
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModelResponse DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModelResponse
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResultViewModelResponse UnauthorizedErrorMessage()
        {
            return new ResultViewModelResponse
            {
                Message = "Você não tem autorização!!!",
                Success = false,
                Data = null
            };
        }
    }
}