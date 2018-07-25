using AutoMapper;
using Emplomania.Data.ApiClient.Services;
using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.AccountingReportViewModels;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.FormViewModels;
using Emplomania.UI.ViewModels.NomenclatorsViewModels;
using Emplomania.UI.ViewModels.PaymentGatewayViewModels;
using Emplomania.UI.ViewModels.QueriesViewModels;
using Emplomania.UI.ViewModels.ServicesViewModels;
using Emplomania.UI.ViewModels.StartViewModels;
using Emplomania.UI.ViewModels.UserViewMoldels;
using Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels;
using Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels;
using Emplomania.UI.Views.UtilsTemplatesViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Emplomania.UI.ViewModels
{
    //OJO: Enum que representa a las tareas que se puedan realizar, ej insertar un usuario, crear usuario administrativo etc.
    public enum TaskType
    {
        [Description("Crear usuario Administrativo")]
        CreateUser,
        [Description("Insertar cliente")]
        InsertClient,
    }


    public class EMMainViewModel : ViewModelBase
    {
        private EMViewModelBase currentViewModel;
        public EMViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);

                if (currentViewModel is BasicViewModel)
                    IsBasicView = Visibility.Collapsed;
                else
                    IsBasicView = Visibility.Visible;
            }
        }



        private UserAdminRole currentUserType;
        public UserAdminRole CurrentUserType
        {
            get { return currentUserType; }
            set
            {
                SetProperty(ref currentUserType, value);
            }
        }

        private Visibility isBasicView;
        public Visibility IsBasicView
        {
            get
            {
                return isBasicView;
            }
            set
            {
                SetProperty(ref isBasicView, value);
            }
        }

        private bool scrollOffsetReset;
        public bool ScrollOffsetReset
        {
            get { return scrollOffsetReset; }
            set
            {
                scrollOffsetReset = value;
                OnPropertyChanged();
            }
        }

        //Coleccion observable para bindear el menu de las tareas
        public ObservableCollection<MenuItem> OpenedTasks { get; set; }
        //Diccionario que representa cual user-control se esta mostrando en una tarea de un tipo determinado
        public Dictionary<TaskType, EMViewModelBase> Tasks { get; set; }

        public EMMainViewModel(MainViewModel centralMain, UserAdminRole currentUser) : base(centralMain)
        {
            this.CurrentUserType = currentUser;
            CentralMain.Title = "emplomania";
            this.CurrentViewModel = new BasicViewModel(this);
            this.OpenedTasks = new ObservableCollection<MenuItem>();
            this.Tasks = new Dictionary<TaskType, EMViewModelBase>();
            //this.OpenedStacks.Add(new MenuItem() { Header = "Create User", Command = DisplayCreateUserView });

        }

        #region Commands
        public ICommand CloseSesionCommand => new RelayCommand(param =>
          {
              CentralMain.CurrentViewModel = new LoginViewModel(this.CentralMain);
          });


        public ICommand UpdateDBCommand
        {
            get
            {
                return new RelayCommand(action => SincLocalDBWithSiteDb());
            }
        }

        public ICommand InsertEmployerCommand => new RelayCommand(param =>
        {
            var insertEmployerModel = param as InsertEmployerModel;
            insertEmployerModel.BusinessVO.Workplaces = insertEmployerModel.SelectedWorkplaces.ToList();
            if (!ServiceLocator.Get<IEmployerService>().AddOrUpdate(insertEmployerModel.UserVO, insertEmployerModel.EmployerVO, insertEmployerModel.BusinessVO))
            {
                MessageBox.Show("El usuario no pudo ser insertado.");
                return;
            }
            DisplayEmployerSheetView.Execute(insertEmployerModel);
        });

        public ICommand InsertTeacherCommand => new RelayCommand(param =>
        {
            var insertTeacherModel = param as InsertTeacherModel;
            if (!ServiceLocator.Get<ITeacherService>().AddOrUpdate(insertTeacherModel.UserVO, insertTeacherModel.TeacherVO))
            {
                MessageBox.Show("El usuario no pudo ser insertado.");
                return;
            }
            DisplayTeacherSheetView.Execute(insertTeacherModel);
        });

        public ICommand VerifyClient => new RelayCommand(param =>
         {
             var insertClientModel = param as InsertClientModel;
             var userServ = ServiceLocator.Get<IUserService>();
             var id = insertClientModel.UserVO.Id;
             UserVO us = userServ.Get(x => x.Id == id);
             if (us == null)
             {
                 MessageBox.Show($"El usuario no pudo ser verificado. Error.");
                 return;
             }
             us.Verified = true;
             userServ.Update(us);
             MessageBox.Show($"Usuario UserName:{us.UserName} verificado correctamente.");
             DisplayBasicView.Execute(null);
         });

        public ICommand CreateWorkerPofileFinichCommand => new RelayCommand(param =>
        {
            var insertWorkerModel = param as InsertWorkerModel;
            insertWorkerModel.WorkerVO.WorkAspirations = insertWorkerModel.SelectedWorkAspirations.ToList();
            if (!ServiceLocator.Get<IWorkerService>().AddOrUpdate(insertWorkerModel.WorkerVO))
            {
                MessageBox.Show("No se puede salvar el trabajador. Intente modificar los datos.");
                return;
            }

            DisplayWorkerSheetView.Execute(new InsertWorkerModel(insertWorkerModel));
        });

        public ICommand CloseButtomCommand => new RelayCommand(param =>
        {
            if (MessageBox.Show("Desea cerrar la sub-ventana?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DisplayBasicView.Execute(CurrentViewModel);
            }
        });
        #endregion

        #region Navegation
        private void DisplayEMView<T>(params object[] p) where T : EMViewModelBase
        {
            CurrentViewModel = typeof(T).GetConstructors().First().Invoke(new object[] { this }.Concat(p).ToArray()) as EMViewModelBase;
            ResetScrollContent();
        }

        private void DisplayEMRootView<T>(TaskType tt)
        {
            if (Tasks.ContainsKey(tt))
                MessageBox.Show("Ya exciste una tarea de tipo. Debe terminar la misma.");
            else
                Tasks[tt] = typeof(T).GetConstructors().First().Invoke(new object[] { this }.ToArray()) as EMViewModelBase;
            CurrentViewModel = Tasks[tt];
            OpenedTasks.Add(new MenuItem() { Header = GetDescription(tt), Command = new RelayCommand(action => CurrentViewModel = Tasks[TaskType.CreateUser]) });

        }
        private string GetDescription(object enumValue)
        {
            var descriptionAttribute = enumValue.GetType()
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }
        

        //OJO: Si le llega como parametro algo distinto de null entonces asume que es de una vista que cierra una tarea
        public ICommand DisplayBasicView => 
            new RelayCommand(param =>
                {
                    CurrentViewModel = new BasicViewModel(this);

                    //Se toman los nombres de las clases que tengan el atributo closeable
                    //var closeablesClass = typeof(CreateUserViewModel).Assembly.GetTypes().Where(x => x.IsClass && x.GetCustomAttributes(typeof(CloseableAttribute), false).Length != 0).Select(x=>x.Name).ToList();
                    //TODO: Si es una sub-ventana de root process se debe quitar del menu de acceso rapido.
                    //if (param != null && closeablesClass.Contains(param.GetType().Name))
                    //if (param != null && param.GetType().Name=="CreateUserViewModel")
                    //{
                    //    Tasks.Remove(TaskType.CreateUser);
                    //    OpenedTasks.Remove(OpenedTasks.Where(mi => mi.Header.ToString() == GetDescription(TaskType.CreateUser)).FirstOrDefault());
                    //}
                });


        public ICommand DisplayCreateUserView =>
            new RelayCommand(param =>
                {
                    DisplayEMRootView<CreateUserViewModel>(TaskType.CreateUser);
                });

        public ICommand DisplayInsertClientView =>
            new RelayCommand(param =>
            {
                DisplayEMRootView<InsertClientViewModel>(TaskType.InsertClient);
            });

        public ICommand DisplayAlterClientView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new AlterClientViewModel(this));
            }
        }

        public ICommand DisplaySaleCredCuponView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new SaleCredCuponViewModel(this));
            }
        }

        public ICommand DisplayInsertRecomendationLevelView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new InsertRecomendationViewModel(this));
            }
        }

        public ICommand DisplayPaymentGatewayView => new RelayCommand(paramEx =>
          {
              if (paramEx != null)
              {
                  //TODO: Castear paramEx a insertClient
                  ResetScrollContent();
                  var vm = new PaymentGatewayViewModel(this) { UserClientIdetityKnow = true, CurrentUser = (paramEx as InsertClientModel).UserVO };
                  if (paramEx is InsertWorkerModel)
                      vm.SelectedClientType = UserClientRole.Trabajador;
                  if (paramEx is InsertEmployerModel)
                      vm.SelectedClientType = UserClientRole.Empleador;
                  if (paramEx is InsertTeacherModel)
                      vm.SelectedClientType = UserClientRole.Profesor;
                  CurrentViewModel = vm;
              }
              else
                  DisplayEMView<PaymentGatewayViewModel>();
          });


        public ICommand DisplayInsertClientNaturalView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new InsertClient_NaturalViewModel(this, action as InsertClientModel));
            }
        }

        public ICommand DisplayInsertClientByInvitationView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new InsertClient_ByInvitationViewModel(this, action as InsertClientModel));
            }
        }

        public ICommand DisplayInsertClientEmployerView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new EmployerFormViewModel(this, action as InsertEmployerModel));
            }
        }

        public ICommand DisplayInsertClientTeacherView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new TeacherFormViewModel(this, action as InsertTeacherModel));
            }
        }

        public ICommand DisplayInsertClientWorkerView
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    var contextType = actionParam.GetType();
                    if (contextType.Name == "InsertWorkerModel")
                    {
                        CurrentViewModel = new InsertClient_CreatePerfil1ViewModel(this, actionParam as InsertWorkerModel);
                    }
                    else if (contextType.Name == "InsertClient_WorkerSheetViewModel")
                    {
                        var context = actionParam as InsertClient_WorkerSheetViewModel;
                        CurrentViewModel = new InsertClient_CreatePerfil1ViewModel(this, context.InsertWorkerModel)
                        {
                            FromWorkerSheet = true
                        };
                    }
                    else
                        throw new Exception();
                });
            }
        }

        public ICommand DisplayInsertClientWorker2View
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    var contextType = actionParam.GetType();
                    if (contextType.Name == "InsertClient_CreatePerfil1ViewModel")
                    {
                        var context = actionParam as InsertClient_CreatePerfil1ViewModel;
                        context.InsertWorkerModel.WorkerVO.User = context.InsertWorkerModel.UserVO;
                        context.InsertWorkerModel.WorkerVO.DriverLicenses = context.InsertWorkerModel.SelectedLicenses.ToList();
                        context.InsertWorkerModel.WorkerVO.Vehicles = context.InsertWorkerModel.SelectedVehicles.ToList();

                        if (!ServiceLocator.Get<IWorkerService>().AddOrUpdate(context.InsertWorkerModel.WorkerVO))
                        {
                            MessageBox.Show("No se puede salvar el trabajador. Intente modificar los datos.");
                            return;
                        }
                        if (context.FromWorkerSheet)
                        {
                            DisplayWorkerSheetView.Execute(context.InsertWorkerModel);
                        }
                        else
                        {
                            CurrentViewModel = new InsertClient_CreatePerfil2ViewModel(this, context.InsertWorkerModel);
                        }

                    }
                    else if (contextType.Name == "InsertClient_WorkerSheetViewModel")
                    {
                        var context = actionParam as InsertClient_WorkerSheetViewModel;
                        CurrentViewModel = new InsertClient_CreatePerfil2ViewModel(this, context.InsertWorkerModel)
                        {
                            FromWorkerSheet = true
                        };
                    }
                    else
                        throw new Exception();
                });
            }
        }

        public ICommand DisplayInsertClientWorker3View
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    var contextType = actionParam.GetType();
                    if (contextType.Name == "InsertClient_CreatePerfil2ViewModel")
                    {
                        var context = actionParam as InsertClient_CreatePerfil2ViewModel;
                        context.InsertWorkerModel.WorkerVO.User = context.InsertWorkerModel.UserVO;
                        context.InsertWorkerModel.WorkerVO.WorkReferences = context.InsertWorkerModel.SelectedWorkReferences.ToList();
                        context.InsertWorkerModel.WorkerVO.Languages = context.InsertWorkerModel.SelectedWorkerLanguages.ToList();
                        context.InsertWorkerModel.WorkerVO.Courses = context.InsertWorkerModel.SelectedCourses.ToList();

                        if (!ServiceLocator.Get<IWorkerService>().AddOrUpdate(context.InsertWorkerModel.WorkerVO))
                        {
                            MessageBox.Show("No se puede salvar el trabajador. Intente modificar los datos.");
                            return;
                        }

                        //var param = new InsertWorkerModel(context.InsertWorkerModel);
                        if (context.FromWorkerSheet)
                        {
                            DisplayWorkerSheetView.Execute(new InsertWorkerModel(context.InsertWorkerModel));
                        }
                        else
                        {
                            CurrentViewModel = new InsertClient_CreatePerfil3ViewModel(this, new InsertWorkerModel(context.InsertWorkerModel));
                        }
                    }
                    else if (contextType.Name == "InsertClient_WorkerSheetViewModel")
                    {
                        var context = actionParam as InsertClient_WorkerSheetViewModel;
                        var iwm = context.InsertWorkerModel;

                        CurrentViewModel = new InsertClient_CreatePerfil3ViewModel(this, context.InsertWorkerModel);
                    }
                    else
                        throw new Exception();
                });
            }
        }

        public ICommand DisplayEmployerSheetView
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    CurrentViewModel = new InsertClient_EmployerSheetViewModel(this, actionParam as InsertEmployerModel);
                });
            }
        }

        public ICommand DisplayTeacherSheetView
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    CurrentViewModel = new InsertClient_TeacherSheetViewModel(this, actionParam as InsertTeacherModel);
                });
            }
        }

        public ICommand DisplayWorkerSheetView
        {
            get
            {
                return new RelayCommand(actionParam =>
                {
                    CurrentViewModel = new InsertClient_WorkerSheetViewModel(this, actionParam as InsertWorkerModel);
                });
            }
        }

        public ICommand DisplayQueryUserRecomendationLevelView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new QueryUserRecomendationLevelViewModel(this);
                });
            }
        }

        public ICommand DisplayQueryUserToRecomendationLevelView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new QueryUserToRecomendationLevelViewModel(this);
                });
            }
        }

        public ICommand DisplayQueryUserWithRecomendationLevelView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new QueryUserWithRecomendationLevelViewModel(this);
                });
            }
        }

        public ICommand DisplayQueryWorkerForPlaceView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new QueryWorkerForPlaceViewModel(this);
                });
            }
        }

        public ICommand DisplayQueryClientByUserView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new QueryClientByUserViewModel(this);
                });
            }
        }

        public ICommand DisplayInsertCoursView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new InsertCoursViewModel(this);
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayInsertOfferView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new InsertOfferViewModel(this);
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayInsertNeedView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new InsertNeedViewModel(this);
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayInsertJobVacanciesView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new InsertJobVacanciesViewModel(this);
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayInsertRafflesView
        {
            get
            {
                return new RelayCommand(paramAction =>
                {
                    CurrentViewModel = new InsertRafflesViewModel(this);
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayNomenclatorsView => new RelayCommand(paramEx =>
         {
             CurrentViewModel = new NomenclatorsViewModel(this);
             ResetScrollContent();
         });

        public ICommand DisplayAccountingReportView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new AccountingReportViewModel(this);
            ResetScrollContent();
        });

        public ICommand DisplayQueryNoVerificUserView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new QueryNoVerificUserViewModel(this);
            ResetScrollContent();
        });

        public ICommand DisplayRaffleWinnersView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new RaffleWinnersViewModel(this);
            ResetScrollContent();
        });

        public ICommand DisplayBankDepositUserView => new RelayCommand(paramEx =>
          {
              CurrentViewModel = new BankDepositUserViewModel(this);
              ResetScrollContent();
          });

        public ICommand DisplayAllClientsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<AllClientsViewModel>();
          });

        public ICommand DisplayUserByMembresyView => new RelayCommand(paramEx =>
          {
              DisplayEMView<UserByMembresyViewModel>();
          });

        public ICommand DisplayUserByMembresy_DetailsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<UserByMembresy_DetailsViewModel>((Gender)paramEx);
          });

        public ICommand DisplayEvaluatesPersonsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<EvaluatesPersonsViewModel>();
          });

        public ICommand DisplayEvaluatesPersons_WorkerDetailsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<EvaluatesPersons_WorkerDetailsViewModel>();
          });

        public ICommand DisplayContractedWorkersView => new RelayCommand(paramEx =>
          {
              DisplayEMView<ContractedWorkersViewModel>();
          });

        public ICommand DisplaySalledCuponsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<SalledCuponsViewModel>();
          });

        public ICommand DisplayClientContactWindowsView => new RelayCommand(paramEx =>
          {
              ClientContactWindowsView v = new ClientContactWindowsView();
              v.Owner = Application.Current.MainWindow;
              v.DataContext = paramEx as ContactDataModel;
              v.Show();
          });

        public ICommand DisplayConnectedUsersView => new RelayCommand(paramEx =>
          {
              DisplayEMView<ConnectedUsersViewModel>();
          });

        public ICommand DisplaySalesForWorkerView => new RelayCommand(paramEx =>
          {
              DisplayEMView<SalesForWorkerViewModel>();
          });

        public ICommand DisplaySurveyAnalysisViewModel => new RelayCommand(paramEx =>
          {
              DisplayEMView<SurveyAnalysisViewModel>();
          });


        #region NavigationLogics
        public ICommand LogicDisplayPosiblAuthTypeInsertClientViews
        {
            get
            {
                return new RelayCommand(delegate (object o)
                {
                    var insertClientModel = o as InsertClientModel;
                    switch (insertClientModel.AuthenticationTypes)
                    {
                        case AuthenticationTypes.NaturalAuthRB:
                            DisplayInsertClientNaturalView.Execute(insertClientModel);
                            break;
                        case AuthenticationTypes.ForInvitationRB:
                            DisplayInsertClientByInvitationView.Execute(insertClientModel);
                            break;
                        default:
                            DisplayInsertClientNaturalView.Execute(insertClientModel);
                            break;
                    }
                });
            }
        }

        public ICommand LogicDisplayPosiblUserClientTypeInsertClientViews
        {
            get
            {
                return new RelayCommand(paramExec =>
                {
                    var InsertClientModel = paramExec as InsertClientModel;
                    switch (InsertClientModel.UserClientRole)
                    {
                        case UserClientRole.Empleador:
                            DisplayInsertClientEmployerView.Execute(new InsertEmployerModel(InsertClientModel.UserVO));
                            break;
                        case UserClientRole.Profesor:
                            DisplayInsertClientTeacherView.Execute(new InsertTeacherModel(InsertClientModel.UserVO));
                            break;
                        case UserClientRole.Trabajador:
                            DisplayInsertClientWorkerView.Execute(new InsertWorkerModel(InsertClientModel.UserVO));
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        #endregion





        #endregion

        #region Functions
        private void SincLocalDBWithSiteDb()
        {
            //TODO: Bloquear la app para que no se pueda usar hasta que termine de actualizar
            Task.Run(async () =>
            {
                CentralMain.IsTracking = true;
                var res = await DataAdministrator.SincLocalDbWithWebSiteDb();
                //System.Threading.Thread.Sleep(10000);
                CentralMain.IsTracking = false;
            });
        }


        public void ResetScrollContent()
        {
            ScrollOffsetReset = true;
        }

        #endregion

    }
}
