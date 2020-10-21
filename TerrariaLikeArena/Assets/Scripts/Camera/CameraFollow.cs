using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject objectToTrack;
    // Update is called once per frame
    void Update()
    {
        if (objectToTrack != null)
        {
            Vector3 objPos = objectToTrack.transform.position;
            transform.position = new Vector3(objPos.x,objPos.y, -1f);
        }
    }
}
