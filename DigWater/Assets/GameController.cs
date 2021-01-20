using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Water2D;

public class GameController : MonoBehaviour
{
    //bool hasColorBlending;
    //bool hasBlue;
    //bool hasRed;
    public static GameController instance;

    [Tooltip("Stuff to set active when you win the level")]
    public List<GameObject> winStuff;

    [Tooltip("Stuff to set Inactive when you win the level")]
    public List<GameObject> deactivateStuff;

    [Header("Bucket Level Stuff")]
    public bool isBucketOneFull;
    public bool isBucketTwoFull;

    public GameObject blueWater;
    public GameObject redWater;
    public Transform terrain;

    public Collider2D blueWaterCollider;
    public Collider2D redWaterCollider;

    [Header("Shape Level Stuff")]
    public bool isShapeOneFull;
    public bool isShapeTwoFull;
    public bool isShapeThreeFull;
    [SerializeField] GameObject coloredShape;

    public bool bucketLevel;
    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (bucketLevel)
        {
        terrain.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        }

        if (!bucketLevel)
        {
            terrain.transform.rotation = Quaternion.Euler(5f, 0f, 0f);
        }

        instance = this;

        //redWater.SetActive(false);
        //blueWater.SetActive(false);

        isBucketOneFull = false;
        isBucketTwoFull = false;

        foreach (var item in winStuff)
        {
            item.SetActive(false);
        }

        if (!bucketLevel)
        {
            winStuff.Add(coloredShape);
        }
        //hasBlue = false;
        //hasRed = false;
    }

    public void SetShapeFull(int number)
    {
        switch (number)
        {
            case 1:
                isShapeOneFull = true;
                Debug.Log("Shape One " + isShapeOneFull);
                break;
            case 2:
                isShapeTwoFull = true;
                Debug.Log("Shape Two " + isShapeTwoFull);
                break;

            case 3:
                isShapeThreeFull = true;
                Debug.Log("Shape Three " + isShapeThreeFull);
                break;
        }

        if (isShapeOneFull && isShapeTwoFull && isShapeThreeFull)
        {
            LevelComplete();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void SetBucketFull(int number)
    {
        switch (number)
        {
            case 1:
                isBucketOneFull = true;
                winStuff[4].SetActive(true);
                break;
            case 2:
                isBucketTwoFull = true;
                winStuff[5].SetActive(true);
                break;
        }
        if (isBucketOneFull && isBucketTwoFull)
        {
            Debug.Log("Complete the level");
            LevelComplete();
        }
    }

    #region Color Mixing Stuff
    //public void SetColor(int colour)
    //{
    //    switch (colour)
    //    {
    //        case 1:
    //            hasBlue = true;
    //            Debug.Log("Blue Set to True");
    //            break;
    //        case 2:
    //            hasRed = true;
    //            Debug.Log("Red Set to True");
    //            break;
    //    }
    //    if(hasBlue && hasRed)
    //    {
    //        Debug.Log("YOU WIN");
    //        foreach (var item in winStuff)
    //        {
    //            item.SetActive(true);

    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    #endregion

    //public void SetWaterActive(int i)
    //{
    //    if (i == 1)
    //    {
    //        blueWater.SetActive(true);
    //    }
    //    else if (i == 2)
    //    {
    //        redWater.SetActive(true);
    //    }
    //}

    //public void CheckTypeOfWater(bool isBlue, Collider2D other,Color blue, Color red)
    //{
    //    if (isBlue && other.GetComponent<SpriteRenderer>().color == blue)
    //    {
    //        IncreaseWater();
    //    }
    //}

    public void LevelComplete()
    {
        if (bucketLevel)
        {
            Debug.Log("level complete called");
            foreach (var stuff in winStuff)
            {
                stuff.SetActive(true);
            }
        }
        if (!bucketLevel)
        {
            foreach (var stuff in winStuff)
            {
                stuff.SetActive(true);
            }

            foreach (var stuff in deactivateStuff)
            {
                stuff.SetActive(false);
            }
        }

        if (currentSceneIndex != 2) 
        { 
            StartCoroutine(LoadSceneAfterTime(currentSceneIndex+1));
        }
        else if(currentSceneIndex == 2)
        {
            StartCoroutine(LoadSceneAfterTime(0));
        }     
    }
    IEnumerator LoadSceneAfterTime(int index)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(index);
    }

}







