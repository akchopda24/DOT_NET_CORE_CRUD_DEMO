using CRUDDemo.Entities.CustomEntities;
using CRUDDemo.Entities.GenericResponse;
using System.Threading.Tasks;

namespace CRUDDemo.BusinessLogic.Interface
{
    public interface IUsersService
    {
        Task<IListResponse<DtoUsers>> GetUsersAsync();
        Task<IListResponse<DtoUsers>> GetUserByIdAsync(int stateId);
        Task<ISingleResponse<DtoUsers>> AddUserAsync(DtoUsers model);
        Task<ISingleResponse<DtoUsers>> UpdateUserAsync(DtoUsers model);
        Task<ISingleResponse<DtoUsers>> DeleteUserByIdAsync(int id);
    }
}
