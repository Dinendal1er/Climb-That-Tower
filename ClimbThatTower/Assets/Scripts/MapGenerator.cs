using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

namespace Completed
{

	public class MapGenerator : MonoBehaviour
	{
		public enum FloorType {
			BLACKANDWHITE = 0,
			BRICK_GREY = 1,
			BRICKS = 2,
			BRICKS2 = 3,
			CLEARSTONE = 4,
			GRASS = 5,
			MOSS = 6,
			REDCARPET = 7,
			SAND = 8,
			STONE = 9,
			STONE2 = 10,
			WATER = 11,
			WOOD = 12,
			NONE = 13
		};

		public enum RoomType
		{
			BOSS,
			SEMIBOSS,
			FIGHT,
			EVENT,
			START,
			NONE
		};

		// Using Serializable allows us to embed a class with sub properties in the inspector.
		[Serializable]
		public class Count
		{
			public int minimum;             //Minimum value for our Count class.
			public int maximum;             //Maximum value for our Count class.


			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}

		[Serializable]
		public struct FieldInfo
		{
			public FloorType ftype;
			public float height;
		}

		[Serializable]
		public struct MiniMapField
		{
			public RoomType rtype;
			public bool explored;
		}

		public float maxHeight = 0;
		public int columns = 0;
		public int rows = 0;
		public GameObject[] floorTiles; // Array of floor prefabs.
		private Transform boardHolder; // A variable to store a reference to the transform of our Board object.
		public FieldInfo[] grid; //The grid that is used to generates the map

		int _coord(Vector2 coord)
		{
			return (_coord((int)coord.x, (int)coord.y));
		}

		int _coord(int x, int y)
		{
			if (x < 0)
				x = 0;
			if (y < 0)
				y = 0;
			if (x > columns)
				x = columns;
			if (y > rows)
				y = rows;
			return (x * columns + y);
		}

		//Initialize the grid map with a blank map surrounded by walls
		void InitMapGrid()
		{
			grid = new FieldInfo[(columns + 1) * (rows + 1)];
			for (int x = 0; x < columns + 1; ++x)
			{
				for (int y = 0; y < rows + 1; ++y)
				{
					grid[_coord(x, y)] = new FieldInfo();
					if (x == 0 || x == columns || y == 0 || y == rows)
					{
						grid[_coord(x, y)].ftype = FloorType.BRICKS2;
						grid[_coord(x, y)].height = 2F;
					}
					else
					{
						grid[_coord(x, y)].ftype = FloorType.CLEARSTONE;
						grid[_coord(x, y)].height = 1F;
					}
				}
			}
		}

		//Pops the element of the map
		void BoardSetup ()
		{
			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject ("Board").transform;
			for (int x = 0; x < columns + 1; x++)
			{
				for (int y = 0; y < rows + 1; y++)
				{
					if (grid[_coord(x, y)].ftype != FloorType.NONE)
					{
						GameObject toInstantiate = floorTiles[(int)grid[_coord(x, y)].ftype];
						Quaternion rotation = Quaternion.identity;
						rotation.eulerAngles = new Vector3(45F, 0, 45F);
						for (int i = 0; i < (int)grid[_coord(x, y)].height + (grid[_coord(x, y)].height - (int)grid[_coord(x, y)].height > 0.0001 ? 1 : 0); ++i)
						{
							//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
							GameObject instance = Instantiate(toInstantiate, rotation * new Vector3(x, y, -i), Quaternion.identity) as GameObject;
							instance.transform.localRotation = rotation;

							if ((int)grid[_coord(x, y)].height <= i)
							{
								float height = grid[_coord(x, y)].height - (int)grid[_coord(x, y)].height;

								instance.transform.localScale = new Vector3(1, 1, height);
								instance.transform.Translate(new Vector3(0, 0, -(height - 1) / 2.0F));
							}
							//Old version
//							instance.transform.localScale = new Vector3(1, 1, grid[_coord(x, y)].height);
//							instance.transform.Translate(new Vector3(0, 0, -(grid[_coord(x, y)].height - 1) / 2.0F));

							//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
							instance.transform.SetParent(boardHolder);
						}
					}
				}
			}
		}

		static bool isWall(int nb)
		{
			return (nb <= (int)FloorType.BRICKS2 && nb != (int)FloorType.BLACKANDWHITE);
		}

