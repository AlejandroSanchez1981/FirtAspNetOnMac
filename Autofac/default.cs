using Autofac;
using firstaspnet.Data.DbContext;
using firstaspnet.Data.Entities;
using firstaspnet.Interfaces.ioc;


public class DefaultModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ItemContext>().As<IRepository<Item>>();
    builder.RegisterType<MonthFinanceConfigurationsPersister>().As<IFinanceConfigurationPersister>();
    
    builder.Register(c => new MonthFinanceConfigurationsPersister("DefaultEndpointsProtocol=https;AccountName=monthfinance;AccountKey=NQxNgN/+tChgaIPhbQXOFDH3nmmGbnixBE4L63mt+H61fkKG3fKDIsA6wTuzbg1T8FyurdwCH4tVaiWOUgkY0Q==")).As<IFinanceConfigurationPersister>();
  }
}

                                                                                                                                      
