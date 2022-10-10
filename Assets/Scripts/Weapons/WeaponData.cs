using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon Data",menuName = "WeaponData" )]
public class WeaponData : ScriptableObject
{
    [SerializeField]private string name;
    [SerializeField]private int cost;
    [SerializeField]private float shootForce;
    [SerializeField]private float shootRate;
    [SerializeField]private GameObject model;

    public float ShootRate => shootRate;
    public GameObject Model => model;
    public string Name => name;
    public int Cost => cost;
    public float ShootForce => shootForce;
    

}
