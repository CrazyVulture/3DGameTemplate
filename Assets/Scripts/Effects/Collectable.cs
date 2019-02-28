using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip collect;
    public int scorePoints;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundMgr.Instance.PlaySound(collect);
            Destroy(gameObject);
            UIMgr.Instance.AddScore(scorePoints);
        }
    }
}
