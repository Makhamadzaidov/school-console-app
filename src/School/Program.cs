using School.Pages;
using System.Threading.Tasks;

namespace School
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await MainMenuPage.RunAsync();
        }
    }
}
