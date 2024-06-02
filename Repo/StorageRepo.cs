using AutoMapper;
using StorageL3.Abstractions;
using StorageL3.db;
using StorageL3.DTO;
using StorageL3.Models;

namespace StorageL3.Repo
{
    public class StorageRepo : IStorageRepo
    {
        private StorageContext _context;
        private readonly IMapper _mapper;

        public StorageRepo(StorageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Storage> ShowStorages()
        {
            var storages = _context.Storages.ToList();
            return storages;
        }
        public int CreateStorage(StorageDto storageDto)
        {
            var storage = _context.Storages.FirstOrDefault(x => x.Name.Equals(storageDto.Name));

            if (storage != null)
            {
                return storage.Id;
            }
            else
            {
                var entStorage = _mapper.Map<Storage>(storageDto);
                _context.Storages.Add(entStorage);
                _context.SaveChanges();
            }
            storage = _context.Storages.FirstOrDefault(x => x.Name.Equals(storageDto.Name));
            return storage.Id;
        }

        public void GetFromStorage(int productID, int count, int storageID)
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

        public void DeleteStorage(int storageID)
        {
            var storage = _context.Storages.FirstOrDefault(x => x.Id == storageID);
            if (storage != null)
            {
                _context.Storages.Remove(storage);
                _context.SaveChanges();
            }
        }

        public void PutInStorage(int productID, int count, int storageID)
        {
            var storage = _context.productStorages.FirstOrDefault(x => x.StorageID == storageID && x.ProductId == productID);
            if (storage == null)
            {
                _context.productStorages.Add(new ProductStorage() { ProductId = productID, Count = count, StorageID = storageID });
            }
            else
            {
                storage.Count += count;
            }
            _context.SaveChanges();
        }
    
    }
}
