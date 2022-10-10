using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Joystick joystickMove;
    [SerializeField] private Joystick joystickShoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private WeaponData _weaponData;
    private Animator _animator;
    private CharacterController cc;
    private float gravity = -9.8f;
    private IUpdateState currenState;
    private float shootRateTime = 0;
    
    public WeaponData WeaponData
    {
        get => _weaponData;
        set => _weaponData = value;
    }
    public float ShootRateTime
    {
        get => shootRateTime;
        set => shootRateTime = value;
    }
    
    public GameObject Bullet
    {
        get => bullet;
        set => bullet = value;
    }

    public Transform SpawnPoint
    {
        get => spawnPoint;
        set => spawnPoint = value;
    }
    public IUpdateState CurrenState
    {
        get => currenState;
        set => currenState = value;
    }

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
       currenState?.UpdateState(this,transform);
    }

   
    
}
