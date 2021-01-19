using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] AudioClip shredderSound;

    [SerializeField] [Range(0, 1)] float shredderSoundVolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.GetComponent<PolygonCollider2D>()) 
        {
            
            AudioSource.PlayClipAtPoint(shredderSound, Camera.main.transform.position, shredderSoundVolume);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
        Destroy(otherObject.gameObject);
        

    }

}
