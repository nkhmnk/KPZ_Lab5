using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.State
{
    public interface IElementState
    {
        void AddClass(LightElementNode element, string cssClass);
        void RemoveClass(LightElementNode element, string cssClass);
    }

}
