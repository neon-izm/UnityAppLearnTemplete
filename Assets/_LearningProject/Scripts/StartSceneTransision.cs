using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;

public class StartSceneTransision : MonoBehaviour
{
    [SerializeField]
    PageContainer _startPageContainer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _startPageContainer.Push("LoadingScreen", false,
            onLoad: x =>
            {
                var page = x.page;
                Debug.Log("LoadingScreen Loaded");
            });

        yield return new WaitForSeconds(5);
        _startPageContainer.Push("StartupMain", false,
            onLoad: x =>
            {
                var page = x.page;
                Debug.Log("Main Loaded");
            });
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
