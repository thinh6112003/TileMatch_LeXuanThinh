using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    private int numberInitSpawn = 10;
    private int numberDestroy = 50;
    private Dictionary<string, Stack<GameObject>> pool= new Dictionary<string, Stack<GameObject>>();
    private Dictionary<string, Transform> poolParent = new Dictionary<string, Transform>();

    public void InitPool(GameObject prefab,string name, Transform transformParent)
    {
        poolParent[name] = transformParent;
        pool[name] = new Stack<GameObject>();
        for(int i = 0;i < numberDestroy; i++)
        {
            GameObject newObject = Instantiate(prefab,transformParent);
            newObject.SetActive(false);
            pool[name].Push(newObject);
        }
    }
    public GameObject Spawn(string name)
    {
        GameObject newObject;
        if (pool[name].Count == 1) newObject = Instantiate(pool[name].Peek());
        else newObject = pool[name].Pop();
        newObject.SetActive(true);
        return newObject;
    }
    
    public void DeSpawn(GameObject gameObject,string name)
    {
        if(pool[name].Count>=numberDestroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.SetParent(poolParent[name]);
            gameObject.SetActive(false);
            pool[name].Push(gameObject);
        }
    }
    public void DeSpawn(GameObject gameObject, string name, float time)
    {
        StartCoroutine(delay(gameObject, name, time));
    }    
    public IEnumerator delay(GameObject gameObject, string name, float time)
    {
        yield return new WaitForSeconds(time);
        DeSpawn(gameObject, name);
    }
}
