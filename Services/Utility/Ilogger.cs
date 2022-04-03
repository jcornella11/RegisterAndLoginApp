using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services.Utility
{
    public interface Ilogger
    {
        void Debug(string message);

        void Info(string message);

        void Warn(string message);

        void Error(string message);
    }
}
