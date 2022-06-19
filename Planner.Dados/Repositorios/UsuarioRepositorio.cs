using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly Contexto _contexto;
           
        public UsuarioRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Usuario usuario)
        {
            _contexto.Add(usuario);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            _contexto.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Usuario> Buscar()
        {
            return _contexto.Usuario.AsEnumerable();
        }

        public Usuario Buscar(int id )
        {
            return _contexto.Usuario.FirstOrDefault(x => x.Id_Usuario == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Usuario.FirstOrDefault(x => x.Id_Usuario == id));
            _contexto.SaveChanges();
        }
    }
}
