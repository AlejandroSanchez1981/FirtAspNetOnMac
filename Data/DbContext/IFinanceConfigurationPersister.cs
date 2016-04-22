using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using firstaspnet.Entities;

namespace firstaspnet.Data.DbContext
{
	public interface IFinanceConfigurationPersister
	{
		Task<MonthFinance[]> Get();
		Task Persist(IEnumerable<MonthFinance> dashboards);
		Task Persist(MonthFinance dashboard);
		Task<MonthFinance[]> Remove(Guid dashboardId);
	}
}