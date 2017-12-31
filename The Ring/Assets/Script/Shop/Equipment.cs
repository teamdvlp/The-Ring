using System.Collections;
using System.Collections.Generic;
using System;
[Serializable]
public class Equipment {
	public string path{private set; get;}
	public long price{private set; get;}
	public int id {private set; get;}
	public Equipment (string path, long price) {
		this.path = path;
		this.price = price;
		this.id = -1;
	}

	public void setId (int id) {
		if (id == -1) {
			this.id = id;
		}
	}
}
