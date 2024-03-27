using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Model.Entities;
using Web_QLHoSo_So.Repository.KhoRepo;
using Web_QLHoSo_So.Repository.UserRepo;
using Web_QLHoSo_So.Service.common;

namespace Web_QLHoSo_So.Service.KhoService
{
    public class KhoService:IKhoService
    {
        private readonly IKhoRepo _repository;
        private readonly IMapper _mapper;
        public KhoService(IKhoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public bool Add(KhoDto dto)
        {
            return this._repository.Add(_mapper.Map<Kho>(dto));
        }
        public bool Delete(Guid id)
        {
            return this._repository.Delete(id);
        }
        public bool softDelete(Guid id)
        {
            return this._repository.softDelete(id);
        }
        public bool Update(KhoDto dto)
        {
            return _repository.Update(_mapper.Map<Kho>(dto));
        }
        public PageListResultBO<KhoDto> GetAll(KhoQuery? query)
        {
            int begin = (query.page * query.limit) - query.limit;
            var list = _mapper.Map<List<KhoDto>>(_repository.GetAll());
            if (query.keyword != string.Empty)
            {
                list = list.Where(x => x.Name.Contains(query.keyword) || x.MaKho.Equals(query.keyword)).ToList();
            }
            var resulteModel = new PageListResultBO<KhoDto>();
            resulteModel.items = list.Skip(begin).Take(query.limit).ToList();
            resulteModel.totalItems = list.Count();
            return resulteModel;
        }
        public KhoDto GetById(Guid id)
        {
            return _mapper.Map<KhoDto>(_repository.GetbyId(id));
        }
    }
}
