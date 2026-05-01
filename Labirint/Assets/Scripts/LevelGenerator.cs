using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorAndPrefab[] spawnSetup;
    public float ofset = 5;
    private void GenerateTile(int x,int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if(pixelColor.a == 0)
        {
            return;
        }
        

        foreach (ColorAndPrefab colorSetup in spawnSetup)
        {
            if(colorSetup.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x * ofset, 0, z * ofset);
                Instantiate(colorSetup.prefab, position, Quaternion.identity,transform);
            }
        }
    }
    public void GenerateLevel()
    {
        
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }
    void Start()
    {
        
        GenerateLevel();
    }
}
