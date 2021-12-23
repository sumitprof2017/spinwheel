using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollisionInArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int count;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This collider is in arrow object so collided object is from the list
        string collidedObjectname =  collision.gameObject.name;

       
        count = count+1;

        string startBackSpin = SpinningWheel.Instance.StartBackSpinObjectName;
        string landObjectNAme = SpinningWheel.Instance.LandObjectName;
        if (count > 1 && collidedObjectname.Equals(SpinningWheel.Instance.StartBackSpinObjectName))
        {
            SpinningWheel.Instance.spinBool = false;

            SpinningWheel.Instance.backwardSpinBool = true;

            count = 0;
        }




    }
}
