using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public GameObject bubble;
    public GameObject fluid;
    public GameObject needle;
    public GameObject speedShoe;

    private const float RATE_SPAWN_ITEM = 0.95F;

    private List<GameObject> listObjectDestroy;

    void OnCollisionEnter2D(Collision2D col)
    {

        listObjectDestroy = new List<GameObject>();
        if (col.gameObject.name.Contains("Explosion"))
        {
            listObjectDestroy.Add(this.gameObject);
            StartCoroutine("SpawnItem");
            //Destroy(this.gameObject);
        }
    }


    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(0.1f);
        if (Random.value > RATE_SPAWN_ITEM)
        {
            Instantiate(needle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        }
        else if (Random.value > RATE_SPAWN_ITEM)
        {
            Instantiate(fluid, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        }
        else if (Random.value > RATE_SPAWN_ITEM)
        {
            Instantiate(bubble, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        }
        else if (Random.value > RATE_SPAWN_ITEM)
        {
            Instantiate(speedShoe, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        }
        gameObject.SetActive(false);
    }

}
