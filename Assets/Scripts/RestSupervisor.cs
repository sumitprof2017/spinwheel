using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestSupervisor : Singleton<RestSupervisor>
{
    // Start is called before the first frame update

    public IEnumerator GetRequest(string uri, System.Action<string> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("Error While Sending: " + www.error);
        }
        else
        {
/*            Debug.Log("Received: " + www.downloadHandler.text);
*/            callback(www.downloadHandler.text);
        }
    }

}
