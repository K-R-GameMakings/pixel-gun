using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Billboard : NetworkBehaviour {

    public GameObject Vision;
	void Update () {
        if (isLocalPlayer) {
            return;
        }
        transform.LookAt(Vision.transform);
	}
}
