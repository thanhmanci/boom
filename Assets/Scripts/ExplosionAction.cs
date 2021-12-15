using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAction : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.name.Contains("Explosion") && !col.gameObject.name.Contains("bazzi"))
        {
            var putBoomSpawnInstance = FindObjectOfType<PutBoomSpawn>();
            //print(col.gameObject.name);
            if (gameObject.name.Contains("ExplosionVertical"))
            {
            }
            //if (gameObject.name.Contains("ExplosionHorizontal"))
            //{
            //    putBoomSpawnInstance.SetHorizontalStop(true);
            //}
        }
    }
}
