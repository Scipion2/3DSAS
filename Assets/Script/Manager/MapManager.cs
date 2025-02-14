using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    [SerializeField] private Tile[] TilesType;

    public void Start()
    {

        SpawnMap(0,50,0,50,TilesType[0].GetPrefab());

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
                Map[x,z]=spawnedTile;

            }

        }

        return Map;

    }

}
