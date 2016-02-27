using Autofac;
using firstaspnet.Data;
using firtaspnet.interfaces.ioc;

public class DefaultModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<Item>().As<IRepository>();
  }
}