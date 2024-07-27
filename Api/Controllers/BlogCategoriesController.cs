﻿using Application.Features.BlogCategory.Commands.CreateBlogCategory;
using Application.Features.BlogCategory.Commands.RemoveBlogCategory;
using Application.Features.BlogCategory.Commands.UpdateBlogCategory;
using Application.Features.BlogCategory.Queries.GetBlogCategories;
using Application.Features.BlogCategory.Queries.GetBlogCategory;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("GetBlogCategories")]
        public async Task<List<BlogCategoryDTO>> GetBlogCategories(GetBlogCategoriesQuery query)
        {
            var blogCategories = await _mediator.Send(query);

            return blogCategories;
        }


        [AllowAnonymous]
        [HttpPost("GetBlogCategory")]
        public async Task<BlogCategoryDTO> GetBlogCategory(GetBlogCategoryQuery query)
        {
            var blogCategory = await _mediator.Send(query);

            return blogCategory;
        }


        [HttpPost("AddBlogCategory")]
        public async Task<ApiResponse> AddBlogCategory(CreateBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateBlogCategory")]
        public async Task<ApiResponse> UpdateBlogCategory(UpdateBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveBlogCategory")]
        public async Task<ApiResponse> RemoveBlogCategory(RemoveBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

    }
}
