﻿using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float rotateSpeed=45;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }
}
