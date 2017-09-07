using AutoMapper;

namespace WPFTest.Servicios.Mapping
{
    public class UsuarioProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return this.GetType().ToString();
            }
        }

        public UsuarioProfile()
        {
            CreateMap<Data.usuario, Model.DTO.UsuarioDTO>()
                .ForMember(target => target.NombreUsuario, option => option.MapFrom(source => source.usuario1));
            CreateMap<Model.DTO.UsuarioDTO, Data.usuario>()
                .ForMember(target => target.usuario1, option => option.MapFrom(source => source.NombreUsuario));

            CreateMap<Model.DTO.UsuarioDTO, Model.Usuario>();
            CreateMap<Model.Usuario, Model.DTO.UsuarioDTO>();

            CreateMap<Model.Usuario, Data.usuario>()
                .ForMember(target => target.usuario1, option => option.MapFrom(source => source.NombreUsuario));
            CreateMap<Data.usuario, Model.Usuario>()
                .ForMember(target => target.NombreUsuario, option => option.MapFrom(source => source.usuario1));
        }
    }
}
