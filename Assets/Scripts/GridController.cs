using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

public class GridController : MonoBehaviour
{
    public Tilemap tileMap;
    public float x = 0;
    public float y = 0;
    const int MaxLengthHorizontal = 15;
    const int MaxLengthVertical = 13;
    public Tile mapPirateHorizontal;
    public Tile mapPirateVertical;

    void Start()
    {
        string[,] gameBlockMap = new string[MaxLengthVertical, MaxLengthHorizontal] {
            { "pirate", "pirate", "pirate", "pirate", "", "", "", "pirate", "", "", "", "pirate", "pirate", "pirate", "pirate"},
            { "pirate", "pillar", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pillar", "pirate"},
            { "pirate", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "pirate"},
            { "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate"},
            { "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate"},
            { "pirate", "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate", "pirate"},
            { "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "pirate", "pirate", "pirate"},
            { "pirate", "pirate", "pirate", "pirate", "", "pirate", "", "pirate", "", "pirate", "", "pirate", "pirate", "pirate", "pirate"},
            { "pirate", "pirate", "", "pirate", "pirate", "", "pirate", "pirate", "pirate", "", "pirate", "pirate", "", "pirate", "pirate"},
            { "pirate", "pillar", "", "pirate", "pirate", "pirate", "", "", "", "pirate", "pirate", "pirate", "", "pillar", "pirate"},
            { "pirate", "", "", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "pirate", "", "", "pirate"},
        };

        for (int i = -2; i < MaxLengthHorizontal; i++)
        {
            for (int j = -2; j < MaxLengthVertical; j++)
            {
                int RandomInt = UnityEngine.Random.Range(0, 1000);
                var tile = RandomInt % 2 == 0 ? mapPirateHorizontal : mapPirateVertical;
                tileMap.SetTile(new Vector3Int(i, j, 0), mapPirateHorizontal);
            }
        }

    }

}
