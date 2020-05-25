using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiScores : MonoBehaviour
{
    public UiScoreItem CurrentScores;
    public UiScoreItem BestScores;
    public Scores Scores;

    private void Update()
    {
        CurrentScores.SetData(Scores.CurrentScore);
        BestScores.SetData(Scores.BestScore);
    }
}
