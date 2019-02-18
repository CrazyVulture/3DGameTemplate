
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip destroySound;
    public EnemyController enemyController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            return;
        if (!other.CompareTag("Player"))
            Destroy(other.gameObject);
        SoundMgr.Instance.PlaySound(destroySound);
        Instantiate(explosion, transform.position, transform.rotation);
        enemyController.Death();
    }
}
