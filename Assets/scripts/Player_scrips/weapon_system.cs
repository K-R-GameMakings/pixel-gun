using UnityEngine;
using System.Collections;

public class weapon_system : MonoBehaviour {
    public Gun[] loadOut;
    public Transform weapon_transform;
    private GameObject current_weapon;
    public GameObject bullet_hole;
    public LayerMask bul_layer;
    public int index;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Equip(1);
        }
        if(current_weapon != null && Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void Equip (int p_ind)
    {
        if (current_weapon != null)
        {
            Destroy(current_weapon);
        }
        GameObject t_newEquipment = Instantiate(loadOut[p_ind].prefab, weapon_transform.position, weapon_transform.rotation, weapon_transform) as GameObject;
        t_newEquipment.transform.localPosition = Vector3.zero;
        t_newEquipment.transform.localEulerAngles = Vector3.zero;

        current_weapon = t_newEquipment;
        index = p_ind;
    }
    void shoot()
    {
        Transform t_spawn = transform.Find("MyCamera");

        RaycastHit t_hit = new RaycastHit();
        if(Physics.Raycast(t_spawn.position,t_spawn.forward,out t_hit,loadOut[index].firerate,bul_layer))
        {
            GameObject t_newHole = Instantiate(bullet_hole, t_hit.point, Quaternion.FromToRotation(Vector3.forward, t_hit.normal)) as GameObject;

            Destroy(t_newHole, 5f);
        }
        
    }
}
