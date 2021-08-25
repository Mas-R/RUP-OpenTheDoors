using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    private int index=1;
    public GameObject parent;
    public Animator anim;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Finish2"))
        {
            if(collision.GetComponent<DoorIndex>().index == index)
            {
                collision.gameObject.SetActive(false);
                index++;
            }
        }

    }
    private void Start()
    {
        
    }
    void Update()
    {
       if(LevelManager.activeindex)
        {
            GetChildObject(parent.transform, "Finish2");
            index = 1;
            LevelManager.activeindex = false;
        }
       if(index == 4)
        {
            LevelManager.activeindex = false;
            StartCoroutine(StartAnim());
        }
    }
    public IEnumerator StartAnim()
    {
        anim.SetBool("OpenDoor", true);
        yield return new WaitForSeconds(0.75f);
        LevelManager.check = true;
        Destroy(parent);
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

