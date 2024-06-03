using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlushPuzzle{
public class RightChoiceController : MonoBehaviour
{
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private GameObject SpawnPrefab;

  
private void OnCollisionEnter(Collision collision){
    
      GameObject Key = Instantiate(SpawnPrefab, Spawnpoint.position, Quaternion.identity) as GameObject;
    }
    
}
}