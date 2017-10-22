using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;
using UnityEngine;
using Mono.Data.Sqlite;
public class SqliteUserManager {
	public static string CONNECTION_STRING = "URI=file:" + Application.dataPath + "/" + "User/UserData/User.sqlite";
	public static IDbConnection conn = new SqliteConnection (CONNECTION_STRING);

	public static void connect () {
		if (conn.State != ConnectionState.Open) {
			conn.Open();
		}
	}

	public static Double getCoin () {
		string query = "select Coin from UserInfo";
		Double Coin = 0;
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
					IDataReader idata = idb.ExecuteReader();
					Coin = Convert.ToDouble(idata[0]);
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
		return Coin;
	}

	public static int getBestScore () {
		string query = "select BestScore from UserInfo";
		int BestScore = 0;
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
					IDataReader idata = idb.ExecuteReader();
					BestScore = Convert.ToInt32(idata[0]);
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
		return BestScore;
	}

	public static List<int> getCharacter () {
		string query = "select CharacterID from Character";
		List<int> Character = new List<int>();
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
					IDataReader idata = idb.ExecuteReader();
					int i = 0;
					while (idata.Read()) {
					Character.Add(Convert.ToInt32(idata[0]));
					}
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
		return Character;
	}

	public static void setCoin (Double Coin) {
		string query = "update UserInfo set Coin = " + Coin + " where STT = 0";
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}

	public static void setBestScore (Double bestScore) {
		string query = "update UserInfo set BestScore = " + bestScore + " where STT = 0";
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}
	public static void SubtractCharacter (int CharacterID) {
		string query = "delete from Character where CharacterID = " + CharacterID;
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}
	public static void addCharacter (int CharacterID) {
		string query = "insert into Character (CharacterID) values (" + CharacterID + ")";
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}

	public static void AddCoin (Double Coin) {
		string query = "update UserInfo set Coin = Coin +" + Coin + " where STT = 0";
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}

	public static void ClearAllCharacter () {
		string query = "delete from Character";
		connect();
		try {
			using(conn) {
				using (IDbCommand idb = conn.CreateCommand()) {
					idb.CommandText = query;
					idb.ExecuteNonQuery();
				}
			}
		}catch (Exception e) {
			Debug.Log("Loi: " + e.ToString());
		}
	}

}
