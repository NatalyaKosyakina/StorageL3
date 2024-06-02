using StorageL3.Abstractions;
using StorageL3.DTO;
using StorageL3.Models;

namespace StorageL3.GraphQLServices.Mutations
{
    public class Mutation
    {
        private readonly IStorageRepo _storageRepo;

        public Mutation(IStorageRepo storageRepo)
        {
            _storageRepo = storageRepo;
        }

        public List<Storage> ShowStorages() => _storageRepo.ShowStorages();

        public int CreateStorage(StorageDto storageDto) => _storageRepo.CreateStorage(storageDto);

        public void DeleteStorage(int storageID) => _storageRepo.DeleteStorage(storageID);

        public void GetFromStorage(int productID, int count, int storageID) => _storageRepo.GetFromStorage(productID, count, storageID);

        public void PutInStorage(int productID, int count, int storageID) => _storageRepo.PutInStorage(productID, count, storageID);
    }
}
