using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpwanAddressables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            AsyncOperationHandle<GameObject> asyncOpHandle = 
                Addressables.LoadAssetAsync<GameObject>("Assets/Models/Pendantdant");

            asyncOpHandle.Completed += AsyncOpHandle_Completed;
        }
    }

    private void AsyncOpHandle_Completed(AsyncOperationHandle<GameObject> asyncOpHandle)
    {
        if(asyncOpHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOpHandle.Result);
        }

        else
        {
            Debug.Log("Failed to load the object!");
        }
    }
}
