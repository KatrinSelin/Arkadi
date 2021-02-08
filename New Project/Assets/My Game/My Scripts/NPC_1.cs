using UnityEngine;
using System.Collections;

public class NPC_1 : NPC {
	 
	// Use this for initialization
	public override void OnSetUpDialogue() {

		Speech.AddDialogue("0", "Welcome to our planet!", "1");
		Speech.AddDialogue("1", "You have to collect all of the coins", "2");
		Speech.AddDialogue("2", "As well as the Power Up");
	}

	// Triggered when the player comes in range of the NPC
	public override void OnTriggerNPC( Collider other ){

		if (Abilities.doubleJumpEnabled)
		{
			Speech.SetDialogue("2");
		}
		else
		{
			Speech.SetDialogue("0");
		}
	}
}