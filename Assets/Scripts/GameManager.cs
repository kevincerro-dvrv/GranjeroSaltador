using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform barrierSpawnPoint;
    public GameObject barrierPrefab;

    private List<GameObject> availableBarriers;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        availableBarriers = new List<GameObject>();

        StartCoroutine(BarrierSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BarrierSpawner()
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            SpawnBarrier();
        }
    }

    public void RecycleBarrier(GameObject barrier)
    {
        barrier.SetActive(false);
        barrier.transform.position = barrierSpawnPoint.position;
        availableBarriers.Add(barrier);
    }

    public void SpawnBarrier()
    {
        if (availableBarriers.Count == 0) {
            Instantiate(barrierPrefab, barrierSpawnPoint.position, Quaternion.identity);
        } else {
            GameObject barrier = availableBarriers[0];
            availableBarriers.RemoveAt(0);
            barrier.SetActive(true);
        }
    }
}
