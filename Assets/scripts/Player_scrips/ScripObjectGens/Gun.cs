using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject {
    public string name;
    public float firerate;
    public GameObject prefab;
	
}
