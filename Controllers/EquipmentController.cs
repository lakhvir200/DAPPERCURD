using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCurd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCurd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentRepository equipmentRepository;

        public EquipmentController()
        {
            equipmentRepository = new EquipmentRepository();

        }
        [HttpGet]
        public IEnumerable<Equipments> Get()
        {
            return equipmentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Equipments Get(int id)
        {

            return equipmentRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Equipments equipment)
        {
            if(ModelState.IsValid)
            equipmentRepository.Add(equipment);
                       
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Equipments equipment)
        {
            equipment.EquipmentID = id;
            if (ModelState.IsValid)
                equipmentRepository.Update(equipment);

        }

        [HttpDelete]
        public void Delete(int id)
        {
            equipmentRepository.Delete(id);

        }

    }
}