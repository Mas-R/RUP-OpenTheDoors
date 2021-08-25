using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragnDrop : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector2 _screenposition;
    private Vector3 _worldposition;
    private Vector3 _start;
    private bool bdoor2 = false;
    private void Start()
    {
    }
    private void Update()
    {
        
        if(_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        { 
            Drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenposition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            _screenposition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldposition = Camera.main.ScreenToWorldPoint(_screenposition);
        if(_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldposition, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.transform.gameObject.GetComponent<Door>()!=null)
                {
                    Door door = hit.transform.gameObject.GetComponent<Door>();
                    if (door != null)
                    {
                        InitDrag();
                    }
                }
                if (hit.transform.gameObject.GetComponent<Door2>() != null)
                {
                    Door2 door2 = hit.transform.gameObject.GetComponent<Door2>();
                    if (door2 != null)
                    {
                        bdoor2 = true;
                        InitDrag();
                    }
                }
                
            }
        }
    }
    private void InitDrag()
    {
        _isDragActive = true;
        this._start = transform.position;
    }
    private void Drop()
    {
        _isDragActive = false;
        transform.position = _start;
        if(bdoor2)
        {
            LevelManager.activeindex = true;
        }
        bdoor2 = false;
    }
    private void Drag()
    {
        transform.position = new Vector2(_worldposition.x, _worldposition.y);
    }
    
    
}
