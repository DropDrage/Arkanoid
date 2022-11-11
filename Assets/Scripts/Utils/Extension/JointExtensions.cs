using UnityEngine;

namespace Utils
{
    public static class JointExtensions
    {
        public static void BreakJoint(this Joint2D joint) => joint.breakForce = 0;
    }
}
