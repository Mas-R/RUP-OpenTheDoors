using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI point;
    public GameObject door;
    public GameObject door1;
    public GameObject door2;
    public GameObject UpPanel;
    public GameObject DownPanel;
    private int pointindex = 0;
    public static bool activeindex = false;
    private static GameObject[] doors;
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
        if (check == true)
        {
            doors = GameObject.FindGameObjectsWithTag("Door");
            RandomDoor();
            DoorManagement();
            pointindex++;
            point.text = "" + pointindex;
        }
    }

    private void DoorManagement()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        GetChildObject(doors[0].transform,"Input");
        GetChildObject(doors[0].transform, "Finish");
        GetChildObject(doors[0].transform, "Finish2");
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
        
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                Instantiate(door);
                break;
            case 1:
                Instantiate(door1);
                break;
            case 2:
                Instantiate(door2);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                child.gameObject.SetActive(true);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag);
            }
        }
    }
}