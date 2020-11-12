using System;
using System.Collections.Generic;
using System.Text;
using ShoeStore.Entities;

namespace ShoeStore.Fillers
{
    public interface IDataFiller
    {
        public void Fill(DataContext dataContext);
    }
}
