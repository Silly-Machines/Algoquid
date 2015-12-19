﻿public interface ILevelElement {
	// Element parameters
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