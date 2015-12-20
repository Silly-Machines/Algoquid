using UnityEngine;

public interface ILevelElement {

	// Element parameters
	string name { get; set; }
	GameObject model { get; set; }

	// Booleans
	bool interactable { get; set; }
	bool pickable { get; set; }
	bool breakable { get; set; }
	bool climbable { get; set; }

	// Element fonctions
	void OnPickup();
	void OnDrop();
	void OnInteract();
	void OnBreak();
	void OnClimb();
}