		private static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
		
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static List<Vector2> Line(Vector2 p0, Vector2 p1)
		{
			int x0 = (int)p0.x;
			int y0 = (int)p0.y;
			int x1 = (int)p1.x;
			int y1 = (int)p1.y;
			bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
			List<Vector2> retval = new List<Vector2>();

			if (steep)
			{
				Swap<int>(ref x0, ref y0);
				Swap<int>(ref x1, ref y1);
			}
			if (x0 > x1)
			{
				Swap<int>(ref x0, ref x1);
				Swap<int>(ref y0, ref y1);
			}
			int dX = (x1 - x0), dY = Math.Abs(y1 - y0);
			int err = (dX / 2);
			int ystep = (y0 < y1 ? 1 : -1), y = y0;

			for (int x = x0; x <= x1; ++x)
			{
				if (steep)
					retval.Add(new Vector2(y, x));
				else
					retval.Add(new Vector2(x, y));
				err = err - dY;
				if (err < 0)
				{
					y += ystep;
					err += dX;
				}
			}
			return (retval);
		}

		delegate bool myComp(List<Vector2> l);
		delegate void del(List<Vector2> l, float a, float b, float c, float d, myComp f);

		private List<Vector2> RandomShapedRoom(Vector2 roomCenter, int width, int height)
		{
			Vector2 a1, a2, b1, b2, c1, c2, d1, d2;
			List<Vector2> retval = new List<Vector2>();
			List<Vector2> tmp = new List<Vector2>();

			a1 = new Vector2(roomCenter.x - width / 2, roomCenter.y - height / 2);
			b1 = new Vector2(roomCenter.x + width / 2, roomCenter.y - height / 2);
			c1 = new Vector2(roomCenter.x + width / 2, roomCenter.y + height / 2);
			d1 = new Vector2(roomCenter.x - width / 2, roomCenter.y + height / 2);
			a2 = new Vector2(a1.x, a1.y / 2);
			b2 = new Vector2(b1.x + (columns - b1.x) / 2, b1.y);
			c2 = new Vector2(c1.x, c1.y + (rows - c1.y) / 2);
			d2 = new Vector2(d1.x, d1.y + (rows - d1.y) / 2);

			del randomAddCorner = (l, a, b, c, d, f) =>
			{
				// Adds a new point 1 out of 2 times
				if (Random.Range(0, 2) % 2 == 0)
				{
					l.Add(new Vector2(Random.Range(a, b), Random.Range(c, d)));
					// f determines if the newly added point needs to be swapped with the last one
					if (f(l))
					{
						Vector2 t = l[l.Count - 2];

						l[l.Count - 2] = l[l.Count - 1];
						l[l.Count - 1] = t;
					}
				}
			};
			tmp.Add(new Vector2(Random.Range(a1.x, b1.x), Random.Range(a2.y, a1.y)));
			randomAddCorner(tmp, a1.x, b1.x, a2.y, a1.y, l => l[l.Count - 2].x > l[l.Count - 1].x);
			tmp.Add(new Vector2(Random.Range(b1.x, b2.x), Random.Range(b1.y, c1.y)));
			randomAddCorner(tmp, b1.x, b2.x, b1.y, c1.y, l => l[l.Count - 2].y > l[l.Count - 1].y);
			tmp.Add(new Vector2(Random.Range(d1.x, c1.x), Random.Range(c1.y, c2.y)));
			randomAddCorner(tmp, d1.x, c1.x, c1.y, c2.y, l => l[l.Count - 2].x < l[l.Count - 1].x);
			tmp.Add(new Vector2(Random.Range(d2.x, d1.x), Random.Range(a1.y, d1.y)));
			randomAddCorner(tmp, d2.x, d1.x, a1.y, d1.y, l => l[l.Count - 2].y < l[l.Count - 1].y);
			for (int i = 0; i < tmp.Count; ++i)
			{
				retval.AddRange(Line(tmp[i], i + 1 == tmp.Count ? tmp[0] : tmp[i + 1]));
			}
			return (retval);
		}

		private void BoundaryFill4(FloorType remplacement, FloorType boundary, Vector2 coord)
		{
			if (coord.x == 0 || coord.y == 0 || coord.x == columns || coord.y == rows || grid[_coord(coord)].ftype == remplacement || grid[_coord(coord)].ftype == boundary)
			{
				return;
			}
			grid[_coord(coord)].ftype = remplacement;
			BoundaryFill4(remplacement, boundary, new Vector2(coord.x - 1, coord.y));
			BoundaryFill4(remplacement, boundary, new Vector2(coord.x, coord.y - 1));
			BoundaryFill4(remplacement, boundary, new Vector2(coord.x, coord.y + 1));
			BoundaryFill4(remplacement, boundary, new Vector2(coord.x + 1, coord.y));
		}

