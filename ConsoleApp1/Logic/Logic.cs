using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Logic
    {
        private readonly IMapper _mapper;
        private readonly Dal _dal;

        public Logic(IMapper mapper)
        {
            _mapper = mapper;
            _dal = new Dal(_mapper);
        }

        public IEnumerable<LogicDto> RequestDataFromLogic()
        {
            return _mapper.Map<IEnumerable<LogicDto>>(_dal.RequestDataFromDal());
        }
    }

    public class LogicDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
