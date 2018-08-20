using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleManager
{
    public interface IModule
    {
        string ModuleName { get; set; }

        List<Parameter> ModuleCalistir();

    }
}
