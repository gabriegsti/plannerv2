using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class EventoRepositorio
    {
        private readonly Contexto _contexto;
           
        public EventoRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Evento evento)
        {
            _contexto.Add(evento);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Evento evento)
        {
            _contexto.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Evento> Buscar()
        {
            return _contexto.Evento.AsEnumerable();
        }

        public Evento Buscar(int id )
        {
            return _contexto.Evento.FirstOrDefault(x => x.Id_Evento == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Evento.FirstOrDefault(x => x.Id_Evento == id));
            _contexto.SaveChanges();
        }
    }
}
