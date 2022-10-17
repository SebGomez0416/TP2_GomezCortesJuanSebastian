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
    private IUpdateState currenState;
    private float shootRateTime = 0;
    private GameObject weapon;
    private GameObject sight;
    private int life;
    private bool tutorial;
    
    public GameObject Sight
    {
        get => sight;
        set => sight = value;
    }
    public GameObject Weapon
    {
        get => weapon;
        set => weapon = value;
    }
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

    public static event Action OnSendDamage;

    private void Awake()
    {
        tutorial = true;
        life = 3;
        cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        currenState = new IdleState();
        SpawnWeapon();
    }

    private void OnEnable()
    {
        ScreenTutorial.OnTutorial += SetTutorial;
        Tip.OnTutorial += SetTutorial;
    }

    private void OnDisable()
    {
        ScreenTutorial.OnTutorial -= SetTutorial;
        Tip.OnTutorial -= SetTutorial;
    }

    void Update()
    {
        if (tutorial)
        {
           _animator.SetTrigger("Idle/Shoot");
        }
        else  currenState?.UpdateState(this,transform);
       
    }
    private void SpawnWeapon()
    {
         weapon = Instantiate(_weaponData.Model, spawnPoint);
         sight= GameObject.Find("Sight");
         sight.SetActive(false);
    }

    private void OnCollisionEnter(Collision c)
    {
        Debug.Log("entro");
        if (!c.gameObject.CompareTag("Enemy")) return;
        Debug.Log("enemigo");
        IsDEAD();
        OnSendDamage?.Invoke();
    }
    private void IsDEAD()
    {
        life--;
        if (life > 0) return;
        _animator.SetTrigger("Dying");
        Destroy(gameObject,3.1f);
    }

    private void SetTutorial()
    {
        tutorial = !tutorial;
    }
}
