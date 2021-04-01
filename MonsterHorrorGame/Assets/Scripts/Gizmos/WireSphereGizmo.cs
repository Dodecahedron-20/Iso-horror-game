using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
public class WireSphereGizmo : MonoBehaviour {

    public Color color = Color.red;
    public float radius = 1f;

	private void OnDrawGizmos() {
        Gizmos.color = this.color;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
#endif
