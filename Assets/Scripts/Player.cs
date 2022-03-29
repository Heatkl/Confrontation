using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    private int coinsQuantity = 1000;
    [SerializeField] private Text text;
    private List<Transform> enemies = new List<Transform>();
    private List<Transform> army = new List<Transform>();
    //Вызов публичного метода: Player.instance.Method();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }

    private void Update()
    {
        text.text = coinsQuantity + "$";
    }

    public int CoinsQuantity
    {
        get { return coinsQuantity; }
        set { coinsQuantity = value; }
    }

    public Transform GetNearEnemy()
    {
        Transform nearestUnit = null;
        foreach (Transform i in enemies)
        {
            if (nearestUnit == null)
            {
                nearestUnit = i;
            }
            else if (i.position.z < nearestUnit.position.z)
            {
                nearestUnit = i;
            }
        }
        return nearestUnit;

    }

    public Transform GetNearArmy()
    {
        Transform nearestUnit = null;
        foreach (Transform i in army)
        {
            if (nearestUnit == null)
            {
                nearestUnit = i;
            }
            else if (i.position.z > nearestUnit.position.z)
            {
                nearestUnit = i;
            }
        }
        return nearestUnit;

    }

    public void AddEnemy(Transform _enemy)
    {
        enemies.Add(_enemy);
    }

    public void RemoveEnemy(Transform _enemy)
    {
        enemies.Remove(_enemy);
    }

    public void AddArmy(Transform _army)
    {
        army.Add(_army);
    }

    public void RemoveArmy(Transform _army)
    {
        army.Remove(_army);
    }

    public void ReloadScene()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);

    }
}
