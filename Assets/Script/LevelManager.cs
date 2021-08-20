using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject door;
    public GameObject door1;
    public GameObject UpPanel;
    public GameObject DownPanel;
    public static GameObject[] doors;
    public static int index = 0;
    private static int indexa = 0;
    public static bool check = false;
    // Start is called before the first frame update
    void Awake()
    {
        RandomDoor();
        RandomDoor();
        DoorManagement();
    }

    // Update is called once per frame
    void Update()
    { 
        if(check == true)
        {
            doors = GameObject.FindGameObjectsWithTag("Door");
            RandomDoor();
            DoorManagement();
        }
    }

    private void DoorManagement()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        doors[0].transform.GetChild(2).gameObject.SetActive(true);
        doors[0].transform.GetChild(3).gameObject.SetActive(true);
        doors[0].transform.SetParent(UpPanel.transform);
        doors[1].transform.SetParent(DownPanel.transform);
        foreach (GameObject x in doors)
        {

            x.transform.localScale = new Vector3(1, 1, 1);

        }
        check = false;
    }

    private void RandomDoor()
    {
        int random = Random.Range(0,2);
        switch (random)
        {
            case 0:
                Instantiate(door);
                break;
            case 1:
                Instantiate(door1);
                
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
