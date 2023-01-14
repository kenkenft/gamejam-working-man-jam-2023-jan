using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] MainFruitPool;
    public Sprite[] mainFruitSprites;
    List<int> cropFruitPool = new List<int>{}, unaddedFruit = new List<int>{};
    int randomIndex;
    void Start()
    {
        MainFruitPool = new int[mainFruitSprites.Length];
        for(int i = 0; i < mainFruitSprites.Length; i++)
        {    
            MainFruitPool[i] = i;
            unaddedFruit.Add(i);
        }
        
        //ToDo Select random amout fruit pool
        for(int i = 0; i < 2; i++)
        {
            randomIndex = Random.Range(0, unaddedFruit.Count);
            cropFruitPool.Add(unaddedFruit[randomIndex]);
            unaddedFruit.RemoveAt(randomIndex);
        }
        
        // foreach(int fruit in cropFruitPool)
        //     Debug.Log("FruitID: " + fruit);

    }

    
}
