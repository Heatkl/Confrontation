using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void Start()
    {
        if(gameObject.CompareTag("Enemy"))
            Player.instance.AddEnemy(gameObject.transform);

        else if (gameObject.CompareTag("Player"))
            Player.instance.AddArmy(gameObject.transform);


    }
}
