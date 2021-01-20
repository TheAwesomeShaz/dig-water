using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFiller : MonoBehaviour
{
    SkinnedMeshRenderer water;
    
    public static BucketFiller instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        water = GetComponent<SkinnedMeshRenderer>();
        //Setting Weight to zero
        water.SetBlendShapeWeight(0, 0);
        water.SetBlendShapeWeight(1, 0);
        water.enabled = false;
    }

    public void FillWater(int weight)
    {
        water.enabled = true;
        water.SetBlendShapeWeight(0,weight);
        water.SetBlendShapeWeight(1, weight);
    }

    public void FillWaterShape2(int weight)
    {
        water.enabled = true;

        water.SetBlendShapeWeight(0, 0);
        water.SetBlendShapeWeight(1, weight);
        //if (weight < 30)
        //{
        //    water.SetBlendShapeWeight(0,weight+20);
        //}
        //else
        //{
        //    water.SetBlendShapeWeight(0, weight);
        //}
    }
    public void FillWaterShape3(int weight)
    {
        water.enabled = true;

        var reverseWeight = 100 - weight;
        if(reverseWeight < 0)
        {
            reverseWeight = 0;
        }

        water.SetBlendShapeWeight(1, weight);
        water.SetBlendShapeWeight(0, reverseWeight);
        if(weight >= 100)
        {
            water.SetBlendShapeWeight(0, 0);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
