using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("Bucket Colors")]
    Collider col;

    public bool isBucket = true;



    public bool isBlue;
    public bool isShape1;
    public bool isShape2;
    public bool isShape3;
    public GameObject waterStopper1;
    public GameObject waterStopper2;
    public GameObject waterStopper3;

    public bool destroyParticle = true;

    public GameController gc;
    //blue is RGBA(0.000, 0.485, 1.000, 0.900)
    public Color colorNeeded;
    //red is RGBA(1.000, 0.018, 0.000, 1.000)
    
    public bool isFull;
    public BucketFiller bucketWaterShapeKey;

    public GameObject successPS;
    public GameObject failPS;
    public Transform posPS;



    [Header("Weight of the shapeKey")]
    public int weight;


    private void Start()
    {
        if(waterStopper1 && waterStopper2 && waterStopper3)
        {
            waterStopper1.SetActive(false);
            waterStopper2.SetActive(false);
            waterStopper3.SetActive(false);
        }


        isFull = false;
        if (isBlue)
        {
        colorNeeded = new Color(0.000f, 0.485f, 1.000f, 1.000f);
        }
        if (!isBlue)
        {
            colorNeeded = new Color(1.000f, 0.018f, 0.000f, 1.000f);
        }
        

        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerShet(other);
    }


    public void TriggerShet(Collider2D other)
    {
        Color waterDropColor = other.GetComponent<SpriteRenderer>().color;

        bool waterDropColorSame = (int)waterDropColor.r * 1000 == (int)colorNeeded.r * 1000 &&
                                  (int)waterDropColor.g * 1000 == (int)colorNeeded.g * 1000 &&
                                  (int)waterDropColor.b * 1000 == (int)colorNeeded.b * 1000 &&
                                  (int)waterDropColor.a * 1000 == (int)colorNeeded.a * 1000;


        if (waterDropColorSame)
        {
            
            var particleFX = Instantiate(successPS, posPS.position, Quaternion.identity) as GameObject;
            Destroy(particleFX, 1f);
            IncreaseWater();
        }
        //Debug.Log("IsRed");
       
       else{
            var particleFX = Instantiate(failPS, posPS.position, Quaternion.identity) as GameObject;
            Destroy(particleFX, 1f);
            //particle effect black color
            Debug.Log("Wrong type of water");
        }

        
        Destroy(other.gameObject);
        


       
    }
   
    private void IncreaseWater()
    {
        
        if (weight < 100)
        {
            //increaseShapeKey

            weight++;
            bucketWaterShapeKey.FillWater(weight);
            

        }

        if(isShape1&& weight < 100)
        {
            weight += 10;
            bucketWaterShapeKey.FillWater(weight);

        }

        if (isShape2 && weight < 100)
        {
            weight++;
            bucketWaterShapeKey.FillWaterShape2(weight);
        }

        if (isShape3 && weight < 100)
        {
            weight+=2;
            bucketWaterShapeKey.FillWater(weight);
        }


        //if((isShape1 || isShape2 || isShape3 )&& weight == 100)
        //{
        //    destroyParticle = false;
        //}

        if (weight == 100)
        {
            isFull = true;
            if (isBucket)
            {

                if (isBlue)
                {
                    gc.SetBucketFull(1);
                }
                else
                {
                    gc.SetBucketFull(2);
                }
            }
            else if (!isBucket)
            {
                if (isShape1)
                {
                    gc.SetShapeFull(1);
                    waterStopper1.SetActive(true);
                }
                if (isShape2)
                {
                    gc.SetShapeFull(2);
                    waterStopper2.SetActive(true);
                }
                if (isShape3)
                {
                    gc.SetShapeFull(3);
                    waterStopper3.SetActive(true);
                }
            }
        }
    }

   
}

