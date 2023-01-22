public class MastermindModel
{
    public int[] Solution { get; set; }
    public int TurnsRemaining { get; set; }
    public List<int[]> GuessHistory { get; set; }

    public MastermindModel()
    {
        TurnsRemaining = 10;
        GuessHistory = new List<int[]>();

        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://www.random.org/integers/?num=4&min=1&max=6&col=1&base=10&format=plain&rnd=new";
            string apiResponse = client.GetStringAsync(apiUrl).Result;
            string[] responseArray = apiResponse.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int[] SolutionArray = new int[responseArray.Length];
            for (int i = 0; i < responseArray.Length; i++)
            {
                SolutionArray[i] = int.Parse(responseArray[i]);
            }
            Solution = SolutionArray;
        }
    }
}