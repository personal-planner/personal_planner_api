using System.Threading.Tasks;

namespace DAL
{
    public interface IActCommand
    {
        public void CreateAct(ActModel model);
        public void ChangeAct(ActModel model);
    }
}
