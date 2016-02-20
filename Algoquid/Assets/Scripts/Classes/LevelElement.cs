using UnityEngine;
using System.Collections;

public class LevelElement : MonoBehaviour {

	//
	// Element parameters
	//
	public string element_name;
	public bool pickable;
	public bool droppable;
	public bool interactable;
	public bool breakable;
	public bool climbable;

	//
	// Element status
	//
	bool picked;
	bool dropped;
	bool interacted;
	bool breaked;
	bool climbed;

	public LevelElement() {
		picked = false;
		dropped = false;
		interacted = false;
		breaked = false;
		climbed = false;
	}

	void Update() {
		DoEvents ();
	}

	void OnMouseOver () {
		var info = "----- [" + name + "] -----\n";
		if (breakable)
			info += "Cassable\n";

		if (climbable)
			info += "Grimpable\n";

		if (interactable)
			info += "Interaction possible\n";

		if (pickable)
			info += "Ramassable";

		HUDHandler.showInfo (info);
	}
	
	void OnMouseExit () {
		HUDHandler.showInfo (null);
	}

	/// <summary>
	/// Does the events.
	/// </summary>
	public void DoEvents() {
		// Pickup event
		if (pickable && picked)
			OnPickup ();

		// Drop event
		if (droppable && dropped)
			OnDrop ();

		// Interact event
		if (interactable && interacted)
			OnInteract ();

		// Break event
		if (breakable && breaked)
			OnBreak ();

		// Climb event
		if (climbable && climbed)
			OnClimb ();
	}

	#region Overridable methods
	/// <summary>
	/// Raises the pickup event.
	/// </summary>
	public virtual void OnPickup() {

	}

	/// <summary>
	/// Raises the drop event.
	/// </summary>
	public virtual void OnDrop() {

	}

	/// <summary>
	/// Raises the interact event.
	/// </summary>
	public virtual void OnInteract() {

	}

	/// <summary>
	/// Raises the break event.
	/// </summary>
	public virtual void OnBreak() {

	}

	/// <summary>
	/// Raises the climb event.
	/// </summary>
	public virtual void OnClimb() {

	}
	#endregion
}
