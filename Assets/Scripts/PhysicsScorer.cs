using TMPro;
using UnityEngine;

//Structs are similar to classes without inheritance.
public struct JointData
{
    public Joint joint;
    public float previousForce;

    public JointData(Joint newJoint)
    {
        this.joint = newJoint;
        previousForce = 0f;
    }

}
public class PhysicsScorer : MonoBehaviour
{
    //Arrays dont auto populate, and resizing arrays require you to create a new array and copy details over
    //Which is very ineffective.
    JointData[] _jointData;

    public Transform ragdoll;

    public TMP_Text forceScore;
    public float score;

    private void Start()
    {
        //This grabs all thje joints in the ragdoll and stores them in an array. That way we populate the Array.
        Joint[] joints = ragdoll.GetComponentsInChildren<Joint>();
        //Create a new Array thats made up of the struct
        _jointData = new JointData[joints.Length];

        //Loop through each joint, and setup the struct with the data.
        for (int index = 0; index < _jointData.Length; index++)
        {
            Joint joint = joints[index];

            _jointData[index] = new JointData(joint);
        }
    }

    private void FixedUpdate()
    {
        //Every Fixed update, we loop through all our joints.
        for (int index = 0; index < _jointData.Length; index++)
        {

            JointData jointData = _jointData[index];
            float tempScore = Mathf.Abs(_jointData[index].previousForce - jointData.joint.currentForce.magnitude);

            if (tempScore >= 100)
            {
                score += tempScore;
            }
            jointData.previousForce = jointData.joint.currentForce.magnitude;

        }

                forceScore.text = score.ToString();
    }
}
