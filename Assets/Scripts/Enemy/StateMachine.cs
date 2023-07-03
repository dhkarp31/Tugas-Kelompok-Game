using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialise()
    {
        ChangeState(new PatrolState());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        //check activeState
        if(activeState != null)
        {
            //run on activeState
            activeState.Exit();
        }
        //change to new state
        activeState = newState;

        //new state wasn't null
        if (activeState != null)
        {
            //setup new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
