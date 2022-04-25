using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using VerticalSliceArchExample.Data;

namespace VerticalSliceArchExample.Features.Books;

public class GetById
{
    public class Query : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int YearPublished { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, ApiDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .ProjectTo<Result>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book is null)
            {
                throw new ObjectNotFoundException();
            }

            return book;
        }
    }
}
