using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Application.Features.Books.Common;
using BookStore.Application.Features.Books.Queries.GetBookById;
using BookStore.Domain.Book.Entities;
using MapsterMapper;
using MediatR;

namespace BookStore.Application.Features.Books.Queries.GetBookById

{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }
    }
}
