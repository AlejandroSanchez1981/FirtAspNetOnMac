using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using firstaspnet.Entities;

namespace firstaspnet.Data.DbContext
{
	public interface IFinanceConfigurationPersister
	{
		Task<MonthFinance[]> Get(Guid userId);
		Task Persist(Guid userId, IEnumerable<MonthFinance> dashboards);
		Task Persist(Guid userId, MonthFinance dashboard);
		Task<MonthFinance[]> Remove(Guid userId, Guid dashboardId);
	}
}