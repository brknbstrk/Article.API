using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Article.Infrastructure
{
    public interface IRepository<TEntitiy,PkType>
    {
        IEnumerable<TEntitiy> GetAll();
        TEntitiy GetById(PkType id);
        TEntitiy Update(TEntitiy entity);
        TEntitiy Add(TEntitiy entity);
        TEntitiy Delete(PkType id);
        void Commit();

    }
}
