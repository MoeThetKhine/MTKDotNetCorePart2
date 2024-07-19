using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace MTKDotNetCorePart2.PickAPie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PickAPieController : ControllerBase
{
    private async Task<PickAPie> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<PickAPie>(jsonStr);
        return model!;
    }

    [HttpGet("questions")]
    public async Task<IActionResult> Questions()
    {
        var model = await GetDataAsync();
        return Ok(model.Questions);

    }

    [HttpGet("Answer{qId}")]
    public async Task<IActionResult> Answer(int qId)
    {
        var model = await GetDataAsync();
        var answers = model.Answers.Where(x => x.QuestionId == qId).ToList();

        return Ok(answers);
    }

    [HttpGet("{answerName}/{questionId}")]
    public async Task<IActionResult> Answers(string answerName, int questionId)
    {
        var model = await GetDataAsync();
        var answer = model.Answers.FirstOrDefault(x => x.AnswerName == answerName && x.QuestionId == questionId);

        return Ok(answer);
    }
}
