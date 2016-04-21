using Autofac;
using firstasp.Data.DbContext;
using firstaspnet.Data.DbContext;
using firstaspnet.Data.Entities;
using firtaspnet.Interfaces.ioc;

public class DefaultModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ItemContext>().As<IRepository<Item>>();
    builder.RegisterType<MonthFinanceConfigurationsPersister>().As<firstaspnet.Data.DbContext.interfaces.IMonthFinanceConfigurationPersister>();
    
    builder.Register(c => new MonthFinanceConfigurationsPersister("mysection")).As<firstaspnet.Data.DbContext.interfaces.IMonthFinanceConfigurationPersister>();
  }
}