using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstasnet.Data.DbContext;
using firstaspnet.Data.Db;
using firstaspnet.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace firstaspnet.Data.DbContext
{
    public class MonthFinanceConfigurationsPersister : IFinanceConfigurationPersister
    {
        public static string userId = "42fe5e7f-b378-469d-87e8-cc74420b096a";
        private readonly MonthFinanceStore store;
		private static string documentsContainerName = "usersfinances";
        
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

		public async Task<MonthFinance[]> Get()
		{
			var documentName = GetDocumentName();
			return (await store.Get(documentName))?.ToArray() ?? new MonthFinance[0];
		}

		private static string GetDocumentName()
		{
			return userId.ToString().ToLowerInvariant() + "/" + "config.json";
		}

		public async Task Persist(MonthFinance monthFinance)
		{
			if (monthFinance == null)
			{
				return;
			}
			var stored = await store.Get(GetDocumentName());
			List<MonthFinance> monthFinanceList = new List<MonthFinance>();
			if (stored == null)
			{
				monthFinanceList = new List<MonthFinance>{ monthFinance };
			}
			else
			{
				monthFinanceList = stored.ToList();
				if (monthFinance.IsDefault)
				{
				 	foreach (var monthFInanceConfig in monthFinanceList)
				 	{
				 		monthFInanceConfig.IsDefault = false;
				 	}
				}
				var existent = monthFinanceList.FirstOrDefault(x => x.Id == monthFinance.Id);
				if (existent != null)
				{
					monthFinanceList.Remove(existent);
				}
				monthFinanceList.Add(monthFinance);
				if (monthFinanceList.Count == 1)
				{
					monthFinance.IsDefault = true;
				}
			}
			await Persist(monthFinanceList);
		}
        
        public async Task Persist(IEnumerable<MonthFinance> monthFinances)
		{
			if (monthFinances == null)
			{
				monthFinances = Enumerable.Empty<MonthFinance>();
			}
			var dblist = monthFinances.ToArray();
			foreach (var monthFin in dblist)
			{
				if (Guid.Empty.Equals(monthFin.Id))
				{
					monthFin.Id = Guid.NewGuid();
				}
			}
			if (dblist.Length > 0 && !dblist.Any(x => x.IsDefault))
			{
				dblist[0].IsDefault = true;
			}
			await store.Persist(GetDocumentName(), dblist);
		}

		public async Task<MonthFinance[]> Remove(Guid monthFinanceId)
		{
			var stored = await store.Get(GetDocumentName());
			if (stored == null)
			{
				return new MonthFinance[0];
			}
			var dashboards = stored.Where(x => x.Id != monthFinanceId).ToArray();
			await Persist(dashboards);
			return dashboards;
		}

    
    }
}