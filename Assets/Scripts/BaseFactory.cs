using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    public T GetNewInstance()
    {
        Vector3 pos = new Vector3(Random.Range(-5f,5f), _prefab.transform.position.y, _prefab.transform.position.z);
        return Instantiate(_prefab, pos, Quaternion.identity);
    }
}
