using DAL.Entries;
using System.Threading.Tasks;

namespace DAL.Commands.ActCommands
{
    public interface IActCommand
    {
        public Task CreateAct(ActModel model);
    }
}
