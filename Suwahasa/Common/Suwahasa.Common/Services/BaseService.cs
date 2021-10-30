using AutoMapper;
using System;

namespace Suwahasa.Common.Services
{
    public class BaseService
    {
        protected readonly IMapper mapper;

        public BaseService(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
