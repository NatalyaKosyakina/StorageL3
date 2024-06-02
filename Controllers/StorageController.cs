using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageL3.Abstractions;
using StorageL3.DTO;
using StorageL3.Models;

namespace StorageL3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private IStorageRepo _repo;

        public StorageController(IStorageRepo repo)
        {
            _repo = repo;
        }

        [HttpPost (template: "CreateStorage")]
        public IActionResult CreateStorage(StorageDto storageDto)
        {
            var answer = _repo.CreateStorage(storageDto);
            return Ok(answer);
        }

        [HttpDelete (template: "DeleteStorage")]
        public void DeleteStorage(int storageID)
        {
            _repo.DeleteStorage(storageID);
        }

        [HttpPost(template: "PutInStorage")]
        public void PutInStorage(int productID, int count, int storageID)
        {
            _repo.PutInStorage(productID, count, storageID);
        }

        [HttpDelete (template: "GetFromStorage")]
        public void GetFromStorage(int productID, int count, int storageID)
        {
            _repo.GetFromStorage(productID, count, storageID);
        }

        [HttpGet (template: "ShowStorages")]
        public IActionResult ShowStorages()
        {
            return Ok(_repo.ShowStorages());
        }
    }
}
