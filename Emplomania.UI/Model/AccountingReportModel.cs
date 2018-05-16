using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    public class AccountingReportModel
    {
        public int WorkerTurquesa { get; set; }
        public int WorkerEsmeralda { get; set; }
        public int WorkerZafiro { get; set; }
        public int WorkerRubi { get; set; }
        public int WorkerFichaDestacada { get; set; }
        public int WorkerOfrezcoNecesito { get; set; }
        public int WorkerTotal
        {
            get
            {
                int t = 0;
                t += WorkerTurquesa;
                t += WorkerEsmeralda;
                t += WorkerZafiro;
                t += WorkerRubi;
                t += WorkerOfrezcoNecesito;
                t += WorkerFichaDestacada;
                return t;
            }
        }


        public int EmployerTurquesa { get; set; }
        public int EmployerEsmeralda { get; set; }
        public int EmployerZafiro { get; set; }
        public int EmployerRubi { get; set; }
        public int EmployerOfrezcoNecesito { get; set; }
        public int EmployerAsistenciaTecnica { get; set; }
        public int EmployerTotal
        {
            get
            {
                int t = 0;
                t += EmployerTurquesa;
                t += EmployerEsmeralda;
                t += EmployerZafiro;
                t += EmployerRubi;
                t += EmployerOfrezcoNecesito;
                t += EmployerAsistenciaTecnica;
                return t;
            }
        }


        public int TeacherTurquesa { get; set; }
        public int TeacherEsmeralda { get; set; }
        public int TeacherZafiro { get; set; }
        public int TeacherRubi { get; set; }
        public int TeacherOfrezcoNecesito { get; set; }
        public int TeacherConfeccionMatricula { get; set; }
        public int TeacherTotal
        {
            get
            {
                int t = 0;
                t += TeacherTurquesa;
                t += TeacherEsmeralda;
                t += TeacherZafiro;
                t += TeacherRubi;
                t += TeacherOfrezcoNecesito;
                t += TeacherConfeccionMatricula;
                return t;
            }
        }

        public int TotalOficinaComercial { get; set; }
        public int TotalDepositoBancario { get; set; }
        public int Total
        {
            get
            {
                return TotalDepositoBancario + TotalOficinaComercial;
            }
        }


    }
}
