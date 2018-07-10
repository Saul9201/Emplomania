using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.FormViewModels
{
    public class InsertCoursViewModel : EMViewModelBase
    {
        public CourseVO CourseVO { get; set; }
        public InsertCoursViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            this.CourseVO = new CourseVO() { Id=Guid.NewGuid()};
        }

        public ICommand InsertCourseCommand => new RelayCommand(param =>
        {
            var c=ServiceLocator.Get<ICourseService>().Add(CourseVO);
            if (c != null)
                MessageBox.Show("El Curso fue agregado correcamente en la db local.");
            else
                MessageBox.Show("El Curso no se agrego correcamente.");
        });


    }
}
