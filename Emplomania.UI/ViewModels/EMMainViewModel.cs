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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Emplomania.UI.ViewModels
{
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

        private string subtitle;
        public string Subitle
        {
            get { return subtitle; }
            set
            {
                SetProperty(ref subtitle, value.ToUpper());
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

        public EMMainViewModel(MainViewModel centralMain, UserAdminRole currentUser) : base(centralMain)
        {
            this.CurrentUserType = currentUser;
            CentralMain.Title = "emplomania";
            this.CurrentViewModel = new BasicViewModel(this);
        }

        #region Commands
        public ICommand UpdateDBCommand
        {
            get
            {
                return new RelayCommand(action => SincLocalDBWithSiteDb());
            }
        }

        public ICommand InsertUserClientCommand => new RelayCommand(param =>
        {
            var typeName = param.GetType().Name;
            switch (typeName)
            {
                case "InsertEmployerModel":
                    var insertEmployerModel = param as InsertEmployerModel;
                     var r=ServiceLocator.Get<IEmployerService>().AddOrUpdate(insertEmployerModel.UserVO, insertEmployerModel.EmployerVO, insertEmployerModel.BusinessVO);
                    if (r == null)
                    {
                        MessageBox.Show("El usuario no pudo ser insertado.");
                        return;
                    }
                    DisplayEmployerSheetView.Execute(insertEmployerModel);
                    break;
                case "InsertWorkerModel":
                    var insertWorkerModel = param as InsertWorkerModel;
                    //Todo
                    DisplayWorkerSheetView.Execute(insertWorkerModel);
                    break;
                case "InsertTeacherModel":
                    var insertTeacherModel = param as InsertTeacherModel;
                    //Todo
                    DisplayTeacherSheetView.Execute(insertTeacherModel);
                    break;
                default:
                    break;
            }
        });

        public ICommand VerifyClient => new RelayCommand(param =>
         {
             var insertClientModel = param as InsertClientModel;
             var userServ = ServiceLocator.Get<IUserService>();
             var id = insertClientModel.UserVO.Id;
             UserVO us = userServ.Get(x => x.Id == id);
             if(us==null)
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
            DisplayWorkerSheetView.Execute(insertWorkerModel);
        });
        #endregion

        #region Navegation
        private void DisplayEMView<T>(string v, params object[]p) where T : EMViewModelBase
        {
            CurrentViewModel = typeof(T).GetConstructors().First().Invoke(new object[] { this }.Concat(p).ToArray()) as EMViewModelBase;
            Subitle = v;
            ResetScrollContent();
        }

        public ICommand DisplayBasicView
        {
            get
            {
                return new RelayCommand(param => CurrentViewModel = new BasicViewModel(this));
            }
        }

        public ICommand DisplayCreateUserView
        {
            get
            {
                return new RelayCommand(param => CurrentViewModel = new CreateUserViewModel(this));
            }
        }

        public ICommand DisplayInsertClientView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new InsertClientViewModel(this));
            }
        }

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
                  this.Subitle = "Pasarela de pago";
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
                  DisplayEMView<PaymentGatewayViewModel>("Pasarela de pago");
          });

        public ICommand DisplayInsertBankDepositView
        {
            get
            {
                return new RelayCommand(action => CurrentViewModel = new InsertBankDepositViewModel(this));
            }
        }

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
                        context.InsertWorkerModel.WorkerVO.Languages = new List<WorkerLanguageVO>();
                        foreach (var item in context.InsertWorkerModel.Languages)
                        {
                            if (item != null && item.Language != null && item.LanguageLevel != null)
                            {
                                item.WorkerFK = context.InsertWorkerModel.WorkerVO.Id;
                                context.InsertWorkerModel.WorkerVO.Languages.Add(item);
                            }
                        }
                        context.InsertWorkerModel.WorkerVO.WorkReferences = new List<WorkReferenceVO>();
                        foreach (var item in context.InsertWorkerModel.WorkReferences)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.Place) && !string.IsNullOrEmpty(item.Occupation)
                            && !string.IsNullOrEmpty(item.ContactPerson) && !string.IsNullOrEmpty(item.Phone))
                            {
                                item.WorkerFK = context.InsertWorkerModel.WorkerVO.Id;
                                context.InsertWorkerModel.WorkerVO.WorkReferences.Add(item);
                            }
                        }
                        context.InsertWorkerModel.WorkerVO.Courses = context.InsertWorkerModel.SelectedCourses.ToList();
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
                            CurrentViewModel = new InsertClient_CreatePerfil3ViewModel(this, context.InsertWorkerModel);
                        }
                    }
                    else if (contextType.Name == "InsertClient_WorkerSheetViewModel")
                    {
                        var context = actionParam as InsertClient_WorkerSheetViewModel;
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
                    Subitle = "USUARIOS NIVEL DE RECOMENDACIóN";
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
                    Subitle = "USUARIOS PARA NIVEL DE RECOMENDACIóN (detalles)";
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
                    Subitle = "USUARIOS CON NIVEL DE RECOMENDACIóN (DETALLES)";
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
                    Subitle = "trabajadores por plaza (servicio adicional)";
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
                    Subitle = "cLIENTE por usuario (membresía)";
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
                    Subitle = "Insertar Cursos";
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
                    Subitle = "insertar ofrezco";
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
                    Subitle = "insertar necesito";
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
                    Subitle = "insertar ofertas de empleo";
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
                    Subitle = "insertar rifas";
                    ResetScrollContent();
                });
            }
        }

        public ICommand DisplayNomenclatorsView => new RelayCommand(paramEx =>
         {
             CurrentViewModel = new NomenclatorsViewModel(this);
             Subitle = "Nomencladores";
             ResetScrollContent();
         });

        public ICommand DisplayAccountingReportView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new AccountingReportViewModel(this);
            Subitle = "Reporte Contable";
            ResetScrollContent();
        });

        public ICommand DisplayQueryNoVerificUserView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new QueryNoVerificUserViewModel(this);
            Subitle = "Usuarios no verificados";
            ResetScrollContent();
        });

        public ICommand DisplayRaffleWinnersView => new RelayCommand(paramEx =>
        {
            CurrentViewModel = new RaffleWinnersViewModel(this);
            Subitle = "Ganadores de rifas";
            ResetScrollContent();
        });

        public ICommand DisplayBankDepositUserView => new RelayCommand(paramEx =>
          {
              CurrentViewModel = new BankDepositUserViewModel(this);
              Subitle = "usuarios depósito bancario";
              ResetScrollContent();
          });

        public ICommand DisplayAllClientsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<AllClientsViewModel>("todos los clientes");
          });

        public ICommand DisplayUserByMembresyView => new RelayCommand(paramEx =>
          {
              DisplayEMView<UserByMembresyViewModel>("usuarios por membresía");
          });

        public ICommand DisplayUserByMembresy_DetailsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<UserByMembresy_DetailsViewModel>("usuarios por membresía", (Gender)paramEx);
          });

        public ICommand DisplayEvaluatesPersonsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<EvaluatesPersonsViewModel>("Personas Evaluadas");
          });

        public ICommand DisplayEvaluatesPersons_WorkerDetailsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<EvaluatesPersons_WorkerDetailsViewModel>("personas evaluadas (detalles trabajador)");
          });

        public ICommand DisplayContractedWorkersView => new RelayCommand(paramEx =>
          {
              DisplayEMView<ContractedWorkersViewModel>("Trabajadores Contratados");
          });

        public ICommand DisplaySalledCuponsView => new RelayCommand(paramEx =>
          {
              DisplayEMView<SalledCuponsViewModel>("Cupones Vendidos");
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
              DisplayEMView<ConnectedUsersViewModel>("Usuarios Conectados");
          });

        public ICommand DisplaySalesForWorkerView => new RelayCommand(paramEx =>
          {
              DisplayEMView<SalesForWorkerViewModel>("Ventas por trabajador");
          });

        public ICommand DisplaySurveyAnalysisViewModel => new RelayCommand(paramEx =>
          {
              DisplayEMView<SurveyAnalysisViewModel>("Análisis de encuesta");
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
                            var p = new InsertEmployerModel()
                            {
                                AuthenticationTypes = InsertClientModel.AuthenticationTypes,
                                UserClientRole = InsertClientModel.UserClientRole,
                                UserVO = InsertClientModel.UserVO,
                            };
                            p.EmployerVO = new EmployerVO() { Id = Guid.NewGuid(), UserFK = p.UserVO.Id };
                            p.BusinessVO = new BusinessVO() { Id = Guid.NewGuid(), EmployerFK = p.EmployerVO.Id };
                            DisplayInsertClientEmployerView.Execute(p);
                            break;
                        case UserClientRole.Profesor:
                            var p1 = new InsertTeacherModel()
                            {
                                AuthenticationTypes = InsertClientModel.AuthenticationTypes,
                                UserClientRole = InsertClientModel.UserClientRole,
                                UserVO = InsertClientModel.UserVO,
                            };
                            DisplayInsertClientTeacherView.Execute(p1);
                            break;
                        case UserClientRole.Trabajador:
                            var p2 = new InsertWorkerModel()
                            {
                                AuthenticationTypes = InsertClientModel.AuthenticationTypes,
                                UserClientRole = InsertClientModel.UserClientRole,
                                UserVO = InsertClientModel.UserVO,
                            };
                            p2.WorkerVO = new WorkerVO() { Id=Guid.NewGuid(), UserFK = p2.UserVO.Id };

                            p2.WorkerVO.GenderFK = ServiceLocator.Get<IGenderService>().Get(x => x.Name == p2.Gender.ToString()).Id;
                            p2.WorkerVO.Childrens = p2.Childrens == YesNotAnswer.Yes;
                            DisplayInsertClientWorkerView.Execute(p2);
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
