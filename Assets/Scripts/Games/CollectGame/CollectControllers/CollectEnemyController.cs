
using UnityEngine;
using UnityEngine.AI;

public class CollectEnemyController : EnemyController
{
    public AudioClip hurtSound;

    //private components
    Transform player;
    NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (PlayerController.GetPlayerStatus() != PlayerStatus.DEAD)
            nav.SetDestination(player.position);
        else
            nav.enabled = false;
    }
}
