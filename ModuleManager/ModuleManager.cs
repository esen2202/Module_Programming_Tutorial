using System;
using System.Collections.Generic;

namespace ModuleManager
{
    public abstract class ModuleManagerAbs : IModule
    {
        public virtual string ModuleName { get; set; } = "Standart Module";

        public abstract List<Parameter> ModuleCalistir();
        
    }
}
