using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour
{
    const string bestScoresKey = "BestScores";
    public (int, int) CurrentScore;
    public (int, int) BestScore;

    public void Awake()
    {
        var jsonScores = PlayerPrefs.GetString(bestScoresKey, "");
        if (!string.IsNullOrWhiteSpace(jsonScores))
            BestScore = JsonUtility.FromJson<(int, int)>(jsonScores);
        else
            BestScore = (0, 0);
    }

    private void OnDestroy()
    {
        var bestScores = PickBestScores();
        var json = JsonUtility.ToJson(bestScores);
        PlayerPrefs.SetString(bestScoresKey, json);
    }

    public void UpdateScores(int player1Scores, int player2Scores)
    {
        CurrentScore = (player1Scores, player2Scores);
    }

    (int, int) PickBestScores()
    {
        if (CurrentScore.Item1 + CurrentScore.Item2 > BestScore.Item1 + BestScore.Item2)
            return CurrentScore;
        else
            return BestScore;
    }
}
