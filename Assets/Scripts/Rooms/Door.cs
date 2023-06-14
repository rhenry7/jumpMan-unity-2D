using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform previousRoom;

    [SerializeField]
    private Transform nextRoom;

    [SerializeField]
    private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom (nextRoom);
                nextRoom.GetComponent<Room1>().ActivateRoom(true);
                previousRoom.GetComponent<Room1>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom (previousRoom);
                previousRoom.GetComponent<Room1>().ActivateRoom(true);
                nextRoom.GetComponent<Room1>().ActivateRoom(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
