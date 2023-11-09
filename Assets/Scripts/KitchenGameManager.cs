using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public event EventHandler OnStateChange;

    public static KitchenGameManager Instance { get; private set; }

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 5f;

    private State state;

    private void Awake()
    {
        Instance = this;

        state = State.WaitingToStart;
    }

    private void Update()
    {

        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChange?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaing()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }
}