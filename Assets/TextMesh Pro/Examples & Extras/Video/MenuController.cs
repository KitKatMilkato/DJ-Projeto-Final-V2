using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
     public VideoPlayer videoPLayer;
     public GameObject menuOpcoes, rawImage;

     private Animator aniomatorRawImage;
    void Start()
    {
        rawImage.SetActive(false);
        aniomatorRawImage = rawImage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!videoPLayer.isPlaying && Input.anyKey) 
        {
             videoPLayer.Play();
             aniomatorRawImage.SetTrigger("Fade-in");
             rawImage.SetActive(true);
             menuOpcoes.SetActive(true);
        }
        
    }
}
