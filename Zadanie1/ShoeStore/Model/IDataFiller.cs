using System;
using System.Collections.Generic;
using System.Text;
using ShoeStore.Model;

namespace ShoeStore
{
    public interface IDataFiller
    {
        public void Fill(DataContext dataContext);
    }
}
