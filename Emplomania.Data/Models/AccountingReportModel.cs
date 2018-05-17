using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Model
{
    public class AccountingReportModel
    {
        public float? WorkerTurquesa { get; set; }
        public float? WorkerEsmeralda { get; set; }
        public float? WorkerZafiro { get; set; }
        public float? WorkerRubi { get; set; }
        public float? WorkerDiamante { get; set; }
        public float? WorkerFichaDestacada { get; set; }
        public float? WorkerOfrezcoNecesito { get; set; }
        public float? WorkerTotal
        {
            get
            {
                float? t = 0;
                t += WorkerTurquesa ?? 0;
                t += WorkerEsmeralda ?? 0;
                t += WorkerZafiro ?? 0;
                t += WorkerRubi ?? 0;
                t += WorkerDiamante ?? 0;
                t += WorkerOfrezcoNecesito ?? 0;
                t += WorkerFichaDestacada ?? 0;
                return t;
            }
        }


        public float? EmployerTurquesa { get; set; }
        public float? EmployerEsmeralda { get; set; }
        public float? EmployerZafiro { get; set; }
        public float? EmployerRubi { get; set; }
        public float? EmployerDiamante { get; set; }
        public float? EmployerOfrezcoNecesito { get; set; }
        public float? EmployerAsistenciaTecnica { get; set; }
        public float? EmployerTotal
        {
            get
            {
                float? t = 0;
                t += EmployerTurquesa ?? 0;
                t += EmployerEsmeralda ?? 0;
                t += EmployerZafiro ?? 0;
                t += EmployerRubi ?? 0;
                t += EmployerDiamante ?? 0;
                t += EmployerOfrezcoNecesito ?? 0;
                t += EmployerAsistenciaTecnica ?? 0;
                return t;
            }
        }


        public float? TeacherTurquesa { get; set; }
        public float? TeacherEsmeralda { get; set; }
        public float? TeacherZafiro { get; set; }
        public float? TeacherRubi { get; set; }
        public float? TeacherDiamante { get; set; }
        public float? TeacherOfrezcoNecesito { get; set; }
        public float? TeacherConfeccionMatricula { get; set; }
        public float? TeacherTotal
        {
            get
            {
                float? t = 0;
                t += TeacherTurquesa ?? 0;
                t += TeacherEsmeralda ?? 0;
                t += TeacherZafiro ?? 0;
                t += TeacherRubi ?? 0;
                t += TeacherDiamante ?? 0;
                t += TeacherOfrezcoNecesito ?? 0;
                t += TeacherConfeccionMatricula ?? 0;
                return t;
            }
        }

        public float? TotalOficinaComercial { get; set; }
        public float? TotalDepositoBancario { get; set; }
        public float? TotalVentaCupon { get; set; }
        public float? Total
        {
            get
            {
                return TotalDepositoBancario + TotalOficinaComercial + TotalVentaCupon;
            }
        }

    }
}
