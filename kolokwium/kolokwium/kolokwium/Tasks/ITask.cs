using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szymon_Guzik_13659.Tasks {
    interface ITask: IComparable<ITask> {
        string Name { get; set; }
    }
}
