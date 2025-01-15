using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        void CrearGenero(Genero genero);
        Guid ObtenerGUID();
        Task<Genero> ObtenerPorId(int id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
