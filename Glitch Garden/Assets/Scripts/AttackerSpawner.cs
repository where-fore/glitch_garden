using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lizardPrefab = null;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;

    private bool spawning = true;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        while (spawning)
        {
            SpawnAttacker(lizardPrefab);

            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);
        }

    }

    private void SpawnAttacker(GameObject attackerPrefab)
    {
        Instantiate(attackerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
