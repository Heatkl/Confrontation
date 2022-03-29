using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    private void Start()
    {
        if(gameObject.CompareTag("Enemy"))
            Player.instance.AddEnemy(gameObject.transform);

        else if (gameObject.CompareTag("Player"))
            Player.instance.AddArmy(gameObject.transform);


    }

    private void OnDestroy()
    {
        gameOverPanel.SetActive(true);
    }
}
