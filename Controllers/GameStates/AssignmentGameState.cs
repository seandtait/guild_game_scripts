using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentGameState : GameState 
{
    public override void Enter()
    {
        base.Enter();
        gc.DoneButton.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        gc.DoneButton.SetActive(false);
    }



}
