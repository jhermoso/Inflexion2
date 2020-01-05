using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class WrapperPropertyEventArgs : EventArgs
    {
        public WrapperProperty WrapperPropertyChanged { get; private set; }

        public WrapperPropertyEventArgs(WrapperProperty wrapperPropertyChanged)
        {
            this.WrapperPropertyChanged = wrapperPropertyChanged;
        }

    }
}
