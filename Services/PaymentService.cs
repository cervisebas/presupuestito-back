using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        public async Task CreatePayment(PaymentRequestDto paymentRequestDto)
        {
            var payment = mapper.Map<Payment>(paymentRequestDto);
            payment.Status = true;
            await paymentRepository.Insert(payment);
        }

        public async Task UpdatePayment(int id, PaymentRequestDto paymentRequestDto)
        {
            var existingPayment = await paymentRepository.GetById(id);
            if (existingPayment == null)
            {
                throw new Exception("El pago no existe");
            }
            else
            {
                mapper.Map(paymentRequestDto, existingPayment);
                await paymentRepository.Update(existingPayment);
            }
        }

        public async Task<ActionResult<PaymentResponseDto>> GetPaymentById(int id)
        {
            var payment = await paymentRepository.GetById(id);
            if (payment == null)
            {
                throw new KeyNotFoundException("El pago no fue encontrado.");
            }
            else
            {
                return mapper.Map<PaymentResponseDto>(payment);
            }
        }

        public async Task<ActionResult<List<PaymentResponseDto>>> GetAllPayments()
        {
            var payments = await paymentRepository.GetAll();
            if (payments == null)
            {
                throw new Exception("Pagos no encontrados.");
            }
            else
            {
                return mapper.Map<List<PaymentResponseDto>>(payments);
            }
        }

        public async Task DeletePayment(int id)
        {
            var payment = await paymentRepository.GetById(id);
            if (payment == null)
            {
                throw new KeyNotFoundException("El pago no fue encontrado.");
            }
            else
            {
                payment.Status = false;
                await paymentRepository.Update(payment);
            }
        }

    }
}
