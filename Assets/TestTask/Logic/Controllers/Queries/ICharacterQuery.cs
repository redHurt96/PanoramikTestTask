using System.Threading.Tasks;

namespace TestTask.Logic.Controllers.Queries
{
    public interface ICharacterQuery
    {
        Task<UserData> Get();
    }
}