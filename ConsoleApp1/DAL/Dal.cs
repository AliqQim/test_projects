using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        private readonly IMapper _mapper;

        public Dal(IMapper mapper)
        {
            _mapper = mapper;
        }
        internal IEnumerable<DalEntity> GetInfo()
        {
            return new List<DalEntity>
            {
                new DalEntity { Name="aaa", Count = 111 },
                new DalEntity { Name="bbb", Count = 222 },
            };
        }

        public IEnumerable<DalDto> RequestDataFromDal()
        {
            return _mapper.Map<IEnumerable<DalDto>>(GetInfo());
        }
    }

    public class DalEntity
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class DalDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class DalDtoProfile: Profile
    {
        public DalDtoProfile()
        {
            CreateMap<DalEntity, DalDto>();
        }
    }
}
