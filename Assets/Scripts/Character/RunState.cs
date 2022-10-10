using UnityEngine;

public class RunState : IUpdateState
{
    public void UpdateState(PlayerController player,Transform p)
    {
        
        var ver =  player.JoystickMove.Vertical +Input.GetAxis("Vertical");
        var hor =  player.JoystickMove.Horizontal + Input.GetAxis("Horizontal");
        Vector3 movement=Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            player._Animator.SetTrigger("Run");
            Vector3 forward =  player._Camera.forward;
            forward.y = 0;
            forward.Normalize();
             
            Vector3 right =  player._Camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            direction.Normalize();

            movement = direction * ( player.Speed * Time.deltaTime);
            p.rotation = Quaternion.Slerp(p.rotation, Quaternion.LookRotation(movement),0.2f);
        }

        movement.y +=  player.Gravity * Time.deltaTime;
        player.Cc.Move(movement);
        
        if (player.JoystickShoot.Direction.magnitude != 0)
            player.CurrenState = new ShootState();
        
        else if (player.JoystickMove.Direction.magnitude == 0)
            player.CurrenState = new IdleState();
    }
}
