using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Joystick joystickMove;
    [SerializeField] private Joystick joystickShoot;
    private Animator _animator;
    private CharacterController cc;
    private float gravity = -9.8f;
    private IUpdateState currenState;
    public Animator _Animator
    {
        get => _animator;
        set => _animator = value;
    }
    public CharacterController Cc
    {
        get => cc;
        set => cc = value;
    }

    public float Speed => speed;
    public float RotationSpeed => rotationSpeed;
    public Transform _Camera => _camera;
    public Joystick  JoystickMove => joystickMove;
    public Joystick  JoystickShoot => joystickShoot;
    public float Gravity => gravity;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        currenState = new IdleState();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();

        currenState?.UpdateState(this,transform);
    }

    private void ChangeState()
    {
        if (joystickMove.Direction.magnitude == 0 && joystickShoot.Direction.magnitude == 0)
          currenState = new IdleState();
        
        else if (joystickMove.Direction.magnitude != 0)
            currenState = new RunState();
        
        else if (joystickShoot.Direction.magnitude != 0)
            currenState = new ShootState();
    }
    
}
