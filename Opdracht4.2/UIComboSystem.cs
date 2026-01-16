using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;
    public TMP_Text multiplierField;
    public TMP_Text ballsField;


private void OnEnable()
{
    ComboSystem.OnScoreChange += UpdateUI;          
    CountBalls.OnBallsChanged += UpdateBallsUI;    // Listen to ball changes
}

private void OnDisable()
{
    ComboSystem.OnScoreChange -= UpdateUI;          
    CountBalls.OnBallsChanged -= UpdateBallsUI;
}

// Only update the balls text
private void UpdateBallsUI(int balls)
{
    ballsField.text = "Balls left: " + balls;
}

// Your existing UpdateUI can still update score & multiplier
private void UpdateUI(int score, int multiplier)
{
    scoreField.text = "Score: " + score;
    multiplierField.text = "Multiplier: " + multiplier + "X";
    // ballsField not updated here
}
}