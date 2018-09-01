using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MvcFrameForProjectDal
{
    public class SQlProc :DbContext
    {
        public SQlProc(string DateTable)
            : base(DateTable)
        {
                
        }


    }
}
