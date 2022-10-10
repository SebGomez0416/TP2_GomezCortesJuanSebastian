using UnityEngine;

public class ShootState :MonoBehaviour, IUpdateState
{
    public void UpdateState(PlayerController player,Transform p)
    {
        Vector3 movement= Vector3.zero;
       
        player._Animator.SetTrigger("Idle/Shoot");
        var hor =   player.JoystickShoot.Horizontal ;
        movement.y = hor * (  player.RotationSpeed * Time.deltaTime);
        p.transform.Rotate(movement);

        if (player.JoystickShoot.Direction.magnitude == 0)
        {
            Shoot(player);
            player.CurrenState = new IdleState();
        }
        else if (player.JoystickMove.Direction.magnitude != 0)
            player.CurrenState = new RunState();
        

    }

    private void Shoot(PlayerController p)
    {
        if (Time.time > p.ShootRateTime)
        {
            GameObject newBullet;

            newBullet = Instantiate(p.Bullet, p.SpawnPoint.position, p.SpawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(p.SpawnPoint.forward*p.WeaponData.ShootForce);

            p.ShootRateTime = Time.time +  p.WeaponData.ShootRate;
            Destroy(newBullet,2.0f);
        }
        
    }
}
