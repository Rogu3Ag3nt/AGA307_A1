using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{

    void Start()
    {
        
    }

   
    public void Update()
    {
        
    }
    public void LoadLevel()
    {
        print("Load the level");
        SceneManager.LoadScene(0);
    }
}
