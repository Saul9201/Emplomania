using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.ServicesViewModels
{
    public class QueryClientByUserViewModel : EMViewModelBase
    {
        public QueryClientByUserViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
        }

        private IEnumerable<UserClientModel> userClientCollection;

        public IEnumerable<UserClientModel> UserClientCollection
        {
            get { return userClientCollection; }
            set { SetProperty(ref userClientCollection, value); }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
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
                });
            }
        }
    }
}
