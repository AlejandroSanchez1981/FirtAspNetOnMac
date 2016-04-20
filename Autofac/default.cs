using Autofac;
using firstasp.Data.DbContext;
using firstaspnet.Data.DbContext;
using firstaspnet.Data.DbContext.Interfaces;
using firstaspnet.Data.Entities;
using firtaspnet.Interfaces.ioc;

public class DefaultModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ItemContext>().As<IRepository<Item>>();
    builder.RegisterType<MonthFinanceConfigurationsPersister>().As<IMonthFinanceConfigurationsPersister>();
    
    builder.Register(c => new MonthFinanceConfigurationsPersister("mysection")).As<IMonthFinanceConfigurationsPersister>();
  }
}