using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class ClientPooling : NetworkBehaviour
{
    public List<GameObject> ListOfGameObjects;
    public List<NetworkHash128> listOfNetworkHash128s;
    //public Dictionary<NetworkHash128, > DictionaryOfHash128;
    //public delegate GameObject SpawnDelegate(Vector3 position, NetworkHash128 assetId);
    //public delegate void UnSpawnDelegate(GameObject spawned);

    public NetworkHash128 _networkHash128;
    private void Start()
    {
        _networkHash128 = ListOfGameObjects[0].GetComponent<NetworkIdentity>().assetId;
        //getNetworkHash128();
        //Bullets
        ClientScene.RegisterSpawnHandler(_networkHash128, SpawnObject, DeSpawnObject);
    }
    /*
    private void getNetworkHash128()
    
    {
        for (int i = 0; i <= ListOfGameObjects.Count; i++)
        {
            print(ListOfGameObjects[i].GetComponent<NetworkIdentity>().assetId);
            listOfNetworkHash128s[i] = ListOfGameObjects[i].GetComponent<NetworkIdentity>().assetId;
        }
    }
    */
    public GameObject SpawnObject(Vector3 position, NetworkHash128 assetId)
    {
        //return Instantiate(ListOfGameObjects[0], position, Quaternion.identity);
        print("ClientPooling.SpawnObject was called");
        return SimplePool.SpawnGameObject(ListOfGameObjects[0], position, Quaternion.identity);
    }
    public void DeSpawnObject(GameObject spawned)
    {
        print("ClientPooling.DeSpawnObject was called");
        Debug.Log ("Re-pooling GameObject " + spawned.name);
        SimplePool.DespawnGameObject(spawned);
    }
}