		private void BoundaryFill8(FloorType remplacement, FloorType boundary, Vector2 coord)
		{
			if (coord.x == 0 || coord.y == 0 || coord.x == columns || coord.y == rows || grid[_coord(coord)].ftype == remplacement || grid[_coord(coord)].ftype == boundary)
			{
				return;
			}
			grid[_coord(coord)].ftype = remplacement;
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x - 1, coord.y));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x - 1, coord.y - 1));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x, coord.y - 1));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x + 1, coord.y - 1));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x, coord.y + 1));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x - 1, coord.y + 1));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x + 1, coord.y));
			BoundaryFill8(remplacement, boundary, new Vector2(coord.x + 1, coord.y + 1));
		}

		private void FloodFill4(FloorType remplacement, FloorType target, Vector2 coord)
		{
			if (coord.x == 0 || coord.y == 0 || coord.x == columns || coord.y == rows || grid[_coord(coord)].ftype == remplacement || grid[_coord(coord)].ftype != target)
			{
				return;
			}
			grid[_coord(coord)].ftype = remplacement;
			FloodFill4(remplacement, target, new Vector2(coord.x - 1, coord.y));
			FloodFill4(remplacement, target, new Vector2(coord.x, coord.y - 1));
			FloodFill4(remplacement, target, new Vector2(coord.x, coord.y + 1));
			FloodFill4(remplacement, target, new Vector2(coord.x + 1, coord.y));
		}

		private void FloodFill8(FloorType remplacement, FloorType target, Vector2 coord)
		{
			if (coord.x == 0 || coord.y == 0 || coord.x == columns || coord.y == rows || grid[_coord(coord)].ftype == remplacement || grid[_coord(coord)].ftype != target)
			{
				return;
			}
			grid[_coord(coord)].ftype = remplacement;
			FloodFill8(remplacement, target, new Vector2(coord.x - 1, coord.y));
			FloodFill8(remplacement, target, new Vector2(coord.x - 1, coord.y - 1));
			FloodFill8(remplacement, target, new Vector2(coord.x, coord.y - 1));
			FloodFill8(remplacement, target, new Vector2(coord.x + 1, coord.y - 1));
			FloodFill8(remplacement, target, new Vector2(coord.x, coord.y + 1));
			FloodFill8(remplacement, target, new Vector2(coord.x - 1, coord.y + 1));
			FloodFill8(remplacement, target, new Vector2(coord.x + 1, coord.y));
			FloodFill8(remplacement, target, new Vector2(coord.x + 1, coord.y + 1));
		}

		private void PatternCastleThroneRoom()
		{
			List<Vector2> room = RandomShapedRoom(new Vector2(columns / 2, rows / 2), 15, 15);

			foreach(Vector2 wall in room)
			{
				grid[_coord(wall)].ftype = FloorType.BRICK_GREY;
				grid[_coord(wall)].height = 2F;
			}

			BoundaryFill4(FloorType.REDCARPET, FloorType.BRICK_GREY, new Vector2(columns / 2, rows / 2));
			FloodFill8(FloorType.BRICKS, FloorType.BRICK_GREY, room[0]);
		}

		private void PopRiver(Vector2 coord, Vector2 last, Vector2 direction)
		{
			int riverRange = 4; // The range over which the river digs the field;

			Vector2 rangeDirection = new Vector2(-(coord.y - last.y), coord.x - last.x);
			if (coord.x == 0 || coord.y == 0 || coord.x == columns || coord.y == rows || grid[_coord(coord)].ftype == FloorType.WATER)
				return;
			grid[_coord(coord)].ftype = FloorType.WATER;
			grid[_coord(coord)].height /= 2.0f;
			if (rangeDirection.x != 0)
			{
				InterpolateLineX(coord, coord + riverRange * rangeDirection);
				InterpolateLineX(coord, coord - riverRange * rangeDirection);
			}
			else
			{
				InterpolateLineY(coord, coord + riverRange * rangeDirection);
				InterpolateLineY(coord, coord - riverRange * rangeDirection);
			}
			switch (Random.Range(0, 9))
			{
			case 0:
				if (last.x + 1 == coord.x)
					PopRiver(new Vector2(coord.x + 1, coord.y), coord, direction);
				else
					PopRiver(new Vector2(coord.x - 1, coord.y), coord, direction);
				break;
			case 1:
				if (last.x - 1 == coord.x)
					PopRiver(new Vector2(coord.x - 1, coord.y), coord, direction);
				else
					PopRiver(new Vector2(coord.x + 1, coord.y), coord, direction);
				break;
			case 2:
				if (last.y + 1 == coord.y)
					PopRiver(new Vector2(coord.x, coord.y + 1), coord, direction);
				else
					PopRiver(new Vector2(coord.x, coord.y - 1), coord, direction);
				break;
			case 3:
				if (last.y - 1 == coord.y)
					PopRiver(new Vector2(coord.x, coord.y - 1), coord, direction);
				else
					PopRiver(new Vector2(coord.x, coord.y + 1), coord, direction);
				break;
			default:
				PopRiver(coord + direction, coord, direction);
				break;
			}
		}
			
		private void InterpolateLineX(Vector2 a, Vector2 b)
		{
			float h = (grid[_coord(b)].height - grid[_coord(a)].height) / (b.x - a.x);

			for (int i = 0; i != (b.x - a.x); i += ((b.x - a.x) > 0 ? 1 : -1))
			{
				grid[_coord(new Vector2(a.x + i, a.y))].height = grid[_coord(a)].height + h * (float)i;
			}
		}

		private void InterpolateLineY(Vector2 a, Vector2 b)
		{
			float h = (grid[_coord(b)].height - grid[_coord(a)].height) / (b.y - a.y);

			for (int i = 0; i != (b.y - a.y); i += ((b.y - a.y) > 0 ? 1 : -1))
			{
				grid[_coord(new Vector2(a.x, a.y + i))].height = grid[_coord(a)].height + h * (float)i;
			}
		}

		private void PlasmaHeightField(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
		{
			InterpolateLineX(a, b);
			InterpolateLineX(c, d);
			for (int i = 0; i != (b.x - a.x + ((b.x - a.x) > 0 ? 1 : -1)); i += ((b.x - a.x) > 0 ? 1 : -1))
			{
				InterpolateLineY(new Vector2(a.x + i, a.y), new Vector2(a.x + i, c.y));
			}
			if (b.x - d.x > 2)
			{
				Vector2 center;
				Vector2 north, south, east, west;
				float variance = ((b.x - d.x) / columns) * 1.0f;

				center = new Vector2(d.x + ((int)(b.x - d.x) / 2), d.y + ((int)(b.y - d.y) / 2));
				north = new Vector2(d.x + ((int)(b.x - d.x) / 2), b.y);
				south = new Vector2(d.x + ((int)(b.x - d.x) / 2), d.y);
				east = new Vector2(d.x, d.y + ((int)(b.y - d.y) / 2));
				west = new Vector2(b.x, d.y + ((int)(b.y - d.y) / 2));

				grid[_coord(center)].height += Random.Range(-grid[_coord(center)].height * variance, maxHeight * variance);
				PlasmaHeightField(a, north, center, east);
				PlasmaHeightField(north, b, west, center);
				PlasmaHeightField(center, west, c, south);
				PlasmaHeightField(east, center, south, d);
			}
		}

		private void PlasmaHeightField()
		{
			Vector2 a, b, c, d;

			a = new Vector2(1, rows - 1);
			b = new Vector2(columns - 1, rows - 1);
			c = new Vector2(columns - 1, 1);
			d = new Vector2(1, 1);
			grid[_coord(a)].height += Random.Range(-grid[_coord(a)].height, maxHeight);
			grid[_coord(b)].height += Random.Range(-grid[_coord(b)].height, maxHeight);
			grid[_coord(c)].height += Random.Range(-grid[_coord(c)].height, maxHeight);
			grid[_coord(d)].height += Random.Range(-grid[_coord(d)].height, maxHeight);
			PlasmaHeightField(a, b, c, d);
		}

		private void ColorByHeight()
		{
			float heightForStone = 5.0f;
			float heightForGrass = 2f;

			for (int x = 0; x < columns; x++)
			{
				for (int y = 0; y < rows; y++)
				{
					if (x > 0 && x < columns && y > 0 && y < rows && grid[_coord(x, y)].ftype != FloorType.WATER)
					{
						if (grid[_coord(x, y)].height > heightForStone)
						{
							grid[_coord(x, y)].ftype = FloorType.STONE;
						}
						else if (grid[_coord(x, y)].height > heightForGrass)
						{
							grid[_coord(x, y)].ftype = FloorType.MOSS;
						}
						else
						{
							grid[_coord(x, y)].ftype = FloorType.SAND;
						}
					}
				}
			}
		}

		//SetupScene initializes our level and calls the previous functions to lay out the game board
		public void Awake ()
		{
			columns = 34;
			rows = 34;
			maxHeight = 10F;

			InitMapGrid ();
			PlasmaHeightField();
			PopRiver(new Vector2(12, 1), new Vector2(11, 1), new Vector2(0, 1));
			PopRiver(new Vector2(33, 12), new Vector2(33, 12), new Vector2(-1, 0));
			ColorByHeight();
			BoardSetup ();
		}
	}
}