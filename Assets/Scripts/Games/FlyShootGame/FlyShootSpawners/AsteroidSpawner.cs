using UnityEngine;
using System.Collections;

public class AsteroidSpawner : BaseSpawner
{
    public float waveTime;
    float timeLeft;

    void Start()
    {
        timeLeft = waveTime;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            EventMgr.Instance.RestartGame();
    }

    void FixedUpdate()
    {
        if (timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
                timeLeft = 0;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (PlayerController.GetPlayerStatus()!=PlayerStatus.DEAD)
        {
            spawnPosition = new Vector3(
            Random.Range(-spawnValues.x, spawnValues.x),
            spawnValues.y,
            spawnValues.z);

            spawnRotation = Quaternion.identity;
            Instantiate(spawnObject, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnInterval);

            if (timeLeft==0)
            {
                yield return new WaitForSeconds(5.0f);
                timeLeft = waveTime;
            }
        }

        yield return new WaitForSeconds(2.0f);
        EventMgr.Instance.LoseGame();
        yield return new WaitForSeconds(2.0f);
        UIMgr.Instance.ShowText(TextType.RESTART);
    }
}
