using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "Scriptable Objects/Tile")]
public class Tile : ScriptableObject
{

	[SerializeField] private float x,z;
	[SerializeField] private GameObject Prefab;

	public GameObject GetPrefab(){return Prefab;}// Getter For Prefab

}
