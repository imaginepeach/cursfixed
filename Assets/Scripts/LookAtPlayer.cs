using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(camera);
    }
}
