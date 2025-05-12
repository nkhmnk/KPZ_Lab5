using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.Visitor
{
    public interface IElementVisitor
    {
        void Visit(LightElementNode element);
        void Visit(LightTextNode textNode);
    }

}
