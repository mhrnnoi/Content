using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Features.Books.Commands.AddBook;
using BookStore.Contracts.Book.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _imediator;

        public BookController(IMediator imediator)
        {
            _imediator = imediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookRequest request)
        {
            var command = new AddBookCommand();
            var result = await _imediator.Send(command);
            return Ok(result);

        }
        [HttpGet]
        [HttpPut]
        [HttpDelete]
    }
}