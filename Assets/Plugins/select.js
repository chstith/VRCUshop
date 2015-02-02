#pragma strict

function OnCollisionEnter(theCollision : Collision){
	Debug.Log("Hit: " + theCollision.gameObject.name);
}