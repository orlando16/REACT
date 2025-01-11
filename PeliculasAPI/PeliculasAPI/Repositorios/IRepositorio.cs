using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        Guid ObtenerGUID();
        Task<Genero> ObtenerPorId(int id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
