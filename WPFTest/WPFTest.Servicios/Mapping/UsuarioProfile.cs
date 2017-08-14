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
            CreateMap<Data.usuario, Model.DTO.UsuarioDTO>();
            CreateMap<Model.DTO.UsuarioDTO, Data.usuario>();

            CreateMap<Model.DTO.UsuarioDTO, Model.Usuario>();
            CreateMap<Model.Usuario, Model.DTO.UsuarioDTO>();
        }
    }
}
