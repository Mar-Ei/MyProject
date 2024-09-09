using Microsoft.AspNetCore.Mvc;

namespace Api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : ControllerBase
    {

        private static List<string> MedicalRecords = new()
        {
            "��������� ��������: 120/80 �� ��. ��., ����� 70 ��/���",
            "���������: ��������� 200 ��",
            "�������: �������� ����",
            "����: ��������",
            "������ ������ ������: 5.5 �����/�",
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
                return BadRequest("������������ �������� ��������� sortStrategy");
            }

            return Ok(result);
        }

        
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("������ �������� ������");
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
                return BadRequest("����������� ������ �� ����� ���� ������");
            }

            MedicalRecords.Add(record);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string record)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("������ �������� ������");
            }


            if (string.IsNullOrWhiteSpace(record))
            {
                return BadRequest("����������� ������ �� ����� ���� ������");
            }

            MedicalRecords[index] = record;
            return Ok();
        }

        
        [HttpDelete]
        public IActionResult Delete(int index)
        {

            if (index < 0 || index >= MedicalRecords.Count)
            {
                return BadRequest("������ �������� ������");
            }

            MedicalRecords.RemoveAt(index);
            return Ok();
        }
    }
}



