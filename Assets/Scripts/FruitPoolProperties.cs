using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPoolProperties : MonoBehaviour
{
    
    public Sprite[] mainFruitSprites;
    public int[] mainFruitPool;
    public List<int> cropFruitPool = new List<int>{}, unaddedFruit = new List<int>{};
    int fruitLeft = 0;
    WaitForSecondsRealtime addFruitDelay = new WaitForSecondsRealtime(10.0f);
    // private static FruitPoolProperties _instance;
    // public static FruitPoolProperties Instance
    // {
    //     get
    //     {
    //         if(_instance == null)
    //         {
    //             _instance = GameObject.FindObjectOfType<FruitPoolProperties>();
    //         }
    //         return _instance;
    //     }
    // }

    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        mainFruitSprites = new Sprite[]{
                                        Resources.Load<Sprite>("Apple_0"),
                                        Resources.Load<Sprite>("Bananas_0"),
                                        Resources.Load<Sprite>("Cherries_0"),
                                        Resources.Load<Sprite>("Kiwi_0"),
                                        Resources.Load<Sprite>("Melon_0"),
                                        Resources.Load<Sprite>("Orange_0"),
                                        Resources.Load<Sprite>("Pineapple_0"),
                                        Resources.Load<Sprite>("Strawberry_0")
                                        };
        
    }

    public void SetUp()
    {
        ResetLists();
        SetUpUnaddedFruit();
        AddToCropPool(2);
    }

    void ResetLists()
    {
        cropFruitPool.Clear();
        unaddedFruit.Clear();
    }

    // public void SetUpUnaddedFruit()
    void SetUpUnaddedFruit()
    {
        mainFruitPool = new int[mainFruitSprites.Length];
        for(int i = 0; i < mainFruitSprites.Length; i++)
        {    
            mainFruitPool[i] = i;
            unaddedFruit.Add(i);
        }
    }

    public IEnumerator AddFruitToPool()
    {
        while(fruitLeft !=0)
        {
            yield return addFruitDelay;
            AddToCropPool(1);
            fruitLeft--;
            // Debug.Log("Coroutine AddFruitToPool: Fruit Added to pool! Fruit unadded: "+ unaddedFruitLeft);
        }
        StopCoroutine("AddFruitToPool");
        yield return null;
    }

    // public void AddToCropPool(int amountToAdd)
    void AddToCropPool(int amountToAdd)
    {
        int randomIndex;
        for(int i = 0; i < amountToAdd; i++)
        {
            randomIndex = Random.Range(0, unaddedFruit.Count);
            cropFruitPool.Add(unaddedFruit[randomIndex]);
            unaddedFruit.RemoveAt(randomIndex);
        }
    }

}
