namespace MTKDotNetCorePart2.PickAPie.Models;

public class Answer
{
    public int AnswerId { get; set; }
    public string AnswerImageUrl { get; set; }
    public string AnswerName { get; set; }
    public string AnswerDesp { get; set; }
    public int QuestionId { get; set; }
}
