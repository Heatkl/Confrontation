using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool isEnemy = true;

    private void Start()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();
        if (enemy == null) 
            isEnemy = false;
    }
   


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");

        if (!enabled)
            return;


        var health = other.GetComponent<Health>();
        if (health == null)
            return;

        if((isEnemy && other.CompareTag("Player")) || (!isEnemy && other.CompareTag("Enemy")))
        health.DecreaseHealth(damage);

    }

}