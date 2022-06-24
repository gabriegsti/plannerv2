using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class AulaRepositorio
    {
        private readonly Contexto _contexto;
           
        public AulaRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Aula aula)
        {
            _contexto.Add(aula);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Aula aula)
        {
            _contexto.Entry(aula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Aula> Buscar()
        {
            return _contexto.Aula.AsEnumerable();
        }

        public Aula Buscar(int? id )
        {
            return _contexto.Aula.FirstOrDefault(x => x.Id_Aula == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Aula.FirstOrDefault(x => x.Id_Aula == id));
            _contexto.SaveChanges();
        }
    }
}
