using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public int id;
    public float distanceToDetect;
    private TextMeshProUGUI txtDoor;
    public GameObject objTextDoor;
    private Transform player;
    private InventorController inventorController;
    public string TextLockerDoor, textOpenDoor, textUnlockedDoor;
    private Animator anim;
    public bool unlocked;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        txtDoor = objTextDoor.GetComponent<TextMeshProUGUI>();
        inventorController = player.GetComponent<InventorController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckProximity())
        {
            objTextDoor.SetActive(true);

            if (unlocked)
            {
                txtDoor.text = textUnlockedDoor;
                if (Input.GetKeyDown(KeyCode.E))
                    ChangeDoor();
            }
            else
            {
                var key = inventorController.keys.Where(x => x == id).FirstOrDefault();

                if (key != 0)
                {
                    txtDoor.text = textOpenDoor;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        unlocked = true;
                        ChangeDoor();
                    }
                }
                else
                {
                    txtDoor.text = TextLockerDoor;
                }
            }
        }
        else
        {
            objTextDoor.SetActive(false);
        }
    }

    void ChangeDoor()
    {
        anim.SetTrigger("open");
    }


    bool CheckProximity()
    {
        return Vector3.Distance(transform.position, player.position) <= distanceToDetect;
    }
}
