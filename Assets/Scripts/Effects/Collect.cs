using UnityEngine;

public class Collect : MonoBehaviour
{
    public AudioClip collect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            UIMgr.Instance.AddScore(100);
            if (UIMgr.Instance.score >= 1200)
                EventMgr.Instance.WinGame();
        }
    }
}
