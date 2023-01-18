using System;
using UnityEngine;

public interface ICollisionComponent
{
    event Action<Collision> OnCollisionEntered;
    event Action<Collision> OnCollisionStaying;
    event Action<Collision> OnCollisionExited;
}
