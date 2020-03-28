using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Transform leader;
    public Transform NextFloor;
    public Transform PreviousFloor;
    public Transform CloseDoor;

    public float followSharpness = 0.1f;

    Vector3 _followOffsetInside;
    Vector3 _followOffsetOutside;




    public Image imgGaze;
    public elevControl elevControl;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    const float REFERENCE_FRAMERATE = 30f;

    public void changePosition(Transform transform)
    {
        Vector3 followSet = _followOffsetInside;

        if(transform.CompareTag("CloseDoorOutside"))
        {
            followSet = _followOffsetOutside;
        }
        Vector3 targetPosition = leader.position + followSet;

        targetPosition.x = transform.position.x;
        targetPosition.z = transform.position.z;


        //float timeRatio = Time.deltaTime * REFERENCE_FRAMERATE;

        transform.position += (targetPosition - transform.position) * followSharpness;

    }



    // Start is called before the first frame update
    void Start()
    {
        _followOffsetInside = NextFloor.position - leader.position;


    }

    private void FixedUpdate()
    {
        changePosition(NextFloor);
        changePosition(PreviousFloor);
        changePosition(CloseDoor);

    }

    // Update is called once per frame
    void Update()
    {


        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && gvrStatus && _hit.collider.name == "elevCallBtnPanel")
            {
                elevControl.CallElevator();
                gvrStatus = false;
            }

            if (imgGaze.fillAmount == 1 && gvrStatus && _hit.transform.CompareTag("CloseDoorInside") && gvrStatus)
            {
                elevControl.CallElevator();
                gvrStatus = false;
            }


            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CloseDoorOutside") && gvrStatus)
            {
                elevControl.CallElevator();
                gvrStatus = false;
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("NextFloor") && gvrStatus)
            {
                elevControl.NextFloor();
                Debug.Log("Elevator is called");
                gvrStatus = false;
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("PreviousFloor") && gvrStatus)
            {
                elevControl.PreviousFloor();
                Debug.Log("Elevator is called");
                gvrStatus = false;
            }


        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
