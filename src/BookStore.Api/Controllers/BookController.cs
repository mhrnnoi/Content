using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Features.Books.Commands.AddBook;
using BookStore.Application.Features.Books.Commands.DeleteBook;
using BookStore.Application.Features.Books.Commands.UpdateBook;
using BookStore.Application.Features.Books.Queries.GetAllBooks;
using BookStore.Application.Features.Books.Queries.GetBookById;
using BookStore.Contracts.Book.Request;
using BookStore.Domain.Book.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookController(IMediator imediator, IMapper mapper)
        {
            _mediator = imediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(CUDBookRequest request)
        {
            var command = _mapper.Map<AddBookCommand>(request);


            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(GetBookByIdRequest request)
        {
            var query = new GetBookByIdQuery(request.id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(CUDBookRequest request)
        {
            var command = _mapper.Map<UpdateBookCommand>(request);

            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(CUDBookRequest request)
        {
            var command = _mapper.Map<DeleteBookCommand>(request);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}