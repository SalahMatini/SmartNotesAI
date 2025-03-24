using AutoMapper;
using SmartNotes.API.DTOs;
using SmartNotes.API.Entities;

namespace SmartNotes.API.Mappings
{
    public class NoteAutoMapperProfile : Profile
    {
        public NoteAutoMapperProfile()
        {
            CreateMap<CreateNoteDto, Note>();
            CreateMap<UpdateNoteDto, Note>();
            CreateMap<Note, CreateNoteDto>();
            CreateMap<Note, UpdateNoteDto>();
        }
    }
} 