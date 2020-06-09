using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //Play Global
    private static DontDestroy instance = null;
    public static DontDestroy Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update () {
		if (SceneManager.GetActiveScene().name == "ElevatorLevel1" || SceneManager.GetActiveScene().name == "ElevatorLevel2" || 
        SceneManager.GetActiveScene().name == "ElevatorLevel3" || SceneManager.GetActiveScene().name == "Restroom")
         {
             Destroy(this.gameObject);
         }
	}
}

