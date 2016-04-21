using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstasnet.Data.DbContext;
using firstaspnet.Data.Db;
using firstaspnet.Data.DbContext;
using firstaspnet.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace firstasp.Data.DbContext
{
    public class MonthFinanceConfigurationsPersister : IMonthFinanceConfigurationPersister
    {
        private readonly MonthFinanceStore store;
		private static string documentsContainerName = "usersdashboards";
        
        
        private class MonthFinanceStore: BaseDocumentDao<IEnumerable<MonthFinance>>
		{
			public MonthFinanceStore(CloudStorageAccount account) : base(account) {}
			protected override string DocumentsContainerName { get; } = documentsContainerName;
			protected override void AdjustBlobAttributes(ICloudBlob blobReference)
			{
				var blobProperties = blobReference.Properties;
				blobProperties.ContentType = "application/json";
			}
		}
        
        public MonthFinanceConfigurationsPersister(string connectionString)
		{
			var account = CloudStorageAccount.Parse(connectionString);
            new BlobStorageInitializer(account, documentsContainerName).Initialize();
			store = new MonthFinanceStore(account); 
		}

		public async Task<MonthFinance[]> Get(Guid userId)
		{
			var documentName = GetDocumentName(userId);
			return (await store.Get(documentName))?.ToArray() ?? new MonthFinance[0];
		}

		private static string GetDocumentName(Guid userId)
		{
			return userId.ToString("N").ToLowerInvariant() + "/" + "config.json";
		}

		public async Task Persist(Guid userId, IEnumerable<MonthFinance> monthFinances)
		{
			if (monthFinances == null)
			{
				monthFinances = Enumerable.Empty<MonthFinance>();
			}
			var mflist = monthFinances.ToArray();
			foreach (var monthFinance in mflist)
			{
				if (Guid.Empty.Equals(monthFinance.Id))
				{
					monthFinance.Id = Guid.NewGuid();
				}
				// foreach (var gadgetConfig in dashboard.Gadgets.Where(x => Guid.Empty.Equals(x.Id)))
				// {
				// 	gadgetConfig.Id = Guid.NewGuid();
				// }
			}
			if (mflist.Length > 0 && !mflist.Any(x => x.IsDefault))
			{
				mflist[0].IsDefault = true;
			}
			await store.Persist(GetDocumentName(userId), mflist);
		}

		public async Task Persist(Guid userId, MonthFinance monthFinance)
		{
			if (monthFinance == null)
			{
				return;
			}
			var stored = await store.Get(GetDocumentName(userId));
			List<MonthFinance> monthFinanceList = new List<MonthFinance>();
			if (stored == null)
			{
			//	dashboards = new List<MonthFinance>{ dashboard };
			}
			else
			{
				monthFinanceList = stored.ToList();
				// if (monthFinanceList.IsDefault)
				// {
				// 	foreach (var dashboardConfig in monthFinanceList)
				// 	{
				// 		dashboardConfig.IsDefault = false;
				// 	}
				// }
				var existent = monthFinanceList.FirstOrDefault(x => x.Id == monthFinance.Id);
				if (existent != null)
				{
					monthFinanceList.Remove(existent);
				}
				monthFinanceList.Add(monthFinance);
				if (monthFinanceList.Count == 1)
				{
					// monthFinanceList.IsDefault = true;
				}
			}
			await Persist(userId, monthFinanceList);
		}

		public async Task<MonthFinance[]> Remove(Guid userId, Guid monthFinanceId)
		{
			var stored = await store.Get(GetDocumentName(userId));
			if (stored == null)
			{
				return new MonthFinance[0];
			}
			var dashboards = stored.Where(x => x.Id != monthFinanceId).ToArray();
			await Persist(userId, dashboards);
			return dashboards;
		}
        
        
        
    }
}