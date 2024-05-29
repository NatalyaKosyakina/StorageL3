using StorageL3.Abstractions;
using StorageL3.db;
using StorageL3.Models;

namespace StorageL3.Repo
{
    public class StorageRepo : IStorageRepo
    {
        private StorageContext _context;

        public StorageRepo(StorageContext context)
        {
            _context = context;
        }
        public int CreateStorage(string storageName)
        {
            using (_context)
            {
                var storage = _context.Storages.FirstOrDefault(x => x.Name.Equals(storageName));

                if (storage != null)
                {
                    return storage.Id;
                }
                else
                {
                    _context.Storages.Add(new Storage()
                    {
                        Name = storageName,
                        Products = new List<ProductStorage>()
                    });
                    _context.SaveChanges();
                }
                storage = _context.Storages.FirstOrDefault(x => x.Name.Equals(storageName));
                return storage.Id;
            }
        }

        public void GetFromStorage(int productID, int count, int storageID)
        {
            using (_context)
            {
                var storage = _context.productStorages.FirstOrDefault(x => x.StorageID == storageID && x.ProductId == productID);
                if (storage == null)
                {
                    throw new InvalidOperationException("На такой склад не поступал этот товар");
                }
                else
                {
                    if (count > storage.Count)
                    {
                        throw new InvalidOperationException($"Не хватает {count - storage.Count} единиц товара");
                    }
                    else
                    {
                        storage.Count -= count;
                        _context.SaveChanges();
                    }
                }
                
            }
        }

        public void DeleteStorage(int storageID)
        {
            using (_context)
            {
                var storage = _context.Storages.FirstOrDefault(x => x.Id == storageID);
                if (storage != null)
                {
                    _context.Storages.Remove(storage);
                    _context.SaveChanges();
                }
            }
        }

        public void PutInStorage(int productID, int count, int storageID)
        {
            using (_context)
            {
                var storage = _context.productStorages.FirstOrDefault(x => x.StorageID == storageID && x.ProductId == productID);
                if (storage == null)
                {
                    _context.productStorages.Add(new ProductStorage() { ProductId = productID, Count = count, StorageID = storageID});
                }
                else
                {
                    storage.Count += count;
                }
                _context.SaveChanges();
            }
        }
    
    }
}
