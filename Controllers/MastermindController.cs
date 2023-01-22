using Microsoft.AspNetCore.Mvc;

public class MastermindController : Controller
{
    private MastermindModel _model;
    public MastermindController()
    {
        _model = new MastermindModel();
    }

    public IActionResult Index()
    {
        var model = new MastermindModel();
        return View(model);
    }

    [HttpPost]

    public IActionResult Guess(int[] guess)
    {
        _model.TurnsRemaining--;
        _model.GuessHistory.Add(guess);

        int correctDigits = 0;
        int correctPositions = 0;
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] == _model.Solution[i])
            {
                correctPositions++;
            }
            else if (_model.Solution.Contains(guess[i]))
            {
                correctDigits++;
            }
        }
        ViewData["CorrectDigits"] = correctDigits;
        ViewData["CorrectPositions"] = correctPositions;

        return View("Index", _model);
    }

    public IActionResult NewGame()
    {
        _model = new MastermindModel();
        return RedirectToAction("Index");
    }
}