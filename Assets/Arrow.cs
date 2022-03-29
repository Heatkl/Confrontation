using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float damage = 40f;
    private float speed = 10f;


    private void Start() => Destroy(gameObject, 3f);
    private void OnTriggerEnter(Collider other)
    {

        if (!enabled)
            return;


        var health = other.GetComponent<Health>();
        if (health == null)
            return;

        if (other.CompareTag("Enemy"))
        {
            health.DecreaseHealth(damage, true);
            Destroy(gameObject);
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
