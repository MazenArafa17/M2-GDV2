using System.Collections.Generic;
using System;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    private int scoreMultiplier = 1;
    public static event Action<int, int> OnScoreChange;

    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;             //luisteren naar action event onBumperHit als game start
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;             //stop met luisteren naar action event onBumperHit als scene herstart of game stopt
    }

private void CheckForCombo(string bumperTag, int bumperValue)
{
    bumperTags.Add(bumperTag);

    if (bumperTags.Count > 1)
    {
        if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
        {
            scoreMultiplier++;
        }
        else
        {
            scoreMultiplier = 1;
            bumperTags.Clear();
        }
    }

    ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);
    OnScoreChange?.Invoke(ScoreManager.Instance.score, scoreMultiplier);
}
}