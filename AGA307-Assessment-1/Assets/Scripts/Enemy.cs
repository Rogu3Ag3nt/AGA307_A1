using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTypes myTypes;
    public int health;
    
    float moveDistance = 500;



    void Start()
    {
        if (myTypes == EnemyTypes.Archer)
            health = 50;
        if (myTypes == EnemyTypes.OneHanded)
            health = 100;
        if (myTypes == EnemyTypes.Twohanded)
            health = 200;
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }
    void Setup()
    {
        switch (myTypes)
        {
            case EnemyTypes.Archer:
                health = 50;   
                break;
            case EnemyTypes.OneHanded:
                health = 100;
                break;
            case EnemyTypes.Twohanded:
                health = 200;
                break;

        }
    }


}
