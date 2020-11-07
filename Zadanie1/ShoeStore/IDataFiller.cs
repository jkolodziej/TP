using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public interface IDataFiller
    {
        public void Fill(DataContext dataContext);
    }
}
