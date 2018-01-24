using CustomerAppDAL.Repositories;
using CustomerAppDAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
