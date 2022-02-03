using AutoMapper;
using CRUDDemo.BusinessLogic.Interface;
using CRUDDemo.DataAccessLayer.DbModels;
using CRUDDemo.DataAccessLayer.GenericRepository;
using CRUDDemo.Entities.Constants;
using CRUDDemo.Entities.CustomEntities;
using CRUDDemo.Entities.GenericResponse;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRUDDemo.BusinessLogic.Services
{

    public class UsersService : IUsersService
    {
        private readonly IRepository<Users> _userRepository;

        public UsersService(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IListResponse<DtoUsers>> GetUsersAsync()
        {
            var response = new ListResponse<DtoUsers>();
            var getUserQuery = _userRepository.GetAll();
            if (await getUserQuery.AnyAsync())
            {
                var userDbModels = await getUserQuery.ToListAsync();
                response.Model = Mapper.Map<List<DtoUsers>>(userDbModels);

                response.SetResponse(false, StatusCode.DATA_FOUND_200, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, StatusCode.NO_DATA_FOUND_200, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.BadRequest);
            }
            return response;
        }

        public async Task<IListResponse<DtoUsers>> GetUserByIdAsync(int userId)
        {
            var response = new ListResponse<DtoUsers>();
            var getUserQuery = _userRepository.GetAll().Where(x => x.UserId == userId);
            if (await getUserQuery.AnyAsync())
            {
                var userDbModels = await getUserQuery.ToListAsync();
                response.Model = Mapper.Map<List<DtoUsers>>(userDbModels);

                response.SetResponse(false, StatusCode.DATA_FOUND_200, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, StatusCode.NO_DATA_FOUND_200, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.BadRequest);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUsers>> AddUserAsync(DtoUsers model)
        {
            var response = new SingleResponse<DtoUsers>();
            if (model.UserId == 0)
            {
                var userAdd = Mapper.Map<Users>(model);
                await _userRepository.AddAsync(userAdd);
                response.Model = Mapper.Map<DtoUsers>(userAdd);
                response.SetResponse(false, StatusCode.DATA_ADD_SUCCESS_200, HttpResponseMessages.DATA_ADD_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = model;
                response.SetResponse(true, StatusCode.BAD_REQUEST_400, HttpResponseMessages.ID_SHOULD_ZERO, HttpStatusCode.BadRequest);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUsers>> DeleteUserByIdAsync(int id)
        {
            var response = new SingleResponse<DtoUsers>();

            var userDbModel = await _userRepository.GetAll().Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (userDbModel != null)
            {
                await _userRepository.DeleteAsync(userDbModel);
                response.Model = Mapper.Map<DtoUsers>(userDbModel);
                response.SetResponse(false, StatusCode.DATA_DELETE_SUCCESS_200, HttpResponseMessages.DATA_DELETE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, StatusCode.BAD_REQUEST_400, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.BadRequest);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUsers>> UpdateUserAsync(DtoUsers model)
        {
            var response = new SingleResponse<DtoUsers>();

            var userDbModel = await _userRepository.GetAll().Where(x => x.UserId == model.UserId).FirstOrDefaultAsync();
            if (userDbModel != null)
            {
                userDbModel = Mapper.Map(model, userDbModel);
                await _userRepository.UpdateAsync(userDbModel);
                response.Model = Mapper.Map<DtoUsers>(userDbModel);
                response.SetResponse(false, StatusCode.DATA_UPDATE_SUCCESS_200, HttpResponseMessages.DATA_UPDATE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, StatusCode.BAD_REQUEST_400, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
