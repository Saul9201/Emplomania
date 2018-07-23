using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.QueriesViewModels
{
    public class UserByMembresy_DetailsViewModel : EMViewModelBase
    {

        public UserByMembresy_DetailsViewModel(EMMainViewModel centralEMMain, UserClientRole clientType) : base(centralEMMain)
        {
            Subtitle = "usuarios por membresía";
            CurrentClientTypeDetails = clientType;

            //TODO RECORDAR BORRAR ESTO
            UserClientCollection = new List<UserClientModel>()
                    {
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"},
                        new UserClientModel(){NombreyApellidos="Fulanito Tales Mascuales",Direccion="Calle 24 entre 15 y 17, Vedado, La Habana", RecomendationLevel=2, Correo="dkjfbgk@sdjfgb.com", Telefono="65465446-3513113"}
                    };
        }

        public UserClientRole CurrentClientTypeDetails { get; set; }


        public IEnumerable<UserClientModel> UserClientCollection { get; set; }


    }
}
