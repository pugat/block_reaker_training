using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public static int breakableCount = 0;
    private int timesHit;
    private levelManager levelmanager;
    public Sprite[] hitSprites;
    private bool isBreakable;
    public GameObject smoke;

    void Start () {
        levelmanager = GameObject.FindObjectOfType<levelManager>();
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable)
        {
            HitHandler();
        }    
    }  

    void HitHandler()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelmanager.BrickDestroyed();
            Instantiate(smoke, gameObject.transform.position, Quaternion.identity);           
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {        
        if(hitSprites[timesHit - 1] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        {
            Debug.LogError("Brick sprite missing!");
        }
    }

    void SimulateWin()
    {       
        levelmanager.LoadNextLevel();              
    }
}
