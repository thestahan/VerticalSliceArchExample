using AutoMapper;
using FluentValidation;
using MediatR;
using VerticalSliceArchExample.Data;
using VerticalSliceArchExample.Domain;

namespace VerticalSliceArchExample.Features.Books;

public class Add
{
    public class Command : IRequest<Result>
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int YearPublished { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int YearPublished { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public Handler(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            var bookToReturn = _mapper.Map<Result>(book);

            return bookToReturn;
        }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(1);
            RuleFor(c => c.Author).NotEmpty().MinimumLength(1);
            RuleFor(c => c.YearPublished).GreaterThan(1000);
        }
    }
}
