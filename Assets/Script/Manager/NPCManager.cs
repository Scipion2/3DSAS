using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    
    [SerializeField] private GameObject[] NPCPrefabs;
    [SerializeField] private Transform[] NPCSpawnPoints;
   // [SerializeField] private list<GameObject> NPCS=new list<GameObject>();
    [SerializeField] private int NPCCounter=0;

    private GameObject SpawnNPC(GameObject NPCPrefab)
    {

        GameObject NewNPC=Instantiate(NPCPrefab,NPCSpawnPoints[Random.Range(0,NPCSpawnPoints.Length)]);
        NewNPC.transform.SetParent(this.transform);
        return NewNPC;

    }

    public void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

            SpawnNPC(NPCPrefabs[Random.Range(0,NPCPrefabs.Length)]);
            Debug.Log("NPC Spawned");

        }

    }



}
