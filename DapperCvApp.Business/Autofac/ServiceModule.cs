using Autofac;
using DapperCvApp.DataAccess;
using DapperCvApp.DataAccess.Context;
using System.Data;
using System.Reflection;
using Module = Autofac.Module;

namespace DapperCvApp.Business
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          
            builder.RegisterType<DapperContext>().SingleInstance();

            builder.RegisterGeneric(typeof(DPGenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EducationManager>().As<IEducationService>().InstancePerLifetimeScope();
            builder.RegisterType<SkillManager>().As<ISkillService>().InstancePerLifetimeScope();
            builder.RegisterType<ExperienceManager>().As<IExperienceService>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageManager>().As<ILanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<SocialMediaIconManager>().As<ISocialMediaIconService>().InstancePerLifetimeScope();
            builder.RegisterType<CertificationManager>().As<ICertificationService>().InstancePerLifetimeScope();

            builder.RegisterType<DPAppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPCertificationRepository>().As<ICertificationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPEducationRepository>().As<IEducationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPExperienceRepository>().As<IExperienceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPLanguageRepository>().As<ILanguageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPSkillRepository>().As<ISkillRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPSocialMediaIconRepository>().As<ISocialMediaIconRepository>().InstancePerLifetimeScope();
        }
    }
}
