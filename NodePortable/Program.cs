using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodePortable
{
    class Program
    {
        static void Main(string[] args)
        {

            NodeInstaller n = new NodeInstaller();
            try
            {
                n.Install();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured");
            }

        }
    }
}
