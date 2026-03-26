using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Character character;


    public Sprite doorLocked;
    public Sprite doorOpen;

    public String sceneName;

    bool lockedState = true;
    SpriteRenderer spriteRenderer;

    public int key = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //remember to set things up in engine as well
        character.OnKeyCollected.AddListener(keyCount);
    }

    void UpdateState()
    {
        spriteRenderer.sprite = lockedState ? doorLocked : doorOpen;
    }

    public void SetLock(bool lockState)
    {
        lockedState = lockState;
        UpdateState();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!lockedState && other.gameObject.CompareTag("character"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    

    //
    public void keyCount()
    {
        key++;
        UIKeyCount();
    }
    
    //
    public void UIKeyCount()
    {
        if(key == 2)
        {
            SetLock(false);
        }
    }

}
