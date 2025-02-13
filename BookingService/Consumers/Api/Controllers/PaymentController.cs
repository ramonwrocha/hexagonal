using Application.Payment.Models.Requests;
using Application.Payment.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
    {
        var response = await paymentService.CreatePaymentAsync(request);

        return Ok(response);
    }
}
