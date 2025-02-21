using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    
    [SerializeField] private GameObject[] NPCPrefabs;
    [SerializeField] private Transform[] NPCSpawnPoints;
    [SerializeField] private List<GameObject> NPCS;
    [SerializeField] private Transform[] NPCTargets;
    [SerializeField] private int NPCCounter=0;

    public static NPCManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

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

            NPCS.Add(SpawnNPC(NPCPrefabs[Random.Range(0,NPCPrefabs.Length)]));
            Debug.Log("NPC Spawned");

        }

    }

    public Transform GetTarget()
    {

        return NPCTargets[0];

    }

    public void Respawn(NPCBehavior NPCToReset)
    {

        NPCToReset.transform.position=new Vector3(0,0,0);

    }



}
