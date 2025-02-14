using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    //[SerializeField] private int MinX=0,MaxX=0,MinZ=0,MaxZ=0;
    //[SerializeField] private GameObject TilePrefab;

    public Tile[,] SpawnMap(int MinX, int MaxX, int MinZ, int MaxZ, Tile TilePrefab)
    {

        Tile[,] Map=new Tile[MaxX,MaxZ];

        for(int x=MinX;x<MaxX;++x)
        {

            for(int z=MinZ;z<MaxZ;++z)
            {

                Tile spawnedTile=Instantiate(TilePrefab, new Vector3(x,z),Quaternion.identity);
                spawnedTile.name="x:"+x+" z:"+z;
                Map[x,z]=spawnedTile;

            }

        }

        return Map;

    }

}
