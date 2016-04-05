using Autofac;
using firstaspnet.Data.DbContext;
using firstaspnet.Data.Entities;
using firtaspnet.Interfaces.ioc;

public class DefaultModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ItemContext>().As<IRepository<Item>>();
    
  }
}