using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPlatformHttpMessageHandler
    {
        HttpMessageHandler GetHttpMessageHandler();
    }
}