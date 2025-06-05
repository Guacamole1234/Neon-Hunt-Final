using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool : MonoBehaviour
{
    Stack<GameObject> pool = new Stack<GameObject>();

    [SerializeField] GameObject prefabToInstantiate;
    [SerializeField] int poolSize;


    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tempElement = Instantiate(prefabToInstantiate, Vector3.zero, Quaternion.identity);
            tempElement.GetComponent<BulletBehaviour>().bulletPool = this;
            pool.Push(tempElement);
            tempElement.SetActive(false);
        }
    }

    public GameObject GetElementFromPool()
    {
        GameObject toReturn = null;
        if (pool.Count == 0)
        {
            toReturn = Instantiate(prefabToInstantiate, Vector3.zero, Quaternion.identity);
            toReturn.GetComponent<BulletBehaviour>().bulletPool = this;
            toReturn.SetActive(false);
        }
        else
        {
            toReturn = pool.Pop();
        }
        return toReturn;
    }

    public void ReturnToPool(GameObject element)
    {
        element.SetActive(false);
        pool.Push(element);
    }
}
