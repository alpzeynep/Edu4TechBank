﻿using Edu4TechBankEL.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.InterfacesOfManagers
{
    public interface IBaseManager<T, TDTO, Tid>
    {
        public IDataResult<ICollection<TDTO>> GetAll(string[]? joinTables = null);
        public IDataResult<ICollection<TDTO>> GetSomeAll(Expression<Func<TDTO, bool>>? whereFilter = null, string[]? joinTables = null);

        IDataResult<TDTO> GetById(Tid id);

        public IDataResult<TDTO> GetbyCondition(Expression<Func<TDTO, bool>>? whereFilter = null, string[]? joinTables = null);
        
        public IResult Add(TDTO entity);

        public IResult Update(TDTO entity);

        public IResult Delete(TDTO entity);
    }
}
