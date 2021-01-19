using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Runs even before Start()
    void Awake()
    {
        SetUpSingolton();
    }

    private void SetUpSingolton()
    {
        //GetType(): gets the type of Object attached to this script: Music Player
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //if there is more than one music player, destroy the last one
            Destroy(gameObject);
        }
        else
        {
            //dont destroy the music player when changing scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
