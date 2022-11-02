using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
  // PlayeeMovement willneed access to the animator and
  // the character controller.
  [SerializeField]
  CharacterController mCharacterController;
  [SerializeField]
  Animator mAnimator;

  [SerializeField]
  float mWalkSpeed = 1.5f;

  [SerializeField]
  float mRotationSpeed = 20.0f;

  void Start()
  {
    //mCharacterController = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    // we cant move the player if there is no CharacterController
    if (mCharacterController == null) return;

    // We cant show animations if there is no animator.
    if (mAnimator == null) return;

    // get input from the controller or from the keyboard (W, A, S, D)
    float hInput = Input.GetAxis("Horizontal");
    float vInput = Input.GetAxis("Vertical");

    float speed = mWalkSpeed;

    if(Input.GetKey(KeyCode.LeftShift))
    {
      speed = 2.0f * mWalkSpeed;
    }

    // rotate player.
    transform.Rotate(0.0f, hInput * mRotationSpeed * Time.deltaTime, 0.0f);

    Vector3 forward = transform.forward;
    mCharacterController.Move(forward * speed * vInput * Time.deltaTime);

    // now we apply the animations.
    mAnimator.SetFloat("PosX", 0.0f);
    mAnimator.SetFloat("PosZ", speed * vInput / (2.0f * mWalkSpeed));
  }
}
