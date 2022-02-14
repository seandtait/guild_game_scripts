using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    public virtual State GetState()
    {
        State _s = GetComponent<State>();
        return _s;
    }

    public void ChangeState<T>() where T: State
    {
        // Remove Previous
        if (currentState)
        {
            currentState.Exit();
        }
        DestroyImmediate(currentState);

        // Add new
        currentState = gameObject.AddComponent<T>();
        currentState.Enter();
    }




}
