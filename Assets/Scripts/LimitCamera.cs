using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public GameObject followObject;

    private void LateUpdate()
    {
        transform.position = new Vector3(followObject.transform.position.x, 50, followObject.transform.position.z);
        transform.rotation = Quaternion.Euler(90, followObject.transform.rotation.eulerAngles.y, 0);
    }
}
