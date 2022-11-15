using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   [SerializeField] private GameObject model;
   [SerializeField] private float timeToSpawn;
   [SerializeField] private Transform target;
   

   private void Start()
   {
      InvokeRepeating("Spawn",0,timeToSpawn);
   }

   private void Spawn()
   {
      GameObject e= Instantiate(model, transform.position, transform.rotation);
      e.GetComponent<EnemyController>().Target = target;
   }
}
