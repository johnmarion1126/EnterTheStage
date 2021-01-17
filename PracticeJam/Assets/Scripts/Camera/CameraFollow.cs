using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject playerObject;

    void Update()
    {
        if (playerObject.transform.position.x <= -60.4f) {
            transform.position = new Vector3 (-60.4f, 0, -10f);
        }

        else if (playerObject.transform.position.x >= 60.4f) {
            transform.position = new Vector3 (60.4f, 0, -10f);
        }

        else {
            transform.position = new Vector3 (playerObject.transform.position.x, 0, -10f);
        }
    }
}
