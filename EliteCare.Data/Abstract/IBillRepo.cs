using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Abstract
{
    public interface IBillRepo
    {
        public Bill GetByOrderddId(int oderdId);
    }
}
