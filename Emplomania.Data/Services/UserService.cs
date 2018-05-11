using AutoMapper;
using AutoMapper.QueryableExtensions;
using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emplomania.Infrastucture.Enums;

namespace Emplomania.Data.Services
{
    internal class UserService : CrudService<UserVO, User>, IUserService
    {
        public UserService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public List<UserVO> FilterByUserNameAndFullName(UserClientRole clientType, string userNameToSearch, string fullNameToSearch)
        {
            IQueryable<UserVO> q = null;
            switch (clientType)
            {
                case UserClientRole.Trabajador:
                    q = (from s in db.Users
                        join w in db.Workers on s.Id equals w.UserFK
                        select s).ProjectTo<UserVO>();
                    break;
                case UserClientRole.Empleador:
                    q = (from s in db.Users
                         join e in db.Employers on s.Id equals e.UserFK
                         select s).ProjectTo<UserVO>();
                    break;
                case UserClientRole.Profesor:
                    //TODO: Falta hacer lo mismo para el profesor
                    break;
                default:
                    break;
            }
            if (q == null)
                return null;
            if (!string.IsNullOrEmpty(userNameToSearch))
                q = q.Where(x => x.UserName == userNameToSearch);
            if (!string.IsNullOrEmpty(fullNameToSearch))
                q = q.Where(x => (x.Name + " " + x.LastName + " " + x.LastName2).Contains(fullNameToSearch));
            //q = q.Where(x => x.Name.Contains(fullNameToSearch)||x.LastName.Contains(fullNameToSearch)||x.LastName2.Contains(fullNameToSearch));
            return q.ToList();

        }
    }

    public interface IUserService : ICrudService<UserVO, User>
    {
        List<UserVO> FilterByUserNameAndFullName(UserClientRole selectedClientType, string userNameToSearch, string fullNameToSearch);
    }




    internal class EmployerService : CrudService<EmployerVO, Employer>, IEmployerService
    {
        private IBusinessService bs;
        private IUserService us;
        public EmployerService(EmplomaniaAdminDBContext db, IBusinessService bs, IUserService us) : base(db)
        {
            this.bs = bs;
            this.us = us;
        }

        public Guid? AddOrUpdate(UserVO userVO, EmployerVO employerVO, BusinessVO businessVO)
        {
            var q = (from us in db.Users
                     where us.Id == userVO.Id
                     select us).FirstOrDefault();

            try
            {
                if (q == null)
                {
                    us.Add(userVO);
                    base.Add(employerVO);
                    bs.Add(businessVO);
                }
                else
                {
                    us.Update(userVO);
                    base.Update(employerVO);
                    bs.Update(businessVO);
                }
                return employerVO.Id;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return null;
            }
        }
    }

    public interface IEmployerService : ICrudService<EmployerVO, Employer>
    {
        Guid? AddOrUpdate(UserVO userVO, EmployerVO employerVO, BusinessVO businessVO);
    }

    internal class BusinessService : CrudService<BusinessVO, Business>, IBusinessService
    {
        IBusinessWorkplaceService bws;
        public BusinessService(EmplomaniaAdminDBContext db, IBusinessWorkplaceService bws) : base(db)
        {
            this.bws = bws;
        }

        public override BusinessVO Add(BusinessVO vo, bool saveChanges = true)
        {
            var res = base.Add(vo, saveChanges);
            bws.AddToBusiness(vo.Id, vo.WorkPlaces);
            return res;
        }

        public override void Update(BusinessVO vo)
        {
            base.Update(vo);
            bws.ClearToBusiness(vo.Id);
            bws.AddToBusiness(vo.Id, vo.WorkPlaces);
        }
        public IEnumerable<WorkplaceVO> GetWorkPlaces(Guid businessId)
        {
            return (from bw in db.BusinessWorkplaces
                    join wp in db.Workplaces on bw.WorkplaceFK equals wp.Id
                    where bw.BusinessFK == businessId
                    select wp).ProjectTo<WorkplaceVO>().ToList();
        }
    }

    public interface IBusinessService : ICrudService<BusinessVO, Business>
    {
        IEnumerable<WorkplaceVO> GetWorkPlaces(Guid businessId);
    }

