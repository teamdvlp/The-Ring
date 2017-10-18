using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CompareNature  {
    // nature1 sẽ được đem so sánh với nature2   
	private string nature1;
	private string nature2;

	public CompareNature() {
	}

	// 0: nature1 khắc nature2;
	// 1: nature1 bằng nature2;
	// 2: nature2 khắc nature1
	// 3: nature1 sinh nature2 và ngược lại
	// 4: nature1 không khắc nature2 và ngược lại
    public int compareNature(int natureIndex1, int natureIndex2) {
		ListNature lsNature = new ListNature ();
		nature1 = lsNature.getListNature () [natureIndex1];
		nature2 = lsNature.getListNature () [natureIndex2];

        switch (nature1)
        {
            case "Null":
                {
                    return 3;
                }
            case "Kim":
                {
				if (nature2.Equals ("Mộc")) {
					return 0;
				} else if (nature2.Equals ("Kim")) {
					return 1;
				} else if (nature2.Equals ("Hỏa")) {
					return 2;
				} else if (nature2.Equals("Thủy")) {
					return 3;
				} else {
					return 4;
				}

                }

			case "Mộc":
			{
				if (nature2.Equals ("Thổ")) {
					return 0;
				} else if (nature2.Equals ("Mộc")) {
					return 1;
				} else if (nature2.Equals ("Kim")) {
					return 2;
				} else if (nature2.Equals("Hỏa")) {
					return 3;
				} else {
					return 3;
				}
			}

			case "Thủy": 
			{
				if (nature2.Equals ("Hỏa")) {
					return 0;
				} else if (nature2.Equals ("Thủy")) {
					return 1;
				} else if (nature2.Equals ("Thổ")) {
					return 2;
				} else if (nature2.Equals("Mộc")) {
					return 3;
				} else {
					return 4;
				}
			}

			case "Hỏa": 
			{
				if (nature2.Equals ("Kim")) {
					return 0;
				} else if (nature2.Equals ("Hỏa")) {
					return 1;
				} else if (nature2.Equals ("Thủy")) {
					return 2;
				} else if (nature2.Equals("Thổ")) {
					return 3;
				} else {
					return 4;
				}
			}

		case "Thổ": 
			{
				if (nature2.Equals ("Thủy")) {
					return 0;
				} else if (nature2.Equals ("Thổ")) {
					return 1;
				} else if (nature2.Equals ("Mộc")) {
					return 2;
				} else if (nature2.Equals("Kim")) {
					return 3;
				} else {
					return 4;
				}
			}
		default:
			return -1; 
		}
	}}
