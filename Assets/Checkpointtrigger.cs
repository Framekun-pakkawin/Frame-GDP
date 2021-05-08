using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointtrigger : MonoBehaviour
{
    public int numberofcheckpoint = 1;
    bool activated = false;
    private string CurrentState;
    public Animator townanim;
    private void Update()
    {
        if (activated)
        {
            ChangeAnimationState("Checkpointactivate");
        }
    }
    public void ChangeAnimationState(string NewState)
    {
        if (CurrentState != NewState)
        {
            townanim.Play(NewState);

            CurrentState = NewState;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement.currentcheckpoint = numberofcheckpoint;
            activated = true;
        }
    }
}
