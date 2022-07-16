using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szymon_Guzik_13659.Tasks {
    class DescribedTask: PriorityTask, ITask {
        readonly string Descripton;

        public DescribedTask() {
            this.Name = "";
            this.Priority = 0;
            this.Descripton = "";
        }

        public DescribedTask(string name, int priority, string description) {
            this.Name = name;
            this.Priority = priority;
            this.Descripton = description;
        }

        public DescribedTask(DescribedTask task) {
            this.Name = task.Name;
            this.Priority = task.Priority;
            this.Descripton = task.Descripton;
        }

        public override string ToString() {
            return "{Name: "+ Name +"; Priority: "+ Priority +"; Description: "+ Descripton + "}";
        }
    }
}
