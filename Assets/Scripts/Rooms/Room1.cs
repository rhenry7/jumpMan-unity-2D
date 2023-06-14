using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private Vector3[] initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // initial enemy position
        initialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPosition[i] = enemies[i].transform.position;
        }
    }

    public void ActivateRoom(bool _status)
    {
        // Activate / deactivate enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = initialPosition[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
