using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class AvaliacaoRepositorio
    {
        private readonly Contexto _contexto;
           
        public AvaliacaoRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Avaliacao avaliacao)
        {
            var materia = _contexto.Materia.FirstOrDefault(materia => materia.Id_Materia == avaliacao.MateriaId);

            Evento evento = new Evento(avaliacao.Titulo, avaliacao.Data_Hora, materia.Id_Usuario);

            _contexto.Evento.Add(evento);
            _contexto.SaveChanges();

            avaliacao.EventoId = evento.Id_Evento;
            avaliacao.MateriaId = 1;
            _contexto.Add(avaliacao);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            _contexto.Entry(avaliacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Avaliacao> Buscar()
        {
            return _contexto.Avaliacao.AsEnumerable();
        }

        public Avaliacao Buscar(int id )
        {
            return _contexto.Avaliacao.FirstOrDefault(x => x.Id_Avaliacao == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Avaliacao.FirstOrDefault(x => x.Id_Avaliacao == id));
            _contexto.SaveChanges();
        }
    }
}
