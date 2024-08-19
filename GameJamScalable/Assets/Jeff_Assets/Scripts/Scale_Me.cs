using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Scale_Me : MonoBehaviour
{
    private float ScaleHoiz;
    private float ScaleVert;
    private bool Horiz;
    private bool Vert;
    public float MaxHoriz;
    public float MaxVert;

    // Start is called before the first frame update
    void Start()
    {
        ScaleHoiz = 0.0f;
        ScaleVert = 0.0f;
    }

    public void OnScaleH()
    {
        if (!Vert)
        {
            Horiz = !Horiz;
        }
    }

    public void OnScaleV()
    {
        if (!Horiz)
        {
            Vert = !Vert;
        }   
    }

    private void FixedUpdate()
    {
        if (ScaleHoiz < MaxHoriz && Horiz)
        {
            ScaleHoiz = ScaleHoiz + 0.1f;
            PlayerMovement.isScaledH = true;
        }
        else if (ScaleHoiz > 0.0f && !Horiz)
        {
            ScaleHoiz = ScaleHoiz - 0.1f;
            PlayerMovement.isScaledH = false;
        }
        if (ScaleVert < MaxVert && Vert)
        {
            ScaleVert = ScaleVert + 0.1f;
            PlayerMovement.isScaledV = true;
        }
       else  if (ScaleVert > 0.0f && !Vert)
        {
            ScaleVert = ScaleVert - 0.1f;
            PlayerMovement.isScaledV = false;
        }
        transform.localScale = new Vector3(ScaleHoiz + 1.0f - ScaleVert / 2.0f, ScaleVert + 1.0f - ScaleHoiz/2.0f, ScaleHoiz + 1.0f - ScaleVert / 2.0f);
    }
    void UpdateScale()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ScalerH.inProgress
        //if (ScalerH.inProgress && !Vert)
        //{
        //    Horiz = !Horiz;
        //}
        //if(ScalerV.inProgress && !Horiz)
        //{
        //    Vert = !Vert;
        //}
        //transform.localScale = new Vector3(ScaleHoiz * 2.0f + 1.0f, ScaleHoiz * 2.0f + 1.0f, ScaleVert * 2.0f + 1.0f); 
    }
}
