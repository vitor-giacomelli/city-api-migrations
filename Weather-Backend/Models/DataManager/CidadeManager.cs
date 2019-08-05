using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Backend.Models.Repository;

namespace Weather_Backend.Models.DataManager
{
    public class CidadeManager : IDataRepository<Cidade>
    {
        readonly CidadeContext _cidadeContext;

        public CidadeManager(CidadeContext context)
        {
            _cidadeContext = context;
        }
        public void Add(Cidade entity)
        {
            _cidadeContext.Cidades.Add(entity);
            _cidadeContext.SaveChanges();
        }

        public void Delete(Cidade entity)
        {
            _cidadeContext.Cidades.Remove(entity);
            _cidadeContext.SaveChanges();
        }

        public IEnumerable<Cidade> GetAll()
        {
            return _cidadeContext.Cidades.ToList();
        }

        public Cidade GetById(long id)
        {
            return _cidadeContext.Cidades
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cidade caminhao, Cidade entity)
        {
            caminhao.CodigoCidade = entity.CodigoCidade;
            caminhao.NomeCidade = entity.NomeCidade;
            caminhao.Pais = entity.Pais;
            _cidadeContext.SaveChanges();
        }
    }
}
