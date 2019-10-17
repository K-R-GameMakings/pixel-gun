using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Controller : NetworkBehaviour {

	public GameObject mycamera;
    public GameObject myGun;
    public GameObject bullet;
    public float sensivity;

    private Vector2 ML;

    public Transform bulSpawn;

	void Update () {
		if (!isLocalPlayer){
			Destroy (mycamera.gameObject);
			return;
		}
        Vector2 CL = new Vector2(Input.GetAxisRaw("Mouse X") * sensivity, Input.GetAxisRaw("Mouse Y") * sensivity);
        
        ML += CL;

        ML.y = Mathf.Clamp(ML.y, -75, 80);

		
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 2.5f;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 2.5f;

        myGun.transform.localRotation = Quaternion.AngleAxis(-ML.y+90,Vector3.right);
        mycamera.transform.localRotation = Quaternion.AngleAxis(-ML.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(ML.x , transform.up);

		transform.Translate (x,0,z);

        if (Input.GetMouseButtonDown(0)) {
            CmdFire();
        }

	}

    [Command]
    void CmdFire() {
        GameObject Bullet = (GameObject)Instantiate(bullet, bulSpawn.position, bulSpawn.rotation);

        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 6.0f;

        NetworkServer.Spawn(Bullet);

        Destroy(Bullet,2);
    }

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer> ().material.color = Color.blue;


	}
}
