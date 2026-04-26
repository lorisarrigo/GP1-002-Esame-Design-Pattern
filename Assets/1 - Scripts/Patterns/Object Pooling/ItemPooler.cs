using System.Collections.Generic;
using UnityEngine;
public class ItemPooler : MonoBehaviour
{
    //The Pooler, Spawn the Selected item, if it isn't already spwned creates it, else respawns it in a certain position and rotation

    //Gets the bullet Prefab and create a List for it
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] List<GameObject> pool_BulletPrefab = new ();

    //Counters used to store how many Bullets had spawned
    int instancedCount, pooledCount;

    //used by the EnemyBehavior to get the position and rotation of the spawner then pass it to the Spawner function
    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        return SpawnItemFromPool(bulletPrefab, pool_BulletPrefab, position, rotation);
    }
    //the Spawner function that gets the Prefab to spawn, the list to store it, the position and the rotation to spawn it
    private GameObject SpawnItemFromPool(GameObject objPrefab, List<GameObject> pool, Vector3 position, Quaternion rotation)
    {
        //this cicle is used only if there are object, of the List that are deactivate, in the hierarchy
        for (int i = 0; i < pool.Count; i++)
        {
            //if there are, then reactive the object in the starting position
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.SetPositionAndRotation(position, rotation);
                pool[i].SetActive(true);
                pooledCount++;
                return pool[i];
            }
        }
        //if the for cicle isn't started, instantiate the bullet and Add it to the List
        GameObject instancedObj = Instantiate(objPrefab, position, rotation, transform);
        pool.Add(instancedObj);
        instancedCount++;
        return instancedObj;
    }
}
