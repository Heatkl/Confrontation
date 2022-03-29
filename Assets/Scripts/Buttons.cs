using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private ArcherFactory archerFactory;
    [SerializeField] private WarriorFactory warriorFactory;
    [SerializeField] private TitanFactory titanFactory;
    [SerializeField] private EnemyFactory enemyFactory;
    private int archerCost = 100;
    private int titanCost = 500;
    private int warriorCost = 50;

    private void Start() => StartCoroutine(EnemySpawn());

    public void ArcherButton()
    {
        if (Player.instance.CoinsQuantity < archerCost)
            return;

        Player.instance.CoinsQuantity -= archerCost;
        var prefab = archerFactory.GetNewInstance();
    }

    public void WarriorButton()
    {
        if (Player.instance.CoinsQuantity < warriorCost)
            return;

        Player.instance.CoinsQuantity -= warriorCost;
        var prefab = warriorFactory.GetNewInstance();
    }

    public void TitanButton()
    {
        if (Player.instance.CoinsQuantity < titanCost)
            return;

        Player.instance.CoinsQuantity -= titanCost;
        var prefab = titanFactory.GetNewInstance();
    }

    public void EnemyButton()
    {
        var prefab = enemyFactory.GetNewInstance();
    }

    IEnumerator EnemySpawn()
    {
        for (;;)
        {
            EnemyButton();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
