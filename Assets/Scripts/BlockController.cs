using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public float x = -4.25f;
    public float y = 3.25f;
    public GameObject pirate;
    public GameObject pillar;
    const int MaxLengthHorizontal = 15;
    const int MaxLengthVertical = 13;

    void Start()
    {


        string[,] gameBlockMap = new string[MaxLengthVertical, MaxLengthHorizontal] {
            { "pirate", "pirate", "pirate", "pirate", "", "", "", "pirate", "", "", "", "pirate", "pirate", "pirate", "pirate"},
            { "pirate", "pillar", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pillar", "pirate"},
            { "pirate", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "pirate"},
            { "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "", "pirate", "pirate", "", "", "", "pirate", "pirate", "", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "pirate", "pirate", "pirate", "", "", "", "pirate", "pirate", "pirate", "pirate", "", "pirate"},
            { "pirate", "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate", "pirate"},
            { "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate"},
            { "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate"},
            { "pirate", "pirate", "", "pirate", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pirate", "", "pirate", "pirate"},
            { "pirate", "pillar", "", "pirate", "pirate", "pirate", "", "", "", "pirate", "pirate", "pirate", "", "pillar", "pirate"},
            { "pirate", "", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "", "pirate"},
        };


        for (int i = 0; i < MaxLengthHorizontal; i++)
        {
            for (int j = 0; j < MaxLengthVertical; j++)
            {
                if (!string.IsNullOrEmpty(gameBlockMap[j, i]))
                {
                    var gameBlock = gameBlockMap[j, i] == "pirate" ? pirate : pillar;
                    var blockObj = Instantiate(gameBlock, new Vector3(x, y, 0), Quaternion.identity);
                    blockObj.name = "Block#" + x + "," + y;
                }
                y -= 0.5f;
                if (j == MaxLengthVertical - 1)
                {
                    y = 3.25f;
                }
            }
            x += 0.5f;
        }
    }

}
