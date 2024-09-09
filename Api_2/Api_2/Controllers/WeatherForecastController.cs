using Microsoft.AspNetCore.Mvc;

namespace Api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : ControllerBase
    {

        private static List<string> MedicalRecords = new()
        {
            "Измерение давления: 120/80 мм рт. ст., пульс 70 уд/мин",
            "Лекарство: Ибупрофен 200 мг",
            "Симптом: головная боль",
            "Врач: терапевт",
            "Запись уровня сахара: 5.5 ммоль/л",
        };

        private readonly ILogger<MedicalRecordController> _logger;

        public MedicalRecordController(ILogger<MedicalRecordController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            List<string> result = MedicalRecords;


            if (sortStrategy == null)
            {
                return Ok(result);
            }

            else if (sortStrategy == 1)
            {
                result = result.OrderBy(s => s).ToList();
            }

            else if (sortStrategy == -1)
            {
                result = result.OrderByDescending(s => s).ToList();
            }

            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }

            return Ok(result);
        }

        
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("Указан неверный индекс");
            }

            return Ok(MedicalRecords[index]);
        }

        
        [HttpGet("find-by-name")]
        public IActionResult FindByName(string name)
        {

            int count = MedicalRecords.Count(s => s.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Ok(count);
        }

       
        [HttpPost]
        public IActionResult Add(string record)
        {

            if (string.IsNullOrWhiteSpace(record))
            {
                return BadRequest("Медицинская запись не может быть пустой");
            }

            MedicalRecords.Add(record);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string record)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("Указан неверный индекс");
            }


            if (string.IsNullOrWhiteSpace(record))
            {
                return BadRequest("Медицинская запись не может быть пустой");
            }

            MedicalRecords[index] = record;
            return Ok();
        }

        
        [HttpDelete]
        public IActionResult Delete(int index)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("Указан неверный индекс");
            }

            MedicalRecords.RemoveAt(index);
            return Ok();
        }
    }
}



