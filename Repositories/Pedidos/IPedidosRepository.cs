﻿using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;

namespace Sorveteria.Repositories.Pedidos
{
    public interface IPedidosRepository
    {
        public Task<List<GetPedidosResponse>> GetPedidos();
    }
}