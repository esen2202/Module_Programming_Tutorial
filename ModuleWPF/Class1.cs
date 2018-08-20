using ModuleManager;
using System.Collections.Generic;

namespace ModuleWPF
{
    public class Class1: ModuleManagerAbs
    {
        public override string ModuleName { get; set; } = "Class Module WPF";

        public override List<Parameter> ModuleCalistir()
        {

            var form = new Form1();
            form.ShowDialog();

            //var list = new List<Parameter> {
            //    new Parameter{  Key = "22" , Value = "43"} ,
            //    new Parameter{  Key = "33" , Value = "24" }
            //};

            var list = Form1.list;
            return list;
        }
    }
}
