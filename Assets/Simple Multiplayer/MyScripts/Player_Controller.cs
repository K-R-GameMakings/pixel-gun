using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Controller : NetworkBehaviour {

	public GameObject mycamera;
    public GameObject bullet;

    public Transform bulSpawn;

	void Update () {
		if (!isLocalPlayer){
			Destroy (mycamera.gameObject);
			return;
		}

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate (0,x,0);
		transform.Translate (0,0,z);

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
