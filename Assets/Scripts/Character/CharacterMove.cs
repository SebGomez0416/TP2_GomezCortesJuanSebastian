using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Joystick joystickMove;
    private Animator animator;
    private Vector3 movement;
    private CharacterController cc;
    private float gravity = -9.8f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
         var ver =  joystickMove.Vertical +Input.GetAxis("Vertical");
         var hor = joystickMove.Horizontal + Input.GetAxis("Horizontal");
         movement=Vector3.zero;

         if (hor != 0 || ver != 0)
         {
             animator.SetTrigger("Run");
             Vector3 forward = _camera.forward;
             forward.y = 0;
             forward.Normalize();
             
             Vector3 right = _camera.right;
             right.y = 0;
             right.Normalize();

             Vector3 direction = forward * ver + right * hor;
             direction.Normalize();

             movement = direction * (speed * Time.deltaTime);
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement),0.2f);
         }

         movement.y += gravity * Time.deltaTime;
         cc.Move(movement);

         if (hor == 0 && ver ==0)
         {
             animator.SetTrigger("Idle");
         }
         
        
        
        
    }
   
}
