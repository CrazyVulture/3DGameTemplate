using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tiledSizeZ;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed,tiledSizeZ);
        transform.position = startPos + Vector3.forward * newPos;
    }
}
