using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedMoster());
    }

    IEnumerator SpawnedMoster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length - 1);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(14, 24);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(14, 24);
            }
        }
    }
}
