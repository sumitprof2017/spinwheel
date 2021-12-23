using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetectorInWheelElemts : MonoBehaviour
{
    int count;
    // Start is called before the first frame update

  
 //BackSpinStop
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collidedObjectname = collision.gameObject.name;


        count = count++;
        print("count is" + count);
        print("this gameobnject " + this.gameObject.name + "collided object" + collision.gameObject.name);
        if (this.gameObject.name.Equals(SpinningWheel.Instance.LandObjectName))
        {


            SpinningWheel.Instance.backwardSpinBool = false;
        }

    }
}
