using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Joystick joystickMove;
    private Animator animator;
    private Vector3 movement;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
             rb.MovePosition(rb.position + movement);
             
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement),0.2f);
         }

         if (hor == 0 && ver ==0)
         {
             animator.SetTrigger("Idle");
         }
         
        
        
        
    }
   
}
