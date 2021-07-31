using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChenget;
    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChenget?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChenget?.Invoke(_score);
        _birdMover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();        
    }
}