using UnityEngine;

public class IdleState : IUpdateState
{
   public void UpdateState(PlayerController player,Transform p)
    {
       player._Animator.SetTrigger("Idle/Shoot");

       if (player.JoystickShoot.Direction.magnitude != 0)
       {
           player.Sight.SetActive(true);
           player.CurrenState = new ShootState();
       }
       else if (player.JoystickMove.Direction.magnitude != 0)
       {
            player.Weapon.SetActive(false);
            player.CurrenState = new RunState();
       }
            
    }
}
