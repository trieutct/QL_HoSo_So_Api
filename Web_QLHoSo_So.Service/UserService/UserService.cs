using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Model.Entities;
using Web_QLHoSo_So.Repository;
using Web_QLHoSo_So.Repository.UserRepo;
using Web_QLHoSo_So.Service.common;

namespace Web_QLHoSo_So.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUserRepo repository) 
        {
            _repository = repository;
            this._mapper = mapper;
        }
        public bool Add(UserDto dto)
        {
            return this._repository.Add(_mapper.Map<User>(dto));
        }

        public bool Delete(Guid id)
        {
            return this._repository.Delete(id);
        }
        public bool softDelete(Guid id)
        {
            return this._repository.softDelete(id);
        }
        public bool Update(UserDto dto)
        {
            return _repository.Update(_mapper.Map<User>(dto));
        }

        public PageListResultBO<UserDto> GetAll(UserQuery? query)
        {
            int begin = (query.page * query.limit) - query.limit;
            var list = _mapper.Map<List<UserDto>>(_repository.GetAll());
            if(query.keyword!=string.Empty)
            {
                list=list.Where(x=>x.UserName.Equals(query.keyword)).ToList();
            }    
            var resulteModel = new PageListResultBO<UserDto>();
            resulteModel.items = list.Skip(begin).Take(query.limit).ToList();
            resulteModel.totalItems = list.Count();
            return resulteModel;
        }
        public UserDto GetById(Guid id)
        {
            return _mapper.Map<UserDto>(_repository.GetbyId(id));
        }
        public bool checkUser(string username)
        {
            var data= _repository.FindOne(x=>x.UserName==username);
            if (data != null)
                return true;
            return false;
        }
    }
}
