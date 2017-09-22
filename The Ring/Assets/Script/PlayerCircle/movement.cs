<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
	void Start () {
		
	}
	
	void Update () {
			this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * 60;
			trackpad.positionOffset = Vector2.zero;
}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;


    
	void Start () {
		
	}
	
	void Update () {
			this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * 80;
			trackpad.positionOffset = Vector2.zero;
    }
}
>>>>>>> efd8f170e65cad631cea448820fd7e05d72d02a3
