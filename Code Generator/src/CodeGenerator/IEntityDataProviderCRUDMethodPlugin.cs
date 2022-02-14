using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KYSSPluginInterfaces
{
    public interface IEntityDataProviderCRUDMethodPlugin : IKYSSEntityPlugin
    {
        bool HandledSetIdentity { get; }
    }
}

