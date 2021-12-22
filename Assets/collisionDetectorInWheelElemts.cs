using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetectorInWheelElemts : MonoBehaviour
{
    int count;
    // Start is called before the first frame update

  
        void Start()
        {
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            Mesh mesh = GetComponent<MeshFilter>().mesh;

            mesh.Clear();

            // make changes to the Mesh by creating arrays which contain the new values
            mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
            mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
            mesh.triangles = new int[] { 0, 1, 2 };
        }
    
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
