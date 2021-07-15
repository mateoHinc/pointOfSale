using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace pointOfSale.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new pointOfSale.App(), args);
            host.Run();
        }
    }
}
