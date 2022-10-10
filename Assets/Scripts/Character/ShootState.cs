using UnityEngine;

public class ShootState : IUpdateState
{
    public void UpdateState(PlayerController player,Transform p)
    {
        Vector3 movement= Vector3.zero;
        Debug.Log("ENTRO A AL SHOOT");
        player._Animator.SetTrigger("Shoot");
        var hor =   player.JoystickShoot.Horizontal ;
        movement.y = hor * (  player.RotationSpeed * Time.deltaTime);
        p.transform.Rotate(movement);
    }
}
