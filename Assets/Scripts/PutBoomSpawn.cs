using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PutBoomSpawn : MonoBehaviour
{
    private int maximumBoomItems = 1;
    public List<GameObject> listWaterBall;
    private List<GameObject> listWaterBallActive = new List<GameObject>();
    public GameObject waterBallPrefab;
    GameObject playerObj;
    public GameObject explosion;
    public GameObject explosionVertical;
    public GameObject explosionHorizontal;
    private static GameObject currentWaterBall;
    private const float NUMBER_SECONDS_BOOM_EXOLODES = 3.0f;

    public static int VerticalLength = 2;
    public static int HorizontalLength = 2;

    private List<string> postionSpawnBoom = new List<string>();
    public LayerMask levelMask;


    void Start()
    {
        playerObj = GameObject.Find("bazzi");
        listWaterBall = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            var waterBall = (GameObject)Instantiate(waterBallPrefab);
            waterBall.transform.parent = GameObject.Find("Tilemap").transform;
            waterBall.name = "waterBall #" + i;
            waterBall.SetActive(false);
            listWaterBall.Add(waterBall);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // InvokeRepeating("Spawn", speedSpawn, speedSpawn);
            if (listWaterBallActive.Count < maximumBoomItems)
            {
                SpawnBoom();
            }
        }
    }

    void SpawnBoom()
    {
        float xDirection = NearestQuarter(playerObj.transform.position.x);
        float yDirection = NearestQuarter(playerObj.transform.position.y - 0.3f);
        var heroPosition = new Vector2(xDirection, yDirection);
        var postionExist = postionSpawnBoom.FirstOrDefault(x => x == heroPosition.x + "_" + heroPosition.y);
        if (!string.IsNullOrEmpty(postionExist))
            return;
        foreach (var waterBall in listWaterBall)
        {
            if (!waterBall.activeInHierarchy)
            {
                waterBall.transform.position = new Vector2(heroPosition.x, heroPosition.y);
                waterBall.SetActive(true);
                //print(waterBall.transform.position);
                //if (Physics.Linecast(waterBall.transform.position, new Vector3(waterBall.transform.position.x, waterBall.transform.position.y + 0.5f, 0)))
                //{
                //    print("OKKOKOKOKK");
                //}
                listWaterBallActive.Add(waterBall);
                postionSpawnBoom.Add(waterBall.transform.position.x + "_" + waterBall.transform.position.y);
                currentWaterBall = waterBall;
                StartCoroutine("ExplosionWaterBall", waterBall);
                break;
            }
        }
    }

    static float NearestQuarter(float value)
    {
        var result = (float)Math.Round(value * 4, MidpointRounding.ToEven) / 4;

        if ((result / 0.5f) % 1 == 0)
        {
            result += 0.25f;
        }
        return result;

    }

    IEnumerator ExplosionWaterBall(GameObject waterBall)
    {
        yield return new WaitForSeconds(NUMBER_SECONDS_BOOM_EXOLODES);
        SpawnExplosion(waterBall);
    }



    public void SpawnExplosion(GameObject waterBall)
    {
        if (waterBall.activeSelf == false)
            return;
        currentWaterBall = null;
        waterBall.SetActive(false);
        listWaterBallActive.RemoveAt(0);
        var postionExist = postionSpawnBoom.FirstOrDefault(x => x == waterBall.transform.position.x + "_" + waterBall.transform.position.y);
        postionSpawnBoom.Remove(postionExist);
        var positionX = waterBall.transform.position.x;
        var positionY = waterBall.transform.position.y;
        var middleExplosionObj = Instantiate(explosion, waterBall.transform.position, waterBall.transform.rotation);
        middleExplosionObj.transform.parent = GameObject.Find("Tilemap").transform;
        for (int i = 0; i < HorizontalLength; i++)
        {
            positionX += 0.5f;
            var newPostion = new Vector2(positionX, waterBall.transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(newPostion, new Vector2(0, 0));
            if (hit.collider)
            {
                break;
            };
            var explosionObj = Instantiate(explosionHorizontal, newPostion, waterBall.transform.rotation);
            explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
            Destroy(explosionObj, 0.3f);
        }
        positionX = waterBall.transform.position.x;
        for (int i = 0; i < HorizontalLength; i++)
        {
            positionX -= 0.5f;
            var newPostion = new Vector2(positionX, waterBall.transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(newPostion, new Vector2(0, 0));
            if (hit.collider)
            {
                break;
            };
            var explosionObj = Instantiate(explosionHorizontal, newPostion, waterBall.transform.rotation);
            explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
            Destroy(explosionObj, 0.3f);
        }

        for (int i = 0; i < VerticalLength; i++)
        {
            positionY += 0.5f;
            var newPostion = new Vector2(waterBall.transform.position.x, positionY);
            RaycastHit2D hit = Physics2D.Raycast(newPostion, new Vector2(0, 0));
            if (hit.collider)
            {
                break;
            };
            var explosionObj = Instantiate(explosionVertical, newPostion, waterBall.transform.rotation);
            explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
            Destroy(explosionObj, 0.3f);
        }
        positionY = waterBall.transform.position.y;
        for (int i = 0; i < VerticalLength; i++)
        {
            positionY -= 0.5f;
            var newPostion = new Vector3(waterBall.transform.position.x, positionY, 0);
            RaycastHit2D hit = Physics2D.Raycast(newPostion, new Vector2(0, 0));
            if (hit.collider)
            {
                break;
            };
            var explosionObj = Instantiate(explosionVertical, newPostion, waterBall.transform.rotation);
            explosionObj.transform.parent = GameObject.Find("Tilemap").transform;
            Destroy(explosionObj, 0.3f);

        }
        Destroy(middleExplosionObj, 0.3f);
    }

    public static float GetDistanceHeroWithBoom(Vector2 heroPostion)
    {
        if (currentWaterBall)
        {
            return Vector2.Distance(heroPostion, currentWaterBall.transform.position);
        }
        return 0.0f;
    }

    public void UpBoomLength()
    {
        VerticalLength++;
        HorizontalLength++;
    }

    public void UpNumberBoomItem()
    {
        maximumBoomItems++;
    }

}
