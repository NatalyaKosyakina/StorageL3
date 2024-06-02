using StorageL3.DTO;
using StorageL3.Models;

namespace StorageL3.Abstractions
{
    public interface IStorageRepo
    {
        /*Метод создания склада. 
         * Принимает название склада. Возвращает номер склада*/
        public int CreateStorage(StorageDto storageDto);

        /*Метод удаления склада*/
        public void DeleteStorage(int storageID);

        /*Метод для размещения продукта на складе. 
         * Принимает int productID - что размещаем, int storageID - где размещаем. */
        public void PutInStorage(int productID, int count, int storageID);

        /*Метода для удаления продукта со склада. 
         * Принимает int productID - что удаляем, int storageID - откуда удаляем. */
        public void GetFromStorage(int productID, int count, int storageID);

        /*Метод для вывода списка складов.*/
        public List<Storage> ShowStorages();

    }
}
