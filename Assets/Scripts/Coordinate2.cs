using System;

[System.Serializable]
public class Coordinate2 : IComparable<Coordinate2> {
	public int X;
	public int Y;

	public Coordinate2(int x, int y) {
		X = x;
		Y = y;
	}

	public int CompareTo (Coordinate2 other) {
		int xCompare = X.CompareTo (other.X);

		if (xCompare == 0) {
			return Y.CompareTo (other.Y);
		}

		return xCompare;
	}
}