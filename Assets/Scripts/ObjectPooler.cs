using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singelton
     void Awake()
    {
        int GameSessionCount = FindObjectsOfType<GameSession>().Length;
        if(GameSessionCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary; 

    [SerializeField] private float _offsetX, _offsetY; 
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(poolDictionary.ContainsKey(tag))
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            
            if(objectToSpawn == null)
            {
                return null; 
            }
            objectToSpawn.SetActive(true);

            
            Vector3 randomOffset = new Vector3(Random.Range(-1f*_offsetX, _offsetX), Random.Range(-1f*_offsetY, _offsetY));

            objectToSpawn.transform.position = position + randomOffset;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        else
        {
            Debug.LogWarning("Pool with tag: "+ tag + " doesn't exist");
            return null;
        }
    }
}
