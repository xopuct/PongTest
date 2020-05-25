using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UiScoreItem : MonoBehaviour
{
    public TMP_Text Player1Score;
    public TMP_Text Player2Score;

    public void SetData((int, int) score)
    {
        Player1Score.text = score.Item1.ToString();
        Player2Score.text = score.Item2.ToString();
    }
}
