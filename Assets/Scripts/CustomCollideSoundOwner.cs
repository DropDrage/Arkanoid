using JetBrains.Annotations;
using UnityEngine;

[DisallowMultipleComponent]
public class CustomCollideSoundOwner : MonoBehaviour
{
    [field: SerializeField]
    public AudioClip CollideSound { get; [UsedImplicitly] private set; }
}
