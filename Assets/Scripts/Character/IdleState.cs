using UnityEngine;

public class IdleState : IUpdateState
{
   public void UpdateState(PlayerController player,Transform p)
    {
        player._Animator.SetTrigger("Idle/Shoot");
        
        if (player.JoystickShoot.Direction.magnitude != 0)
            player.CurrenState = new ShootState();
        
        else if (player.JoystickMove.Direction.magnitude != 0)
            player.CurrenState = new RunState();
    }
}
