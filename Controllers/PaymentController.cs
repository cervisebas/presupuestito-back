using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService paymentService;

        public PaymentController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public async Task CreatePayment([FromBody] PaymentRequestDto paymentRequestDto)
        {
            await paymentService.CreatePayment(paymentRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdatePayment(int id, [FromBody] PaymentRequestDto paymentRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await paymentService.UpdatePayment(id, paymentRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResponseDto>> GetPaymentById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var payment = await paymentService.GetPaymentById(id);
            return Ok(payment);
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentResponseDto>>> GetAllPayments()
        {
            return await paymentService.GetAllPayments();
        }

        [HttpPatch("{id}")]
        public async Task DeletePayment(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await paymentService.DeletePayment(id);
        }

    }
}
