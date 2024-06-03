using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlushPuzzle{
public class WrongChoice : MonoBehaviour
{
     

    // Private Variable
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private PlushPuzzleChoices _plushPuzzleChoices = null;
    //[SerializeField] private Animator explode;
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private bool explodeOnInteract = false;
    [SerializeField] private GameObject effectsPrefab;
    [SerializeField] private float effectsdisplayTime = 3.0f;
    //[SerializeField] private bool Active = false;
    
    private float delaytimer;

    //Unity Methods
    private void Awake (){
        delaytimer = 0.0f;
    }

    private void Update(){
        delaytimer += Time.deltaTime;

        if (delaytimer >= delay && !explodeOnInteract) {
            DoExplosion();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (explodeOnInteract && enabled) {
            DoExplosion();
            Destroy(gameObject);
            DoGameOver();}
    }
    //Helper Methods
    private void DoExplosion (){
        HandleEffects();
        

    }
   

    private void HandleEffects(){
        if(effectsPrefab != null){
            GameObject effect = Instantiate(effectsPrefab, transform.position, Quaternion.identity);
            Destroy(effect, effectsdisplayTime);
        }
    }
    private void DoGameOver (){
        SceneManager.LoadScene("GameOver");
    }

}
}
