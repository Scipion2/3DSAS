using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    [SerializeField] private Tile[] TilesType;
    [SerializeField] private int XMax,XMin,ZMax,ZMin;

    public void Start()
    {

        SpawnMap(XMin,XMax,ZMin,ZMax,TilesType[0].GetPrefab());

    }

    public GameObject[,] SpawnMap(int MinX, int MaxX, int MinZ, int MaxZ, GameObject TilePrefab)
    {

        GameObject[,] Map=new GameObject[MaxX,MaxZ];

        for(int x=MinX;x<MaxX;++x)
        {

            for(int z=MinZ;z<MaxZ;++z)
            {

                GameObject spawnedTile=Instantiate(TilePrefab, new Vector3(x,0,z),Quaternion.identity);
                spawnedTile.name="x:"+x+" z:"+z;
                spawnedTile.transform.SetParent(this.transform);
                //Map[x,z]=spawnedTile;

            }

        }

        return Map;

    }

}
