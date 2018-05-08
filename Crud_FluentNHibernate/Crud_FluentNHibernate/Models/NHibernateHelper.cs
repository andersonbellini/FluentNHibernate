using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Crud_FluentNHibernate.Models
{
    public class NHibernateHelper
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abellini\Downloads\Crud_FluentNHibernate\Crud_FluentNHibernate\Crud_FluentNHibernate\App_Data\Cadastro.mdf;Integrated Security=True;Connect Timeout=30
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abellini\Downloads\Crud_FluentNHibernate\Crud_FluentNHibernate\Crud_FluentNHibernate\App_Data\Cadastro.mdf;Integrated Security=True;Connect Timeout=30;").ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Aluno>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
