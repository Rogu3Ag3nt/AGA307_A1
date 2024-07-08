using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Scoremanager : MonoBehaviour
{
    
    static public int timeRemaning = 200;
    public GameObject Scoretextbox;


    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        Scoretextbox.GetComponent<Text>().text = "Time Remaning =" + timeRemaning.ToString();
    }

    public IEnumerator Timer()
    {
       yield return new WaitForSeconds(1);
        timeRemaning -= 1;
        StartCoroutine(Timer());
    
    
    }


}
