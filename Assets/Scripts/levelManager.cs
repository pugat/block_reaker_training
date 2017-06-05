using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {
    
	public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quitRequest()
    {      
        Application.Quit();
    }

    public void LoadNextLevel()
    {      
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount<=0)
        {
            LoadNextLevel();
        }
    }
}
