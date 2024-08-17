using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI text;
    int scoreCount = 1;

    public void ScoreUpdate()
    {
        text.SetText("Score: " + scoreCount++.ToString());
    }
}
