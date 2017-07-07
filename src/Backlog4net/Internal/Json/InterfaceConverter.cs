using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Converters;
namespace Backlog4net.Internal.Json
{
    internal class InterfaceConverter<TInterface, TConcrete> : CustomCreationConverter<TInterface>
        where TConcrete : TInterface, new()
    {
        public override TInterface Create(Type objectType) => new TConcrete();
    }
}
