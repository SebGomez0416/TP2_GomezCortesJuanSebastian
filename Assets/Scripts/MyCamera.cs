
using UnityEngine;

public class MyCamera : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private Vector3 offSet;
      
   private void LateUpdate()
   {
      transform.position = new Vector3(target.position.x - offSet.x, offSet.y, target.position.z - offSet.z);
   }
}
