using ModuleManager;
using System;
using System.Collections.Generic;

namespace ModuleClass1
{
    public class Class1 : ModuleManagerAbs
    {
        public override string ModuleName { get; set; } = "Class Module 1";

        public override List<Parameter> ModuleCalistir()
        {

            var list = new List<Parameter> {
                new Parameter{  Key = "Key1" , Value = "Value1"} ,
                new Parameter{  Key = "Key2" , Value = "Value2" }
            };

            return list;
        }
    }
}
