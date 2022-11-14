using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
  [SerializeField]
  Transform mPlayer;

  TPC mTpc;

  // Start is called before the first frame update
  void Start()
  {
    mTpc = new TPCTrack(transform, mPlayer);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void LateUpdate()
  {
    mTpc.Calculate();
  }
}
