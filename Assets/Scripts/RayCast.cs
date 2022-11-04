/*
using System.Collections;

using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using TMPro;

public class RayCast : MonoBehaviour
{
    public TMP_Text posText;
    //public TMP_Text objectHit;
    public GameObject sphereMarker;
    GameObject rayObject;

    // Start is called before the first frame update

    // next attempt: remove start
    
    
    void Start()
    {
        rayObject = Instantiate(sphereMarker, this.transform);
    }
    

    // Update is called once per frame
    void Update()
    {
        foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
            // Ignore anything that is not a hand because we want articulated hands
            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }
                    if (p.Result != null)
                    {
                        //var startPoint = p.Position;
                        var endPoint = p.Result.Details.Point;
                        var hitObject = p.Result.Details.Object;
                        if (hitObject)
                        {
                            /*
                            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            sphere.transform.localScale = Vector3.one * 0.01f;
                            sphere.transform.position = endPoint;
                            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            if (p.Result.PreviousPointerTarget != sphere)
                            {
                                sphere.transform.localScale = Vector3.one * 0.01f;
                                sphere.transform.position = endPoint;
                            }
                            
                            rayObject.transform.position = endPoint;

                        }
                        posText.text = endPoint.ToString("F3");
                        //objectHit.text = hitObject.ToString();
                    }

                }
            }
        }
    }
}
*/
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

using TMPro;

public class RayCast : MonoBehaviour
{
    public GameObject sphereMarker;
    GameObject rayObject;
    
    // private Vector3 endPoint;

    public TMP_Text posText;

    // Start is called before the first frame update
    void Start()
    {
        rayObject = Instantiate(sphereMarker, this.transform);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
            // Ignore anything that is not a hand because we want articulated hands
            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }

                    if (p.Result != null)
                    {
                        var endPoint = p.Result.Details.Point;

                        if (p.Result.Details.Object)
                        {
                            rayObject.GetComponent<Renderer>().enabled = true;
                            rayObject.transform.position = endPoint;

                            //var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            //sphere.transform.localScale = Vector3.one * 0.01f;
                            //sphere.transform.position = endPoint;


                        }

                        posText.text = endPoint.ToString("F3");
                        
                        
                    }

                }
            }
        }

    }
    

}
*/

using System.Collections;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

using TMPro;

public class RayCast : MonoBehaviour
{
    public GameObject sphereMarker;
    GameObject rayObject;
    private Vector3 endPoint;
    public TMP_Text posText;

    // Start is called before the first frame update
    void Start()
    {
        rayObject = Instantiate(sphereMarker, this.transform);
    }

   // Update is called once per frame
    void Update()
    {
        rayObject.GetComponent<Renderer>().enabled = false;

        if(PointerUtils.TryGetHandRayEndPoint(Handedness.Right, out endPoint));
        {
            rayObject.GetComponent<Renderer>().enabled = true;
            rayObject.transform.position = endPoint;
        }

        posText.text = endPoint.ToString("F3");

    }




}