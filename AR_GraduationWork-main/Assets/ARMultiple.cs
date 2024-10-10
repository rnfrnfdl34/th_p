using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;


public class ARMultiple : MonoBehaviour
{   

    [SerializeField]
    ARRaycastManager arRaycastManager;

    [SerializeField]
    Camera arCamera;

    GameObject selectedPrefab;
    ARObject selectedObject;

    private static List<ARRaycastHit> arHits = new List<ARRaycastHit>();
    private static RaycastHit physicsHit;

    public void SetSelectedPrefab(GameObject selectedPrefab) {
        this.selectedPrefab = selectedPrefab;
    }

    private void Awake() {
        selectedPrefab = arRaycastManager.raycastPrefab;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.touchCount == 0) 
            return;

        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;

        if (IsPointOverUIObject(touchPosition)) 
            return;

        if (touch.phase == TouchPhase.Began) {
            if(!SelectARObject(touchPosition)) {
                SelectARPlane(touchPosition);
            }
        }
        else if (touch.phase == TouchPhase.Ended) {
            if(selectedObject) {
                selectedObject.Selected = false;
            }
        }
        
    }
    private bool SelectARObject(Vector2 touchPosition) {
        Ray ray = arCamera.ScreenPointToRay(touchPosition);
            if(Physics.Raycast(ray, out physicsHit))
            {
                selectedObject = physicsHit.transform.GetComponent<ARObject>();
                if(selectedObject) {
                    selectedObject.Selected = true;
                    return true;
                }
            }
            return false;
    }
    private void SelectARPlane(Vector2 touchPosition) {
        if(arRaycastManager.Raycast(touchPosition, arHits, TrackableType.PlaneWithinPolygon)) {
            Pose hitpose = arHits[0].pose;
            var newARObj = Instantiate(selectedPrefab, hitpose.position, hitpose.rotation);
            newARObj.AddComponent<ARObject>();
        }
    }
    bool IsPointOverUIObject(Vector2 pos) {
        PointerEventData eventDataCurPosition = new PointerEventData(EventSystem.current);
        eventDataCurPosition.position = pos;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurPosition, results);
        return results.Count > 0;
    }
}
