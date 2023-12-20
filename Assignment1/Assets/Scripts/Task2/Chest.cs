using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] public List<Item> itemList;

    

    // Start is called before the first frame update
    void Start()
    {
        float sum = 0;
        foreach(Item item in itemList)
        {
            sum += item.probability;
        }
        if(sum!=100)
        {
            
            Debug.LogError("Probability sum must be equal to 100");
        }
    }

    public void LootChest()
    {
        float random= Random.Range(0, 100);
        float probability = 0;
        foreach(Item item in itemList)
        {
            probability += item.probability;
            if(random<=probability)
            {
                Debug.Log(item.name);
                break;
            }
        }
    }
}
