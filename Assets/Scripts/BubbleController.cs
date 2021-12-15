using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject explosionHorizontal;
    public GameObject explosionVertical;
    public GameObject explosionMiddle;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Explosion"))
        {
            var spriteRend = gameObject.GetComponent<SpriteRenderer>();
            spriteRend.sortingOrder = -1;
            var bubble = Instantiate(bubblePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(bubble, 0.5f);
            StartCoroutine("ExplosionWaterBall", gameObject);
        }
    }

    IEnumerator ExplosionWaterBall(GameObject bubble)
    {
        yield return new WaitForSeconds(0.5f);
        var pos = new Vector2(bubble.transform.position.x, bubble.transform.position.y);
        var explosionObj = Instantiate(explosionMiddle, pos, bubble.transform.rotation);
        explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        Destroy(explosionObj, 0.3f);

        pos = new Vector2(bubble.transform.position.x + 0.5f, bubble.transform.position.y);
        explosionObj = Instantiate(explosionHorizontal, pos, bubble.transform.rotation);
        explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        Destroy(explosionObj, 0.3f);

        pos = new Vector2(bubble.transform.position.x - 0.5f, bubble.transform.position.y);
        explosionObj = Instantiate(explosionHorizontal, pos, bubble.transform.rotation);
        explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        Destroy(explosionObj, 0.3f);

        pos = new Vector2(bubble.transform.position.x, bubble.transform.position.y + 0.5f);
        explosionObj = Instantiate(explosionVertical, pos, bubble.transform.rotation);
        explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        Destroy(explosionObj, 0.3f);

        pos = new Vector2(bubble.transform.position.x, bubble.transform.position.y - 0.5f);
        explosionObj = Instantiate(explosionVertical, pos, bubble.transform.rotation);
        explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        Destroy(explosionObj, 0.3f);
        Destroy(bubble);

    }
}
