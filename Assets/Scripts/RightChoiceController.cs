using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlushPuzzle{
public class RightChoiceController : MonoBehaviour
{
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private GameObject SpawnPrefab;
    private bool IsSpawned = false;

  
private void OnCollisionEnter(Collision collision){
    if (IsSpawned == false){

    IsSpawned = true;
      GameObject Key = Instantiate(SpawnPrefab, Spawnpoint.position, Quaternion.identity) as GameObject;
      Destroy(gameObject);
      DoCredits();
    }
}
private void DoCredits (){
        SceneManager.LoadScene("Credits");
    }
}
}