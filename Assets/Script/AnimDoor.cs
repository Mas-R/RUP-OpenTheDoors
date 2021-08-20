using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDoor : MonoBehaviour
{
    public GameObject parent;
    public Animator anim;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Input"))
        {
            StartCoroutine(StartAnim());
        }
        
    }

    IEnumerator StartAnim()
    {
        anim.SetBool("OpenDoor", true);
        yield return new WaitForSeconds(0.75f);
        LevelManager.check = true;
        Destroy(parent);
    }
}
