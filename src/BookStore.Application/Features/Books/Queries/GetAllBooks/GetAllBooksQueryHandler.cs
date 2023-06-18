using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Application.Features.Books.Common;
using MapsterMapper;
using MediatR;

namespace BookStore.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryHandler(IMapper mapper, IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books =  await _bookRepository.GetByAllAsync();
            var booksDto = _mapper.Map<List<BookDTO>>(books);
            await _unitOfWork.SaveChangesAsync();
            return booksDto;
        }
    }
}
