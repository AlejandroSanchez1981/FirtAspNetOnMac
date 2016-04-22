using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using firstaspnet.Data.DbContext.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace firstasnet.Data.DbContext
{
	public class BaseDocumentDao<TDocument> where TDocument : class
	{
		private readonly IDocumentSerializer<TDocument> documentSerializer;

		public BaseDocumentDao(string connectionString)
			: this(CloudStorageAccount.Parse(connectionString), new JsonDocumentSerializer<TDocument>()) {}

		public BaseDocumentDao(CloudStorageAccount account)
			: this(account, new JsonDocumentSerializer<TDocument>())
		{ }
        
        protected CloudStorageAccount Account { get; }

		protected virtual string DocumentsContainerName { get; }

		public BaseDocumentDao(CloudStorageAccount account, IDocumentSerializer<TDocument> documentSerializer)
		{
			DocumentsContainerName = typeof (TDocument).Name.ToLowerInvariant();
			if (account == null)
			{
				throw new ArgumentNullException(nameof(account));
			}
			if (documentSerializer == null)
			{
				throw new ArgumentNullException(nameof(documentSerializer));
			}
			Account = account;
			this.documentSerializer = documentSerializer;
		}

		
		public async Task<TDocument> Get(string documentName)
		{
			var blobStorageType = Account.CreateCloudBlobClient();
			var container = blobStorageType.GetContainerReference(DocumentsContainerName);
			var blobAddressUri = documentName;

			var serializationStream = new MemoryStream();
			try
			{
				var blobref = container.GetBlobReferenceFromServer(blobAddressUri);
				await blobref.DownloadToStreamAsync(serializationStream);
			}
			catch (StorageException e)
			{
				if (e.RequestInformation.HttpStatusCode == (int) HttpStatusCode.NotFound)
				{
					return null;
				}
				throw;
			}
			return documentSerializer.Deserialize(serializationStream);
		}

		public Task Persist(string documentName, TDocument document)
		{
			var blobAddressUri = documentName;
			var blobStorageType = Account.CreateCloudBlobClient();
			var container = blobStorageType.GetContainerReference(DocumentsContainerName);
			var blobReference = container.GetBlockBlobReference(blobAddressUri);
			AdjustBlobAttributes(blobReference);
			return blobReference.UploadFromStreamAsync(documentSerializer.Serialize(document));
		}

		protected virtual void AdjustBlobAttributes(ICloudBlob blobReference) {}

		public Task Remove(string documentName)
		{
			var blobStorageType = Account.CreateCloudBlobClient();
			var container = blobStorageType.GetContainerReference(DocumentsContainerName);

			return container.GetBlobReferenceFromServer(documentName).DeleteIfExistsAsync();
		}
	}
}