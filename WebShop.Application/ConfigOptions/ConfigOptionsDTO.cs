using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ConfigOptions))]
    public class ConfigOptionsDTO : EntityDto
    {
        public ConfigOptionsDTO() 
        { }

        public int? AppId { get; set; }
        public string OptionKey { get; set; }
        public string OptionValue { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string Notes { get; set; }
    }
}
