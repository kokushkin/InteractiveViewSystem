using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public class ListModelEventArgs<DataModelType> : EventArgs 
    {
        public IListModel<DataModelType> List { get; private set; }

        public ListModelEventArgs(IListModel<DataModelType> _list)
        {
            List = _list;
        }
    }
}
