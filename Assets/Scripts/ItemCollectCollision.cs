using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("bazzi"))
        {
            var putBoomSpawnInstance = col.gameObject.GetComponent<PutBoomSpawn>();
            var bazziMovementInstance = col.gameObject.GetComponent<BazziMovement>();
            if (gameObject.name.Contains("bubble"))
            {
                putBoomSpawnInstance.UpNumberBoomItem();
            }
            if (gameObject.name.Contains("fluid"))
            {
                putBoomSpawnInstance.UpBoomLength();
            }
            if (gameObject.name.Contains("speed"))
            {
                bazziMovementInstance.UpSpeedHero();
            }
            Destroy(gameObject);
        }
    }

}
