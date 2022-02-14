using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State 
{
    public GameController gc;

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.GetType() + ": Enter");
        gc = GetComponent<GameController>();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log(this.GetType() + ": Exit");
    }

    public IEnumerator ShowPhaseBanner()
    {
        float phaseTime = 1f;
        float waitTime = 2f;
        float currentTimer = 0;
        while (currentTimer < phaseTime)
        {
            yield return null;
        }
        
    }

}
