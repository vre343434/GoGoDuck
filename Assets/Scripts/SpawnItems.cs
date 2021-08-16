using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    //[SerializeField] [Range(4f, 17f)] float spawnRangeX;
    //[SerializeField] [Range(0f, 5f)] float spawnRangeY;
    [SerializeField] bool looping = false;
    [SerializeField] int waitSecond;
    [SerializeField] GameObject prefab;
    [SerializeField] Items[] items;


    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(Spawn());
        }
        while (looping);
    }

    private IEnumerator Spawn()
    {        
        var pos = new Vector2(Random.Range(4f, 17f), Random.Range(0f, 5f));
        GameObject newItem = Instantiate(prefab, pos, Quaternion.identity);

        var randomItem = Random.Range(0, items.Length);
        newItem.gameObject.tag = items[randomItem].GetItemNumber().ToString();
        newItem.GetComponent<SpriteRenderer>().sprite = items[randomItem].GetItemImage();

        yield return new WaitForSeconds(waitSecond);
    }

}
