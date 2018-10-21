using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos : MonoBehaviour {
	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position,1);
	}
}
