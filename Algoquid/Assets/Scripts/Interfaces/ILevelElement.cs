using UnityEngine;

public interface ILevelElement {

	// Element fonctions
	void OnPickup();
	void OnDrop();
	void OnInteract();
	void OnBreak();
	void OnClimb();
}
