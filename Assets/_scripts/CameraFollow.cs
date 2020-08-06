using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform player;
  public Vector3 offset;
  public float followSpeed;

 
  void Update ()
  {
      Vector3 target = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);
      Vector3 currentPos = Vector3.Lerp(transform.position, target, followSpeed);
      this.transform.position = currentPos;
  }
}
