
using UnityEngine;

public class AsteroidController : BaseController
{
    public GameObject explosion;
    public AudioClip destroySound;

    void Start()
    {
        Init();
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Player")
        {
            EventMgr.Instance.PlayerDead();
            return;
        }
        SoundMgr.Instance.PlaySound(destroySound);
        Instantiate(explosion, transform.position, transform.rotation);
        UIMgr.Instance.AddScore(10);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
