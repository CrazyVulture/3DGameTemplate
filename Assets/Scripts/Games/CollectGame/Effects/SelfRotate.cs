using UnityEngine;

public enum RotateAxis
{
    X_AXIS = 0,
    Y_AXIS,
    Z_AXIS
}

public class SelfRotate : MonoBehaviour
{
    public bool isRandom;
    public float tumble;

    public RotateAxis rotateAxis;
    public float rotateSpeed;

    void Start()
    {
        if (isRandom)
        {
            var rigidBody = GetComponent<Rigidbody>();
            if (rigidBody)
                rigidBody.angularVelocity = Random.insideUnitSphere * rotateSpeed;
        }
    }

    void Update()
    {
        if (!isRandom)
        {
            switch (rotateAxis)
            {
                case RotateAxis.X_AXIS:
                    transform.Rotate(new Vector3(rotateSpeed, 0, 0) * Time.deltaTime);
                    break;
                case RotateAxis.Y_AXIS:
                    transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                    break;
                case RotateAxis.Z_AXIS:
                    transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
                    break;
            }
        }
    }
}
