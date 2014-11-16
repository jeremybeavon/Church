using System;
using System.IO;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Embedded;

namespace Church.DataAccess.RavenDb
{
    /// <summary>
    /// Base class for data access.
    /// </summary>
    public abstract class AbstractDataAccess
    {
        /// <summary>
        /// The default RavenDb document store.
        /// </summary>
        private static readonly Lazy<IDocumentStore> DefaultStore = new Lazy<IDocumentStore>(LoadStore);

        /// <summary>
        /// The current RavenDb document store.
        /// </summary>
        private static IDocumentStore store;

        /// <summary>
        /// Gets or sets the current RavenDb document store.
        /// </summary>
        public static IDocumentStore Store
        {
            get { return store ?? DefaultStore.Value; }
            set { store = value; }
        }

        /// <summary>
        /// Returns a new session.
        /// </summary>
        /// <returns>A new session.</returns>
        protected IAsyncDocumentSession CreateSession()
        {
            return Store.OpenAsyncSession();
        }

        /// <summary>
        /// Save the specified item.
        /// </summary>
        /// <param name="itemToSave">The item to save.</param>
        /// <returns>A task that represents saving the specified item.</returns>
        protected async Task SaveAsync(object itemToSave)
        {
            using (IAsyncDocumentSession session = this.CreateSession())
            {
                await session.StoreAsync(itemToSave);
                await session.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Loads the document store.
        /// </summary>
        /// <returns>The loaded store.</returns>
        private static IDocumentStore LoadStore()
        {
            string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            IDocumentStore documentStore = new EmbeddableDocumentStore()
            {
                DataDirectory = Path.Combine(baseDirectory, "RavenDb"),
#if DEBUG
                UseEmbeddedHttpServer = true,
#endif
                Configuration =
                {
                    CreateAnalyzersDirectoryIfNotExisting = false,
                    CompiledIndexCacheDirectory = Path.Combine(baseDirectory, "CompiledIndexCache"),
                    PluginsDirectory = Path.Combine(baseDirectory, "Plugins"),
#if DEBUG
                    HostName = "localhost",
                    Port = 12345
#endif
                }
            };
            try
            {
                documentStore.Initialize();
            }
            catch (Exception e)
            {
                e.GetHashCode();
                throw;
            }

            return documentStore;
        }
    }
}
