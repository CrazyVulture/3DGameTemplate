using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private int count;

    public AudioClip collect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UIMgr.Instance.SetCountText(count);
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            ++count;
            UIMgr.Instance.SetCountText(count);
            if (count >= 12)
                EventMgr.Instance.Win();
        }
    }
}
