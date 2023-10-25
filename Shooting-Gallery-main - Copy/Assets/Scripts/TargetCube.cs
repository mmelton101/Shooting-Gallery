using UnityEngine;

public class TargetCube : Target
{
    bool rotationOn = false;
    float rotationAmount = 360f;
    float currentRotationAmount = 0;

    Vector3 rotation;

    float time;

    // Update is called once per frame
    void Update()
    {
        //If currently rotating
        if (rotationOn)
        {
            //And current rotation is less than 360 degrees, continue rotating
            if(currentRotationAmount < rotationAmount)
            {
                time = Time.deltaTime;
                target.transform.Rotate(rotation * time);
                currentRotationAmount += rotationAmount * time;

            }
            //Finish rotation
            else
            {
                rotationOn = false;
                target.transform.rotation = Quaternion.Euler(0, 0, 0);


            }
        }
        else
        {

        }
        
    }


    void Rotate (float degrees)
    {
        // The target can only start a rotation if it is not currently rotating
        if (!rotationOn)
        {
            rotationOn = true;
            rotationAmount = degrees;
            currentRotationAmount = 0f;
            rotation = new Vector3(0, degrees, 0);

        }
    }

    public override void Process(RaycastHit hit)
    {
        //If the gameobject that hit is a target
        if(gameObject.tag == "Target")
        {
            Rotate(rotationAmount);
        }

        effectScript.Play(hit, hitSound, hitEffect, effectDuration);

    }
}
