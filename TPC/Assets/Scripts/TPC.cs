using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We want to implement third-persn camera that is not associated
// with monobehavior. Instead we allow pure C# classes to create
// the third-person camera behavior.
// We also do not want the TPC class to know how to implement the math and phyics
// of the different types of cameras.
abstract public class TPC
{
  // what do we need to make the third-person camera.
  // 1. The camera itself
  // 2. The target.
  protected Transform mCamera;
  protected Transform mPlayer;

  // let's have a constructor.
  public TPC(Transform camera, Transform player)
  {
    mCamera = camera;
    mPlayer = player;
  }

  // Since I (TPC) do not know how to implement the math for the 
  // camera, I will allow all classes derived from me
  // to implement the real behavior.
  public abstract void Calculate();
}

public class TPCTrack : TPC
{
  public TPCTrack(Transform camera, Transform player)
    : base(camera, player)
  {
  }

  public override void Calculate()
  {
    // Get the target position.
    Vector3 targetPos = mPlayer.position;

    // The camera does not want to track the foot of the player,
    // instead we track the head of the player.
    targetPos.y += 2.0f;

    // make the camera look at the target pos.
    mCamera.LookAt(targetPos);

  }
}
