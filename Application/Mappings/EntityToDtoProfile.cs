using AutoMapper;
using PostsAPI.Application.DTOs;
using PostsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostsAPI.Application.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Post, PostDto>();
        }
    }
}
