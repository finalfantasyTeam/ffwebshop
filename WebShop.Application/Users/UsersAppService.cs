using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersAppService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            Mapper.CreateMap<Users, UsersDTO>();
            Mapper.CreateMap<UsersDTO, Users>();
        }

        public async Task<ListUsersRs> GetAllUsers()
        {
            try
            {
                List<Users> users = await _usersRepository.GetAllListAsync();
                return new ListUsersRs()
                {
                    Users = users.MapTo<List<UsersDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetUsersRs> GetUser(GetUsersRq rq)
        {
            try
            {
                Users user = await _usersRepository.GetAsync(rq.UserId);

                return new GetUsersRs()
                {
                    User = user.MapTo<UsersDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateUsersRs> CreateUser(CreateUsersRq rq)
        {
            try
            {
                Users insertUser = rq.User.MapTo<Users>();
                insertUser = await _usersRepository.InsertAsync(insertUser);

                return new CreateUsersRs()
                {
                    User = insertUser.MapTo<UsersDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateUsersRs> UpdateUser(UpdateUsersRq rq)
        {
            try
            {
                Users updateUser = rq.User.MapTo<Users>();
                updateUser = await _usersRepository.UpdateAsync(updateUser);

                return new UpdateUsersRs()
                {
                    User = updateUser.MapTo<UsersDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteUsersRs> DeleteUser(DeleteUsersRq rq)
        {
            try
            {
                Users deleteUser = rq.User.MapTo<Users>();
                await _usersRepository.DeleteAsync(deleteUser);

                return new DeleteUsersRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
