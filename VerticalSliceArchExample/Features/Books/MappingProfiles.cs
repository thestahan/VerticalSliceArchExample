using AutoMapper;
using VerticalSliceArchExample.Domain;

namespace VerticalSliceArchExample.Features.Books;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Add.Command, Book>();
        CreateMap<Book, Add.Result>();
        CreateMap<Book, GetById.Result>();
    }
}
