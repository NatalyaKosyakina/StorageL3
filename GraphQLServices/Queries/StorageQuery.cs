using StorageL3.DTO;
using StorageL3.Models;
using StorageL3.Repo;

namespace StorageL3.GraphQLServices.Queries
{
    public class StorageQuery
    {
        public IEnumerable<Storage> ShowStorages([Service] StorageRepo repo) => repo.ShowStorages();

        public int CreateStorage([Service] StorageRepo repo, StorageDto storageDto) => repo.CreateStorage(storageDto);

        public void DeleteStorage([Service] StorageRepo repo, int storageID) => repo.DeleteStorage(storageID);

        public void PutInStorage([Service] StorageRepo repo, int productID, int count, int storageID) =>
            repo.PutInStorage(productID, count, storageID);

        public void GetFromStorage([Service] StorageRepo repo, int productID, int count, int storageID) =>
            repo.GetFromStorage(productID, count, storageID);
    }
}
