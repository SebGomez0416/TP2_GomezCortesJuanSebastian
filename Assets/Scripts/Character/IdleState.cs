using UnityEngine;

public class IdleState : IUpdateState
{
    public void UpdateState(PlayerController player,Transform p)
    {
        
        Debug.Log("ENTRO A AL IDLE");
        player._Animator.SetTrigger("Idle");
    }
}
