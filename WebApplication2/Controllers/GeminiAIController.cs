using Microsoft.AspNetCore.Mvc;
using WebApplication2.Client;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeminiAIController : ControllerBase
    {
        private readonly GeminiApiClient _geminiApiClient;
        

        public GeminiAIController(GeminiApiClient  geminiApiClient)
        {
            _geminiApiClient = geminiApiClient;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateContent([FromBody] PromptRequest request)
        {
            try
            {
                string response = await _geminiApiClient.GenerateContentAsync(request.Prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
