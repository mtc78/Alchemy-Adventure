using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int LevelToLoad; //set this in the editor under scripts to the level to load (level 1 is 0, level 2 is 1)
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
