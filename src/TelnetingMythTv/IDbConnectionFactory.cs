using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TelnetingMythTv
{
    public interface IDbConnectionFactory
    {
        IDbConnection create();
    }
}
