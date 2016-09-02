using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Common;
using WebShop.Core;

namespace WebShop.Application
{
    public class ConfigOptionsAppService : IConfigOptionsAppService
    {
        private readonly IConfigOptionsRepository _ConfigOptionsRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public ConfigOptionsAppService(IConfigOptionsRepository ConfigOptionsyRepository)
        {
            _ConfigOptionsRepository = ConfigOptionsyRepository;
            Mapper.CreateMap<ConfigOptionsDTO, ConfigOptions>();
            Mapper.CreateMap<ConfigOptions, ConfigOptionsDTO>();
        }

        public async Task<ListConfigOptionsRs> GetAllOptions()
        {
            try
            {
                List<ConfigOptions> ConfigOptionses = await _ConfigOptionsRepository.GetAllListAsync();
                return new ListConfigOptionsRs()
                {
                    Options = ConfigOptionses.MapTo<List<ConfigOptionsDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetConfigOptionsRs> GetOptionById(GetConfigOptionsRq rq)
        {
            ConfigOptions ConfigOptions = await _ConfigOptionsRepository.GetAsync(rq.Id);

            return new GetConfigOptionsRs()
            {
                Option = ConfigOptions.MapTo<ConfigOptionsDTO>()
            };
        }

        public async Task<GetConfigOptionsRs> GetOptionByKey(GetConfigOptionsRq rq)
        {
            ConfigOptions ConfigOptions = await _ConfigOptionsRepository.GetOptionByKeyAsync(rq.OptionKey);

            return new GetConfigOptionsRs()
            {
                Option = ConfigOptions.MapTo<ConfigOptionsDTO>()
            };
        }

        public async Task<CreateConfigOptionsRs> CreateOption(CreateConfigOptionsRq rq)
        {
            try
            {
                rq.Option.CreateDate = DateTime.Now;
                ConfigOptions insertOption = rq.Option.MapTo<ConfigOptions>();
                rq.Option.Id = await _ConfigOptionsRepository.InsertAndGetIdAsync(insertOption);

                return new CreateConfigOptionsRs()
                {
                    Option = rq.Option
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateConfigOptionsRs> UpdateOption(UpdateConfigOptionsRq rq)
        {
            try
            {
                rq.Option.UpdateDate = DateTime.Now;
                ConfigOptions updateOption = rq.Option.MapTo<ConfigOptions>();
                updateOption = await _ConfigOptionsRepository.UpdateAsync(updateOption);

                return new UpdateConfigOptionsRs()
                {
                    Option = updateOption.MapTo<ConfigOptionsDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteConfigOptionsRs> DeleteOption(DeleteConfigOptionsRq rq)
        {
            try
            {
                ConfigOptions deleteOption = rq.Option.MapTo<ConfigOptions>();
                await _ConfigOptionsRepository.DeleteAsync(deleteOption);

                return new DeleteConfigOptionsRs()
                {
                    Option = deleteOption.MapTo<ConfigOptionsDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
