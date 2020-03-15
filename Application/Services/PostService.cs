using AutoMapper;
using PostsAPI.Application.DTOs;
using PostsAPI.Application.Exceptions;
using PostsAPI.Application.Interfaces;
using PostsAPI.Domain.Entities;
using PostsAPI.Domain.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAPI.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public PostService(
            IPostRepository postRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsService claimsService
        )
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        public async Task<Post> GetAsync(int id)
        {
            var post = await _postRepository.FindAsync(id);
            if (post == null)
                throw new NotFoundException(nameof(Post), id);

            return await _postRepository.FindAsync(id);
        }

        public IEnumerable<Post> ListUserPosts()
        {
            return _postRepository.ListUserPosts(_claimsService.GetUserId());
        }

        public async Task<int> CreateAsync(PostDto postDto)
        {
            var userId = _claimsService.GetUserId();
            var post = _mapper.Map<Post>(postDto);
            post.CreatedBy = userId;
            post.CreatedAt = DateTime.Now;
            _postRepository.Add(post);
            await _unitOfWork.CompleteAsync();
            return post.Id;
        }

        public async Task<Post> UpdateAsync(int id, PostDto postDto)
        {
            var post = await GetAsync(id);
            if (post == null)
                throw new NotFoundException(nameof(Post), id);

            post.Title = postDto.Title;
            post.Body = postDto.Body;
            post.LastModifiedAt = DateTime.Now;
            _postRepository.Update(post);
            await _unitOfWork.CompleteAsync();

            return post;
        }

        public async Task DeleteAsync(int id)
        {
            var post = await GetAsync(id);
            if (post == null)
                throw new NotFoundException(nameof(Post), id);

            _postRepository.Delete(post);
            await _unitOfWork.CompleteAsync();
        }
    }
}
