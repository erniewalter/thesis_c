using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using TMPro;
using System.Collections;

public class demoScript : MonoBehaviour
{
    public TMP_Text posText;
    public TMP_Text objectHit;

    // Update is called once per frame
    void Update()
    {
        foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
            // Ignore anything that is not a hand because we want articulated hands
            
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }
                    if (p.Result != null)
                    {
                    if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
                    {

                        var endPoint = p.Result.Details.Point;
                        var hitObject = p.Result.Details.Object;
                       
                        posText.text = endPoint.ToString("F4");
                        objectHit.text = hitObject.ToString();

                    }

                    }

                }
            }
        }
    }