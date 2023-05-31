using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ftp4u.Core.Abstraction
{
    public interface ITcpListenerFactory
    {
        ITcpListenerWrapper CreateTcpListenerWrapper();
    }
}