    internal class BusinessWorkplaceService : CrudService<BusinessWorkplaceVO, BusinessWorkplace>, IBusinessWorkplaceService
    {
        public BusinessWorkplaceService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToBusiness(Guid businessId, IEnumerable<WorkplaceVO> workPlaces)
        {
            try
            {
                if (workPlaces != null)
                    foreach (var item in workPlaces)
                        if (item != null && base.Get(x => x.BusinessFK == businessId && x.WorkplaceFK == item.Id) == null)
                            this.Add(new BusinessWorkplaceVO() { BusinessFK = businessId, WorkplaceFK = item.Id });
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToBusiness(Guid businessId)
        {
            try
            {
                var q = (from bwp in db.BusinessWorkplaces
                         where bwp.BusinessFK == businessId
                         select bwp).ToList();
                foreach (var item in q)
                {
                    db.BusinessWorkplaces.Remove(item);
                }
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
    }

    public interface IBusinessWorkplaceService : ICrudService<BusinessWorkplaceVO, BusinessWorkplace>
    {
        bool AddToBusiness(Guid businessId, IEnumerable<WorkplaceVO> workPlaces);
        bool ClearToBusiness(Guid businessId);
    }



    internal class WorkerService : CrudService<WorkerVO, Worker>, IWorkerService
    {
        IUserService us;
        IWorkReferenceService wrs;
        IWorkerDriverLicenseService wdls;
        IWorkerVehicleService wvs;
        IWorkerLanguageService wls;
        IWorkerCourseService wcs;
        IWorkAspirationService was;
        public WorkerService(EmplomaniaAdminDBContext db, IUserService us, IWorkReferenceService wrs, IWorkerDriverLicenseService wdls, IWorkerVehicleService wvs, IWorkerLanguageService wls, IWorkerCourseService wcs, IWorkAspirationService was) : base(db)
        {
            this.us = us;
            this.wrs = wrs;
            this.wdls = wdls;
            this.wvs = wvs;
            this.wls = wls;
            this.wcs = wcs;
            this.was = was;
        }
        public bool AddOrUpdate(WorkerVO worker)
        {
            var q = (from us in db.Users
                     where us.Id == worker.User.Id
                     select us).FirstOrDefault();
            try
            {
                if (q == null)
                {
                    us.Add(worker.User);
                    worker.UserFK = worker.User.Id;
                    base.Add(worker);
                    bool res=wrs.AddToWorker(worker.Id, worker.WorkReferences);
                    res&=wdls.AddToWorker(worker.Id, worker.DriverLicenses);
                    res &= wvs.AddToWorker(worker.Id, worker.Vehicles);
                    res&=wls.AddToWorker(worker.Id, worker.Languages);
                    res &= wcs.AddToWorker(worker.Id, worker.Courses);
                    res &= was.AddToWorker(worker.Id, worker.WorkAspirations);
                    return res;
                }
                else
                {
                    us.Update(worker.User);
                    base.Update(worker);
                    bool res=wrs.ClearToWorker(worker.Id);
                    res&=wrs.AddToWorker(worker.Id, worker.WorkReferences);
                    res&=wdls.ClearToWorker(worker.Id);
                    res&=wdls.AddToWorker(worker.Id, worker.DriverLicenses);
                    res&=wvs.ClearToWorker(worker.Id);
                    res&=wvs.AddToWorker(worker.Id, worker.Vehicles);
                    res&=wls.ClearToWorker(worker.Id);
                    res&=wls.AddToWorker(worker.Id, worker.Languages);
                    res&=wcs.ClearToWorker(worker.Id);
                    res &= wcs.AddToWorker(worker.Id, worker.Courses);
                    res &= was.ClearToWorker(worker.Id);
                    res &= was.AddToWorker(worker.Id, worker.WorkAspirations);
                    return res;
                }
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public override IQueryable<WorkerVO> GetAll()
        {
            var q = from w in db.Workers
                    join us in db.Users on w.UserFK equals us.Id
                    join ec in db.EyeColors on w.EyeColorFK equals ec.Id
                    join sc in db.SkinColors on w.SkinColorFK equals sc.Id
                    join comp in db.Complexios on w.ComplexionFK equals comp.Id
                    join g in db.Genders on w.GenderFK equals g.Id
                    join cs in db.CivilStatuses on w.CivilStatusFK equals cs.Id
                    join sg in db.SchoolGrades on w.SchoolGradeFK equals sg.Id
                    join sp in db.Specialties on w.SpecialtyFK equals sp.Id
                    select new WorkerVO
                    {
                        Id = w.Id,
                        BornDate = w.BornDate,
                        Stature = w.Stature,
                        Childrens = w.Childrens,
                        Barriada = w.Barriada,
                        Abilities = w.Abilities,
                        Salary = w.Salary,
                        Experience = w.Experience,
                        OtherCourses = w.OtherCourses,

                        User = Mapper.Map<UserVO>(us),
                        EyeColor = Mapper.Map<EyeColorVO>(ec),
                        SkinColor = Mapper.Map<SkinColorVO>(sc),
                        Complexion = Mapper.Map<ComplexionVO>(comp),
                        Gender = Mapper.Map<GenderVO>(g),
                        CivilStatus = Mapper.Map<CivilStatusVO>(cs),
                        SchoolGrade = Mapper.Map<SchoolGradeVO>(sg),
                        Specialty = Mapper.Map<SpecialtyVO>(sp),
                    };
            return q;
        }

        public WorkerVO LoadEnumerablesProperties(WorkerVO worker)
        {
            worker.WorkReferences = wrs.GetAll().Where(x => x.WorkerFK == worker.Id).ToList();
            worker.DriverLicenses = (from wdl in db.WorkerDriverLicenses
                                     join dl in db.DriverLicenses on wdl.DriverLicenseFK equals dl.Id
                                     where wdl.WorkerFK == worker.Id
                                     select dl).ProjectTo<DriverLicenseVO>().ToList();
            worker.Vehicles = (from wv in db.WorkerVehicles
                               join v in db.Vehicles on wv.VehicleFK equals v.Id
                               where wv.WorkerFK == worker.Id
                               select v).ProjectTo<VehicleVO>().ToList();
            worker.Languages = wls.GetAll().Where(x => x.WorkerFK == worker.Id).ToList();
            worker.Courses = (from wc in db.WorkerCourses
                              join c in db.Courses on wc.CourseFK equals c.Id
                              where wc.WorkerFK == worker.Id
                              select c).ProjectTo<CourseVO>().ToList();
            worker.WorkAspirations = was.GetAll().Where(x => x.WorkerFK == worker.Id).ToList();
            return worker;
        }
    }
    public interface IWorkerService : ICrudService<WorkerVO, Worker>
    {
        bool AddOrUpdate(WorkerVO worker);
        WorkerVO LoadEnumerablesProperties(WorkerVO worker);
    }

    internal class WorkReferenceService : CrudService<WorkReferenceVO, WorkReference>, IWorkReferenceService
    {
        public WorkReferenceService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<WorkReferenceVO> workReferences)
        {
            try
            {
                if(workReferences!=null)
                    foreach (var item in workReferences)
                    {
                        if(item != null && base.Get(x=>x.WorkerFK==id && x.Place==item.Place)==null)
                        {
                            var toAdd=item;
                            toAdd.WorkerFK = id;
                            base.Add(toAdd);
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wr in db.WorkReferences
                         where wr.WorkerFK == id
                         select wr).ToList();
                foreach (var item in q)
                    db.WorkReferences.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
    }
    public interface IWorkReferenceService : ICrudService<WorkReferenceVO, WorkReference>
    {
        bool AddToWorker(Guid id, IEnumerable<WorkReferenceVO> workReferences);
        bool ClearToWorker(Guid id);
    }

    internal class WorkerDriverLicenseService : CrudService<WorkerDriverLicenseVO, WorkerDriverLicense>, IWorkerDriverLicenseService
    {
        public WorkerDriverLicenseService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<DriverLicenseVO> driverLicenses)
        {
            try
            {
                if (driverLicenses != null)
                    foreach (var item in driverLicenses)
                    {
                        if (item != null && base.Get(x => x.WorkerFK == id && x.DriverLicenseFK == item.Id) == null)
                        {
                            base.Add(new WorkerDriverLicenseVO() { WorkerFK = id, DriverLicenseFK = item.Id });
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wdl in db.WorkerDriverLicenses
                         where wdl.WorkerFK == id
                         select wdl).ToList();
                foreach (var item in q)
                    db.WorkerDriverLicenses.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
    }
    public interface IWorkerDriverLicenseService : ICrudService<WorkerDriverLicenseVO, WorkerDriverLicense>
    {
        bool AddToWorker(Guid id, IEnumerable<DriverLicenseVO> driverLicenses);
        bool ClearToWorker(Guid id);
    }


    internal class WorkerVehicleService : CrudService<WorkerVehicleVO, WorkerVehicle>, IWorkerVehicleService
    {
        public WorkerVehicleService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<VehicleVO> vehicles)
        {
            try
            {
                if (vehicles != null)
                    foreach (var item in vehicles)
                    {
                        if (item != null && base.Get(x => x.WorkerFK == id && x.VehicleFK == item.Id) == null)
                        {
                            base.Add(new WorkerVehicleVO() { WorkerFK = id, VehicleFK = item.Id });
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wv in db.WorkerVehicles
                         where wv.WorkerFK == id
                         select wv).ToList();
                foreach (var item in q)
                    db.WorkerVehicles.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
    }
    public interface IWorkerVehicleService : ICrudService<WorkerVehicleVO, WorkerVehicle>
    {
        bool AddToWorker(Guid id, IEnumerable<VehicleVO> vehicles);
        bool ClearToWorker(Guid id);
    }

    internal class WorkerLanguageService : CrudService<WorkerLanguageVO, WorkerLanguage>, IWorkerLanguageService
    {
        public WorkerLanguageService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<WorkerLanguageVO> languages)
        {
            try
            {
                if (languages != null)
                    foreach (var item in languages)
                    {
                        if (item != null && base.Get(x => x.WorkerFK == id && x.LanguageFK == item.LanguageFK) == null)
                        {
                            var toAdd = item;
                            toAdd.WorkerFK = id;
                            base.Add(toAdd);
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wl in db.WorkerLanguages
                         where wl.WorkerFK == id
                         select wl).ToList();
                foreach (var item in q)
                    db.WorkerLanguages.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public override IQueryable<WorkerLanguageVO> GetAll()
        {
            var q = from wl in db.WorkerLanguages
                    join l in db.Languages on wl.LanguageFK equals l.Id
                    join ll in db.LanguageLevels on wl.LanguageLevelFK equals ll.Id
                    select new WorkerLanguageVO
                    {
                        Id = wl.Id,
                        WorkerFK = wl.WorkerFK,
                        Language = Mapper.Map<LanguageVO>(l),
                        LanguageLevel = Mapper.Map<LanguageLevelVO>(ll),
                    };
            return q;
        }
    }
    public interface IWorkerLanguageService : ICrudService<WorkerLanguageVO, WorkerLanguage>
    {
        bool AddToWorker(Guid id, IEnumerable<WorkerLanguageVO> languages);
        bool ClearToWorker(Guid id);
    }

    internal class WorkerCourseService : CrudService<WorkerCourseVO, WorkerCourse>, IWorkerCourseService
    {
        public WorkerCourseService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<CourseVO> courses)
        {
            try
            {
                if (courses != null)
                    foreach (var item in courses)
                    {
                        if (item != null && base.Get(x => x.WorkerFK == id && x.CourseFK == item.Id) == null)
                        {
                            base.Add(new WorkerCourseVO() { CourseFK = item.Id, WorkerFK = id });
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wc in db.WorkerCourses
                         where wc.WorkerFK == id
                         select wc).ToList();
                foreach (var item in q)
                    db.WorkerCourses.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
    }
    public interface IWorkerCourseService : ICrudService<WorkerCourseVO, WorkerCourse>
    {
        bool AddToWorker(Guid id, IEnumerable<CourseVO> courses);
        bool ClearToWorker(Guid id);
    }

    internal class WorkAspirationService : CrudService<WorkAspirationVO, WorkAspiration>, IWorkAspirationService
    {
        public WorkAspirationService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool AddToWorker(Guid id, IEnumerable<WorkAspirationVO> workAspirations)
        {
            try
            {
                if (workAspirations != null)
                    foreach (var item in workAspirations)
                    {
                        if (item != null && base.Get(x => x.WorkerFK == id && x.WorkplaceFK == item.WorkplaceFK) == null)
                        {
                            var toAdd = item;
                            toAdd.WorkerFK = id;
                            base.Add(toAdd);
                        }
                    }
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }
        public bool ClearToWorker(Guid id)
        {
            try
            {
                var q = (from wa in db.WorkAspirations
                         where wa.WorkerFK == id
                         select wa).ToList();
                foreach (var item in q)
                    db.WorkAspirations.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                this.UndoChanges();
                return false;
            }
        }

        public override IQueryable<WorkAspirationVO> GetAll()
        {
            return from wa in db.WorkAspirations
                   join sc in db.Schedules on wa.ScheduleFK equals sc.Id
                   join wp in db.Workplaces on wa.WorkplaceFK equals wp.Id
                   select new WorkAspirationVO
                   {
                       Id = wa.Id,
                       Abilities = wa.Abilities,
                       Experience = wa.Experience,
                       Observations = wa.Observations,
                       Schedule = Mapper.Map<ScheduleVO>(sc),
                       Workplace = Mapper.Map<WorkplaceVO>(wp),
                   };
        }
    }
    public interface IWorkAspirationService: ICrudService<WorkAspirationVO, WorkAspiration>
    {
        bool AddToWorker(Guid id, IEnumerable<WorkAspirationVO> workAspirations);
        bool ClearToWorker(Guid id);
    }
}
