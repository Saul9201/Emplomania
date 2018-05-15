using AutoMapper;
using Emplomania.Data.VO;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data
{
    public static class MapConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            foreach (Type entityType in System.Reflection.Assembly.GetAssembly(typeof(Emplomania.Model.Category)).GetTypes())
            {
                if (entityType.Name == "Worker")
                {
                    cfg.CreateMap<Worker, WorkerVO>()
                        .ForMember(vo => vo.WorkReferences, opt => opt.Ignore())
                        .ForMember(vo => vo.DriverLicenses, opt => opt.Ignore())
                        .ForMember(vo => vo.Vehicles, opt => opt.Ignore())
                        .ForMember(vo => vo.Languages, opt => opt.Ignore())
                        .ForMember(vo => vo.Courses, opt => opt.Ignore())
                        .ForMember(vo => vo.WorkAspirations, opt => opt.Ignore());
                    cfg.CreateMap<WorkerVO, Worker>()
                        .ForMember(v => v.WorkReferences, opt => opt.Ignore())
                        .ForMember(v => v.DriverLicenses, opt => opt.Ignore())
                        .ForMember(v => v.Vehicles, opt => opt.Ignore())
                        .ForMember(v => v.Languages, opt => opt.Ignore())
                        .ForMember(v => v.Courses, opt => opt.Ignore())
                        .ForMember(v => v.WorkAspirations, opt => opt.Ignore());
                    continue;
                }
                if (entityType.Name == "Business")
                {
                    cfg.CreateMap<Business, BusinessVO>()
                        .ForMember(vo => vo.Workplaces, opt => opt.Ignore());
                    cfg.CreateMap<BusinessVO, Business>()
                        .ForMember(v => v.Workplaces, opt => opt.Ignore());
                    continue;
                }
                if (entityType.Name == "Municipality")
                {
                    cfg.CreateMap<Municipality, MunicipalityVO>()
                        .ForMember(uVO => uVO.ProvinciaId, map => map.MapFrom(u => u.ProvinceFK));
                    cfg.CreateMap<MunicipalityVO, Municipality>()
                        .ForMember(u => u.ProvinceFK, map => map.MapFrom(uVO => uVO.ProvinciaId));
                    continue;
                }
                var voType = Type.GetType(string.Format("Emplomania.Data.VO.{0}VO, Emplomania.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", entityType.Name));
                if (voType != null)
                {
                    cfg.CreateMap(entityType, voType);
                    cfg.CreateMap(voType, entityType);
                }
            }





        }

        //private static byte[] ImageToArrayConvert(Image image)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        image.Save(ms, image.RawFormat);
        //        return ms.ToArray();
        //    }
        //}
    }
}
