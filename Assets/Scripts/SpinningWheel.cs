
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Newtonsoft.Json;

public class SpinningWheel : Singleton<SpinningWheel>
{
    public float speedRotate;
    public bool spinBool,stopWheelBool,backwardSpinBool;
    public TMP_InputField inputValue;
    public GameObject MainWheel;
    string url;
    // Start is called before the first frame update
    void Start()
    {
         url = "https://admin.wheeloffortune.one/options/?distributor=new-milkyway";
        StartCoroutine(RestSupervisor.Instance.GetRequest(url, callback => {

            if (callback != null)
            {
                print("callback is:" + callback);
                InitialData initOb = JsonConvert.DeserializeObject<InitialData>(callback);
                for (int i = 0; i < initOb.results.Count; i++)
                {
                    int ChildIndexOfSelectedGameObject = 12 + i;
                    GameObject textGameObj = MainWheel.transform.GetChild(ChildIndexOfSelectedGameObject).gameObject;
                    textGameObj.GetComponent<TMP_Text>().text = initOb.results[i].option;
                }


            }
        }));
    }


    public void SpinWheelButtonClick()
    {
       

  
    }

    public void BackWardSpin()
    {
        backwardSpinBool = true;
        speedRotate = 50;
        StartCoroutine(spinWheelBackWard());
    }

    public IEnumerator spinWheelBackWard()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.33f);
            print("after 1 sec decrease 200");

            speedRotate = speedRotate - 2;
         
        }
    }

    public IEnumerator spinWheel()
    {
        for(int i = 0;i < 8;i++)
        {
            yield return new WaitForSeconds(1);
            print("after 1 sec decrease 200");

            speedRotate = speedRotate - 200;
        }

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            print("after 0.5 sec decrease 50");

            speedRotate = speedRotate - 50;
      
        }

    }



    float InputValueNumber;
    GameObject ObjectToLandPrize, ObjectToStartBackSpinFrom;
  public  string StartBackSpinObjectName, LandObjectName;
    // Update is called once per frame
    void Update()
    {
        if (spinBool)
        {
            this.gameObject.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);


            string colourInString = inputValue.GetComponent<TMP_InputField>().text;

           

         

            //decrease speed from here to match the above value  and add enable collider of wheel objectss
            /*            foreach(GameObject gm in Transform)
            */

            if (speedRotate == 50)
            {
                //putting collider on object to start to the object where to stop
                 ObjectToLandPrize = GameObject.Find("/Canvas/Panel/MainWheel/" + colourInString);
                ObjectToLandPrize.GetComponent<PolygonCollider2D>().enabled = true;
                GameObject parent = ObjectToLandPrize.transform.parent.gameObject;
                if (colourInString.Equals("blue"))//9 sibling index
                {
                    ObjectToStartBackSpinFrom = parent.transform.GetChild(0).gameObject;
                    ObjectToStartBackSpinFrom.GetComponent<PolygonCollider2D>().enabled = true;

                    StartBackSpinObjectName = ObjectToStartBackSpinFrom.name;
                    LandObjectName = ObjectToLandPrize.name;
                }
                else if (colourInString.Equals("violet"))//10 sibling index
                {
                    ObjectToStartBackSpinFrom = parent.transform.GetChild(1).gameObject;
                    ObjectToStartBackSpinFrom.GetComponent<PolygonCollider2D>().enabled = true;

                    StartBackSpinObjectName = ObjectToStartBackSpinFrom.name;
                    LandObjectName = ObjectToLandPrize.name;
                }
                else if (colourInString.Equals("darkviolet"))//11 sibling index
                {
                    ObjectToStartBackSpinFrom = parent.transform.GetChild(2).gameObject;
                    ObjectToStartBackSpinFrom.GetComponent<PolygonCollider2D>().enabled = true;

                    StartBackSpinObjectName = ObjectToStartBackSpinFrom.name;
                    LandObjectName = ObjectToLandPrize.name;
                }
                else
                {

                    //get parent of objectofcolliderstart to get objectofcollidertostop
                  
                    int getchildIndexOFldangingObject = ObjectToLandPrize.transform.GetSiblingIndex();
                    //get object to stop and add trigger
                    int childIndexOfStopObject = getchildIndexOFldangingObject + 3;


                    ObjectToStartBackSpinFrom = parent.transform.GetChild(childIndexOfStopObject).gameObject;
                    ObjectToStartBackSpinFrom.GetComponent<PolygonCollider2D>().enabled = true;

                    StartBackSpinObjectName = ObjectToStartBackSpinFrom.name;
                    LandObjectName = ObjectToLandPrize.name;
                }
            }


        }

        //for backward spin
        if (backwardSpinBool)
        {
            this.gameObject.transform.Rotate(Vector3.back * speedRotate * Time.deltaTime);

         

        }

    }



    public void Reset()
    {
        
    }
}   
