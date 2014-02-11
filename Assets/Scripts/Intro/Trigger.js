#pragma strict

function Start () {
	
	if (Application.loadedLevelName.Equals("Intro 1")) {
		yield WaitForSeconds (3);
		Application.LoadLevel("Intro 2");
	}
	
	if (Application.loadedLevelName.Equals("Intro 2")) {
		yield WaitForSeconds (3);
		Application.LoadLevel("Intro 3");
	}
	
	if (Application.loadedLevelName.Equals("Intro 3")) {
		yield WaitForSeconds (3);
		Application.LoadLevel("Intro 4");
	}
	
	if (Application.loadedLevelName.Equals("Intro 4")) {
		yield WaitForSeconds (3);
		Application.LoadLevel("Menu");
	}
}

function Update(){


}


