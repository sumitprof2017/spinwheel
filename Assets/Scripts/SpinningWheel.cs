
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Newtonsoft.Json;
using Random = UnityEngine.Random;

public class SpinningWheel : Singleton<SpinningWheel>
{
    public float speedRotate;
    public bool spinBool,stopWheelBool,backwardSpinBool;
    public TMP_InputField inputValue;
    public GameObject MainWheel,TextParentPanel,PolygonColliderGameObjectPanel;
    string url,prizeWinnerUrl;
    // Start is called before the first frame update
    void Start()
    {
         url = "https://admin.wheeloffortune.one/options/?distributor=new-milkyway";
        prizeWinnerUrl = "https://admin.wheeloffortune.one/fortune/?code=";
        //InitialHit
        StartCoroutine(RestSupervisor.Instance.GetRequest(url, callback => {

            if (callback != null)
            {
                print("callback is:" + callback);
                InitialData initOb = JsonConvert.DeserializeObject<InitialData>(callback);
                for (int i = 0; i < initOb.results.Count; i++)
                {
                    GameObject textGameObj = TextParentPanel.transform.GetChild(i).gameObject;
                    textGameObj.GetComponent<TMP_Text>().text = initOb.results[i].option;


                    //PolygonColliderGameObject name change
                     PolygonColliderGameObjectPanel.transform.GetChild(i).gameObject.name = initOb.results[i].option;


                }


            }
        }));
    }


    public void SpinWheelButtonClick()
    {//hit url to see what he wins first and after response if he's token is expired or not.
        string token = inputValue.GetComponent<TMP_InputField>().text;
        if (token.Equals(""))
        {

        }
        else
        {
            StartCoroutine(RestSupervisor.Instance.GetRequest(prizeWinnerUrl + token, callback => {

                if (callback != null)
                {
                    print("callback is:" + callback);
                    WinnerPrizeDecide winnerPrizeDecideObj = JsonConvert.DeserializeObject<WinnerPrizeDecide>(callback);
                    if (winnerPrizeDecideObj.prize.Equals("expired"))
                    {
                        print("Your token is expired");
                    }
                    else
                    {
                        WinnerGameObjectName = winnerPrizeDecideObj.prize;
                        spinBool = true;
                        speedRotate = 1800;
                        StartCoroutine(spinWheel());
                    }


                }
            }));

        }

       
        
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


    string WinnerGameObjectName;
    float InputValueNumber;
    GameObject ObjectToLandPrize, ObjectToStartBackSpinFrom;
  public  string StartBackSpinObjectName, LandObjectName;
    // Update is called once per frame
    void Update()
    {
        if (spinBool)
        {
            this.gameObject.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);


           
           

         

            //decrease speed from here to match the above value  and add enable collider of wheel objectss
            /*            foreach(GameObject gm in Transform)
            */

            if (speedRotate == 50)
            {
                //putting collider on object to start to the object where to stop
                 ObjectToLandPrize = GameObject.Find("/Canvas/Panel/MainWheel/PollygonGameObjectPanel/" + WinnerGameObjectName);
                ObjectToLandPrize.GetComponent<PolygonCollider2D>().enabled = true;
/*                GameObject parent = ObjectToLandPrize.transform.parent.gameObject;
*/

                int randomChildIndex = Random.Range(0, 12);
                //get parent of objectofcolliderstart to get objectofcollidertostop

              

                    ObjectToStartBackSpinFrom = PolygonColliderGameObjectPanel.transform.GetChild(randomChildIndex).gameObject;
                    ObjectToStartBackSpinFrom.GetComponent<PolygonCollider2D>().enabled = true;

                    StartBackSpinObjectName = ObjectToStartBackSpinFrom.name;
                    LandObjectName = ObjectToLandPrize.name;
                
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
