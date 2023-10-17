using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;

    [SerializeField] float minYRateForUp = 1;
    [SerializeField] float maxYRateForUp = 3;
    [SerializeField] float minYRateForDown = 1;
    [SerializeField] float maxYRateForDown = 3;

    [SerializeField] float spawnMinRate = 1;
    [SerializeField] float spawnMaxRate = 3;

    void Start() 
    {
        StartCoroutine(StartSpawnPipe());
    }

    IEnumerator StartSpawnPipe()
    {
        while(true)
        {
            var pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
            if(Random.Range(0,2) == 0)
            {
                pipe.transform.rotation = new Quaternion(0,0,180,0);
                pipe.GetComponent<Pipe>().forMove = Vector2.right;
                Vector3 newPos = transform.position;
                newPos.y = Random.Range(minYRateForUp,maxYRateForUp);
                pipe.transform.position = newPos;
            }
            else
            {
                pipe.transform.rotation = new Quaternion(0,0,0,0);
                pipe.GetComponent<Pipe>().forMove = Vector2.left;
                Vector3 newPos = transform.position;
                newPos.y = Random.Range(minYRateForDown,maxYRateForDown);
                pipe.transform.position = newPos;
            }

            yield return new WaitForSeconds(Random.Range(spawnMinRate, spawnMaxRate + 0.1f));
        }
    }

}
