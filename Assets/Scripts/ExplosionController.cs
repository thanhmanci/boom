using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public static int VerticalLength = 1;
    public static int HorizontalLength = 1;
    public static float positionX = 0f;
    public static float positionY = 0f;

    public static void SpawnExplosion(GameObject explosion, GameObject waterBall, GameObject explosionVertical, GameObject explosionHorizontal){
        positionX = waterBall.transform.position.x;
        positionY = waterBall.transform.position.y;
        var middleExplosionObj = Instantiate(explosion, waterBall.transform.position, waterBall.transform.rotation);
        for(int i = 0; i < VerticalLength; i ++){
            positionX += 0.5f;
            var newPostion = new Vector2(positionX, waterBall.transform.position.y);
            var explosionObj = Instantiate(explosionVertical, newPostion, waterBall.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        positionX = waterBall.transform.position.x;
        for(int i = 0; i < VerticalLength; i ++){
            positionX -= 0.5f;
            var newPostion = new Vector2(positionX, waterBall.transform.position.y);
            var explosionObj = Instantiate(explosionVertical, newPostion, waterBall.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        
        for(int i = 0; i < HorizontalLength; i ++){
            positionY += 0.5f;
            var newPostion = new Vector2(waterBall.transform.position.x, positionY);
            var explosionObj = Instantiate(explosionHorizontal, newPostion, waterBall.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        positionY = waterBall.transform.position.y;
        for(int i = 0; i < HorizontalLength; i ++){
            positionY -= 0.5f;
            var newPostion = new Vector2(waterBall.transform.position.x, positionY);
            var explosionObj = Instantiate(explosionHorizontal, newPostion, waterBall.transform.rotation);
            Destroy(explosionObj, 0.3f);
        }
        Destroy(middleExplosionObj, 0.3f);
    }
}
