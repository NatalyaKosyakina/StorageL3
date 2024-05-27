using StorageL3.Models;

namespace StorageL3.Abstractions
{
    public interface IStorageRepo
    {
        /*Метод создания склада. 
         * Принимает название склада. Возвращает номер склада*/
        public int CreateStorage(string storageName);

        /*Метод удаления склада*/
        public void DeleteStorage(int storageID);

        /*Метод для размещения продукта на складе. 
         * Принимает int productID - что размещаем, int storageID - где размещаем. */
        public void PutInStorage(int productID, int storageID);

        /*Метода для удаления продукта со склада. 
         * Принимает int productID - что удаляем, int storageID - откуда удаляем. */
        public void DeleteInStorage(int productID, int storageID);
    }
}
