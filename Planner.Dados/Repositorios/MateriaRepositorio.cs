using Microsoft.EntityFrameworkCore;
using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class MateriaRepositorio
    {
        private readonly Contexto _contexto;
           
        public MateriaRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Materia materia)
        {
            _contexto.Add(materia);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Materia materia)
        {
            _contexto.Entry(materia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Materia> Buscar()
        {
            return _contexto.Materia.AsEnumerable();
        }

        public Materia Buscar(int id )
        {
            return _contexto.Materia.FirstOrDefault(x => x.Id_Materia == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Materia.FirstOrDefault(x => x.Id_Materia == id));
            _contexto.SaveChanges();
        }
    }
}
