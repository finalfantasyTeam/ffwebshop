using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ConfigOptionsAppService : IConfigOptionsAppService
    {
        private readonly IConfigOptionsRepository _configOptionsRepository;

        public ConfigOptionsAppService(IConfigOptionsRepository configOptionsRepository)
        {
            _configOptionsRepository = configOptionsRepository;
            Mapper.CreateMap<ConfigOptions, ConfigOptionsDTO>();
            Mapper.CreateMap<ConfigOptionsDTO, ConfigOptions>();
        }

        public async Task<ListConfigOptionsRs> GetAllConfigOptions()
        {
            try
            {
                List<ConfigOptions> configOptions = await _configOptionsRepository.GetAllListAsync();
                return new ListConfigOptionsRs()
                {
                    Options = configOptions.MapTo<List<ConfigOptionsDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetConfigOptionsRs> GetConfigOption(GetConfigOptionsRq rq)
        {
            try
            {
                ConfigOptions configOption = await _configOptionsRepository.GetAsync(rq.Id);

                return new GetConfigOptionsRs()
                {
                    Option = configOption.MapTo<ConfigOptionsDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateConfigOptionsRs> CreateConfigOption(CreateConfigOptionsRq rq)
        {
            try
            {
                ConfigOptions insertConfigOption = rq.Option.MapTo<ConfigOptions>();
                insertConfigOption.CreateDate = DateTime.Now;
                insertConfigOption.Id = await _configOptionsRepository.InsertAndGetIdAsync(insertConfigOption);

                return new CreateConfigOptionsRs()
                {
                    Option = insertConfigOption.MapTo<ConfigOptionsDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateConfigOptionsRs> UpdateConfigOption(UpdateConfigOptionsRq rq)
        {
            try
            {
                ConfigOptions updateConfigOption = rq.Option.MapTo<ConfigOptions>();
                updateConfigOption.UpdateDate = DateTime.Now;
                updateConfigOption = await _configOptionsRepository.UpdateAsync(updateConfigOption);

                return new UpdateConfigOptionsRs()
                {
                    Option = updateConfigOption.MapTo<ConfigOptionsDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteConfigOptionsRs> DeleteConfigOption(DeleteConfigOptionsRq rq)
        {
            try
            {
                ConfigOptions deleteConfigOption = rq.Option.MapTo<ConfigOptions>();
                await _configOptionsRepository.DeleteAsync(deleteConfigOption);

                return new DeleteConfigOptionsRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
