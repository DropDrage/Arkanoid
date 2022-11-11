using UnityEngine;

namespace Utils
{
    public static class VectorExtensions
    {
        public static Vector3 Add(this Vector3 vector, in Vector2 other)
        {
            vector.x += other.x;
            vector.y += other.y;

            return vector;
        }
    }
}
