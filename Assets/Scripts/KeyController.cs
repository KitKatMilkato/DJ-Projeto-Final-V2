using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int id;
    public float distanceToDetect;
    public string textKey;
    private Transform player;

    public GameObject objtextKey;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= distanceToDetect)
        {
            objtextKey.SetActive(true);
            objtextKey.GetComponent<TextMeshProUGUI>().text = textKey;

            if(Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<InventorController>().AddItem(id);
                objtextKey.SetActive(false);
                Destroy(gameObject);
            }
        }
        else{
            objtextKey.SetActive(false);
        }
    }
}
