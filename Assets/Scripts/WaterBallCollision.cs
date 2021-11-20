using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallCollision : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionVertical;
    public GameObject explosionHorizontal;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Explosion"))
        {
            SpawnExplosion();
        }
    }



    public void SpawnExplosion()
    {
        this.gameObject.SetActive(false);
        var positionX = this.transform.position.x;
        var positionY = this.transform.position.y;
        var middleExplosionObj = Instantiate(explosion, this.transform.position, this.transform.rotation);
        for (int i = 0; i < PutBoomSpawn.VerticalLength; i++)
        {
            positionX += 0.5f;
            var newPostion = new Vector2(positionX, this.transform.position.y);
            var explosionObj = Instantiate(explosionHorizontal, newPostion, this.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        positionX = this.transform.position.x;
        for (int i = 0; i < PutBoomSpawn.VerticalLength; i++)
        {
            positionX -= 0.5f;
            var newPostion = new Vector2(positionX, this.transform.position.y);
            var explosionObj = Instantiate(explosionHorizontal, newPostion, this.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }

        for (int i = 0; i < PutBoomSpawn.HorizontalLength; i++)
        {
            positionY += 0.5f;
            var newPostion = new Vector2(this.transform.position.x, positionY);
            var explosionObj = Instantiate(explosionVertical, newPostion, this.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        positionY = this.transform.position.y;
        for (int i = 0; i < PutBoomSpawn.HorizontalLength; i++)
        {
            positionY -= 0.5f;
            var newPostion = new Vector2(this.transform.position.x, positionY);
            var explosionObj = Instantiate(explosionVertical, newPostion, this.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        Destroy(middleExplosionObj, 0.3f);
    }

}
